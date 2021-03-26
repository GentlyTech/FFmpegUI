using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using static MediaConverter.SharedMethods;
using static MediaConverter.Enums;
using System.Text;
using System.Diagnostics;

namespace MediaConverter
{
    public partial class Form1 : Form
    {
        OpenFileDialog filePicker = new OpenFileDialog();
        CommonOpenFileDialog folderPicker = new CommonOpenFileDialog();
        List<AudioFile> audioFiles = new List<AudioFile>();

        bool conversionInProgress = false;

        public Form1()
        {
            InitializeComponent();

            Settings.Default.PropertyChanged += ProcessSettingsTriggers;

            if (Settings.Default.DefaultOpenDirectory.Length < 1)
            {
                Settings.Default.DefaultOpenDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }

            if (Settings.Default.DefaultSaveDirectory.Length < 1)
            {
                Settings.Default.DefaultSaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }

            filePicker.InitialDirectory = Settings.Default.DefaultOpenDirectory;
            filePicker.Multiselect = true;
            filePicker.Title = "Add files to queue";
            SetFilter();

            folderPicker.IsFolderPicker = true;
            folderPicker.Title = "Select save location";
            folderPicker.InitialDirectory = Settings.Default.DefaultSaveDirectory;
            folderPicker.DefaultDirectory = Settings.Default.DefaultSaveDirectory;

            SaveLocationTextBox.Text = Settings.Default.DefaultSaveDirectory;

            FormatSelector.DataSource = Enum.GetValues(typeof(AudioFormat));

            ThreadPool.SetMaxThreads(8, 8);

            LogWindow.GetInstance.Info("Application Initialized");
        }

        private void ProcessSettingsTriggers(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UseFileFilters")
            {
                SetFilter();
            }
            else if (e.PropertyName == "DefaultSaveDirectory")
            {
                folderPicker.InitialDirectory = Settings.Default.DefaultSaveDirectory;
                folderPicker.DefaultDirectory = Settings.Default.DefaultSaveDirectory;
            }
            else if (e.PropertyName == "DefaultOpenDirectory")
            {
                filePicker.InitialDirectory = Settings.Default.DefaultOpenDirectory;
            }
        }

        private void SetFilter()
        {
            if (Settings.Default.UseFileFilters)
            {
                filePicker.Filter = GenerateFilters();
            }
            else
            {
                filePicker.Filter = null;
            }
        }

        private string GenerateFilters()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string format in Enum.GetNames(typeof(AudioFormat)))
            {
                builder.Append($"Audio File (*.{format})|*.{format}|");
            }
            foreach (string format in Enum.GetNames(typeof(VideoFormat)))
            {
                builder.Append($"Video File (*.{format})|*.{format}|");
            }
            builder.Append("All files (*.*)|*.*");
            return builder.ToString();
        }

        private void SetConversionState(bool state)
        {
            conversionInProgress = state;
            if (conversionInProgress)
            {
                ConvertButton.Text = "Cancel";
            }
            else
            {
                ConvertButton.Text = "Convert";
            }
        }

        private void UpdateCurrentProgressBar(int percent)
        {
            CurrentProgressBar.Invoke(new MethodInvoker(() => { CurrentProgressBar.Value = percent; }));
        }

        private void UpdateTotalProgressBar()
        {
            TotalProgressBar.Invoke(new MethodInvoker(() =>
            {
                TotalProgressBar.Value = TotalProgressBar.Value < TotalProgressBar.Maximum ? TotalProgressBar.Value + 1 : TotalProgressBar.Maximum;
                if (TotalProgressBar.Value == TotalProgressBar.Maximum)
                {
                    LogWindow.GetInstance.Success("Queue finished.");
                    SystemSounds.Beep.Play();
                }
            }));
        }

        private void ResetProgressBars()
        {
            TotalProgressBar.Maximum = 100;
            TotalProgressBar.Value = 0;
            CurrentProgressBar.Value = 0;
        }

        private void RemoveSelectedFile()
        {
            if (FileList.SelectedItem != null)
            {
                string x = FileList.SelectedItem.ToString();
                for (int i = 0; i < audioFiles.Count; i++)
                {
                    if (audioFiles[i].GetFileName() == x)
                    {
                        string name = audioFiles[i].GetFileName();
                        audioFiles.RemoveAt(i);
                        LogWindow.GetInstance.Info($"Removed {name} from queue");
                    }
                }

                int lastIndex = FileList.SelectedIndex;

                FileList.Items.Remove(FileList.SelectedItem);

                if (FileList.Items.Count > 0)
                {
                    FileList.SelectedIndex = (lastIndex - 1) > 0 ? lastIndex - 1 : 0;
                }

            }
            else
            {
                if (FileList.Items.Count > 0)
                {
                    FileList.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = filePicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                new Thread(() => {
                    if (filePicker.FileNames != null)
                    {
                        foreach (string file in filePicker.FileNames)
                        {
                            AudioFile x = new AudioFile(file);
                            audioFiles.Add(x);
                            LogWindow.GetInstance.Info($"Added {x.GetFileName()} to queue");
                            FileList.Invoke(new MethodInvoker(() => { FileList.Items.Add(x.GetFileName()); }));
                        }
                    }
                }).Start();
            }
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedFile();
        }
        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            LogWindow.GetInstance.Info("Cleared queue");
            audioFiles.Clear();
            FileList.Items.Clear();
        }
        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedFile();
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (!conversionInProgress)
            {
                LogWindow.GetInstance.Info("Conversion Started");
                SetConversionState(true);
                if (audioFiles.Count > 0)
                {
                    try
                    {
                        if (!Directory.Exists(SaveLocationTextBox.Text))
                        {
                            LogWindow.GetInstance.Warn($"Output directory {SaveLocationTextBox.Text} was not found. Creating...");
                            Directory.CreateDirectory(SaveLocationTextBox.Text);
                            LogWindow.GetInstance.Success($"Successfully created output directory at {SaveLocationTextBox.Text}");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex.Message, "Error");
                        LogWindow.GetInstance.Error($"Unable to create output directory: {ex.Message}");
                    }

                    ResetProgressBars();
                    TotalProgressBar.Maximum = audioFiles.Count;

                    AudioFormat format = (AudioFormat)FormatSelector.SelectedItem;
                    string saveLocation = SaveLocationTextBox.Text;

                    foreach (AudioFile file in audioFiles)
                    {
                        LogWindow.GetInstance.Info($"Converting File: {file.GetFullFileName()}, Output: {file.GetFileName()}.{format}");
                        ThreadPool.QueueUserWorkItem((e) => { file.ConvertTo(format, saveLocation); });
                        file.OnProgressChange += UpdateCurrentProgressBar;
                        file.OnProgressComplete += () =>
                        {
                            LogWindow.GetInstance.Success($"Done converting {file.GetFileName()}");
                            UpdateTotalProgressBar();
                        };
                        file.OnProgressError += (reason) => { LogWindow.GetInstance.Error($"Unable to convert {file.GetFileName()} due to the following: {reason}"); };
                    }
                }
                else
                {
                    LogWindow.GetInstance.Error("There are no files to be converted. Aborting.");
                    ShowErrorMessage("Nothing to convert");
                }
                SetConversionState(false);
            }
            else
            {
                LogWindow.GetInstance.Info("User requested abort");
                foreach (AudioFile file in audioFiles)
                {
                    file.CancelConvert();
                }
                ResetProgressBars();
                SetConversionState(false);
            }
        }

        private void SaveLocationButton_Click(object sender, EventArgs e)
        {
            CommonFileDialogResult result = folderPicker.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                SaveLocationTextBox.Text = folderPicker.FileName;
            }

        }
        private void FormatSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogWindow.GetInstance.Info($"Target conversion format now set to {(AudioFormat)FormatSelector.SelectedItem}");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogWindow.GetInstance.Info("Exit command received");
            Settings.Default.Save();
            LogWindow.GetInstance.Info("Saving settings...");
            LogWindow.GetInstance.SaveLog();
            LogWindow.GetInstance.Info("Exiting...");
        }

        private void OpenSaveDirButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(SaveLocationTextBox.Text))
                {
                    Directory.CreateDirectory(SaveLocationTextBox.Text);
                }
                Process.Start("explorer.exe", SaveLocationTextBox.Text);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message, "Error");
                LogWindow.GetInstance.Error(ex.Message);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            new SettingsWindow().ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LogWindow.GetInstance.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void SaveLocationTextBox_TextChanged(object sender, EventArgs e)
        {
            LogWindow.GetInstance.Info($"Output directory now set to: {SaveLocationTextBox.Text}");
        }
    }
}
