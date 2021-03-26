using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaConverter
{
    public partial class SettingsWindow : Form
    {
        CommonOpenFileDialog folderPicker = new CommonOpenFileDialog();
        public SettingsWindow()
        {
            InitializeComponent();
            folderPicker.IsFolderPicker = true;
            folderPicker.InitialDirectory = Settings.Default.DefaultSaveDirectory;
            folderPicker.DefaultDirectory = Settings.Default.DefaultSaveDirectory;
        }

        private string ShowFolderPicker()
        {
           CommonFileDialogResult result = folderPicker.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                return folderPicker.FileName;
            }
            else
            {
                return null;
            }
        }

        private void SaveSettings()
        {
            Settings.Default.DefaultOpenDirectory = DefaultStartLocationTextbox.Text;
            Settings.Default.DefaultSaveDirectory = DefaultOutputLocationTextbox.Text;
            Settings.Default.UseFileFilters = FileFiltersCheckbox.Checked;
            LogWindow.GetInstance.Success("Settings Saved");
        }

        private void ReloadSettings()
        {
            DefaultStartLocationTextbox.Text = Settings.Default.DefaultOpenDirectory;
            DefaultOutputLocationTextbox.Text = Settings.Default.DefaultSaveDirectory;
            FileFiltersCheckbox.Checked = Settings.Default.UseFileFilters;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            LogWindow.GetInstance.Success("Settings Reset");
            ReloadSettings();
        }

        private void DefaultStartLocationTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DefaultOutputLocationTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DefaultStartLocationButton_Click(object sender, EventArgs e)
        {
            string result = ShowFolderPicker();
            if (result != null)
            {
                DefaultStartLocationTextbox.Text = result;
            }
        }

        private void DefaultOutputLocationButton_Click(object sender, EventArgs e)
        {
            string result = ShowFolderPicker();
            if (result != null)
            {
                DefaultOutputLocationTextbox.Text = result;
            }
        }

        private void FileFiltersCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            ReloadSettings();
        }
    }
}
