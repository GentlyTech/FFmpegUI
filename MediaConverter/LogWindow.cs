using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaConverter
{
    public partial class LogWindow : Form
    {
        private static LogWindow instance;
        private StringBuilder log = new StringBuilder();
        public LogWindow()
        {
            InitializeComponent();
        }
        public static LogWindow GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LogWindow();
                }
                return instance;
            }
        }

        public void SaveLog()
        {
            string LogDir = $"{Environment.CurrentDirectory}\\Logs";
            string LogFileName = $"{LogDir}\\{DateTime.Now.ToFileTime()}.log";
            try
            {
                if (!Directory.Exists(LogDir))
                {
                    Warn($"Log directory {LogDir} was not found. Creating...");
                    Directory.CreateDirectory(LogDir);
                    Success($"Successfully created output directory at {LogDir}");
                }

                Info($"Writing log to file {LogFileName}");
                File.WriteAllText(LogFileName, log.ToString());
                Success($"Log successfully saved to {LogFileName}");
            }
            catch (Exception ex)
            {
                Error($"Unable to create log directory: {ex.Message}");
                Error($"Failed to write log to disk");
            }
        }

        private void WriteToLog(string message)
        {
            log.AppendLine(message);
            if (this.IsHandleCreated)
            {
                LogOutput.Invoke(new MethodInvoker(() =>
                {
                    LogOutput.Text = log.ToString();
                }));
            }
        }
        public void Info(string message)
        {
            WriteToLog(message);
            Out(message);
        }

        public void Success(string message)
        {
            WriteToLog(message);
            Out(message);
        }

        public void Warn(string message)
        {
            string modifiedMessage = "WARN: " + message;
            WriteToLog(modifiedMessage);
            Out(modifiedMessage);
        }

        public void Error(string message)
        {
            string modifiedMessage = "ERROR: " + message;
            WriteToLog(modifiedMessage);
            Out(modifiedMessage);
        }

        private void Out(string message)
        {
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }

        private void RefreshLog()
        {
            LogOutput.Text = log.ToString();
        }

        private void LogOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                log.Clear();
                Info("Log Cleared");
                LogOutput.Clear();
            }
            else if (e.KeyCode == Keys.F5)
            {
                RefreshLog();
            }
        }

        private void LogWindow_Load(object sender, EventArgs e)
        {
            RefreshLog();
        }
    }
}
