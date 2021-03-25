using FFmpeg.NET;
using FFmpeg.NET.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MediaConverter.SharedMethods;
using static MediaConverter.Enums;

namespace MediaConverter
{
    class AudioFile
    {
        string Path, FileName, FullFileName, Extension;
        CancellationTokenSource cancellationSource;
        CancellationToken cancellationToken;

        public delegate void ProgressDelegate(int percent);
        public delegate void ErrorDelegate(string reason);
        public delegate void SuccessDelegate();
        public event ProgressDelegate OnProgressChange;
        public event ErrorDelegate OnProgressError;
        public event SuccessDelegate OnProgressComplete;

        public AudioFile(string path)
        {
            this.Path = path;
            this.FileName = System.IO.Path.GetFileNameWithoutExtension(path);
            this.FullFileName = System.IO.Path.GetFileName(path);
            this.Extension = System.IO.Path.GetExtension(path);
            cancellationSource = new CancellationTokenSource();
            cancellationToken = cancellationSource.Token;
        }

        public string GetFileName()
        {
            return this.FileName;
        }

        public string GetFullFileName()
        {
            return this.FileName;
        }

        public string GetFilePath()
        {
            return this.Path;
        }

        public string GetFileExtension()
        {
            return this.Extension;
        }

        public void CancelConvert()
        {
            cancellationSource.Cancel();
        }

        public async void ConvertTo(AudioFormat format, string outputDir)
        {
            MediaFile inputFile = new MediaFile(this.Path);
            MediaFile outputFile = new MediaFile($"{outputDir}\\{this.FileName}.{format.ToString()}");
            Engine ffmpeg;

            try
            {
                ffmpeg = new Engine(Directory.GetCurrentDirectory() + "\\ffmpeg.exe");
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessage(ex.Message, "Error");
                return;
            }

            ffmpeg.Progress += (object sender, ConversionProgressEventArgs e) =>
            {
                OnProgressChange((int)Math.Clamp(Math.Round(e.ProcessedDuration / e.TotalDuration) * 100, 0, 100));
            };

            ffmpeg.Error += (object sender, ConversionErrorEventArgs e) =>
            {
                OnProgressError(e.Exception.Message);
            };

            ffmpeg.Complete += (object sender, ConversionCompleteEventArgs e) =>
            {
                OnProgressComplete();
            };

            if (format == AudioFormat.m4a)
            {
                ConversionOptions options = new ConversionOptions();
                options.ExtraArguments = "-vn";
                await ffmpeg.ConvertAsync(inputFile, outputFile, options, cancellationToken);
            }
            else
            {
                await ffmpeg.ConvertAsync(inputFile, outputFile, cancellationToken);
            }

        }
    }
}
