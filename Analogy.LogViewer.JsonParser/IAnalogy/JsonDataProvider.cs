using Analogy.Interfaces;
using Analogy.LogViewer.JsonParser.Managers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonDataProvider : Template.OfflineDataProvider
    {
        public override string OptionalTitle { get; set; } = "Analogy Json Parser";

        public override Guid Id { get; set; } = new Guid("6751686B-DF5D-433A-9EA0-664F4ED13B1E");
        public override Image? LargeImage { get; set; }
        public override Image? SmallImage { get; set; }
        public override bool CanSaveToLogFile { get; set; }
        public override string FileOpenDialogFilters { get; set; } = "Json log files|*.json";
        public override string FileSaveDialogFilters { get; set; } = string.Empty;
        public override IEnumerable<string> SupportFormats { get; set; } = new[] { "*.json" };

        public override string InitialFolderFullPath => Environment.CurrentDirectory;
        public override bool DisableFilePoolingOption { get; set; }
        public JsonFileLoader JsonParser { get; set; }

        public override bool UseCustomColors { get; set; }
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public JsonDataProvider()
        {
        }
        public override Task InitializeDataProvider(ILogger logger)
        {
            JsonParser = new JsonFileLoader(UserSettingsManager.UserSettings.Settings);
            return base.InitializeDataProvider(logger);
        }

        public override void MessageOpened(IAnalogyLogMessage message)
        {
            //nop
        }
        public override async Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                if (UserSettingsManager.UserSettings.Settings.FileFormatDetection == FileFormatDetection.Automatic ||
                    UserSettingsManager.UserSettings.Settings.Format == FileFormat.Unknown)
                {
                    UserSettingsManager.UserSettings.Settings.Format = TryDetectFormat(fileName);
                }


                return await JsonParser.Process(fileName, token, messagesHandler);
            }

            return new List<AnalogyLogMessage>(0);

        }


        private static FileFormat TryDetectFormat(string fileName)
        {
            string jsonData = string.Empty;
            if (fileName.EndsWith(".gz", StringComparison.InvariantCultureIgnoreCase))
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var gzStream = new GZipStream(fileStream, CompressionMode.Decompress))
                    {
                        using (var streamReader = new StreamReader(gzStream, encoding: Encoding.UTF8))
                        {
                            jsonData = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(jsonData))
            {
                jsonData = SafeReadAllLines(fileName);
            }

            var format = TryParseAsFile(jsonData);
            if (format == FileFormat.Unknown)
            {
                format = TryParsePerLine(fileName);
            }

            return format;
        }
        private static FileFormat TryParsePerLine(string fileName)
        {
            try
            {

                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    try
                    {
                        _ = JsonConvert.DeserializeObject(line);
                    }
                    catch (Exception)
                    {
                        return FileFormat.Unknown;
                    }
                }

                return FileFormat.JsonFormatPerLine;
            }
            catch (Exception)
            {
                return FileFormat.Unknown;
            }
        }

        private static FileFormat TryParseAsFile(string jsonData)
        {
            try
            {
                _ = JsonConvert.DeserializeObject(jsonData);
                return FileFormat.JsonFormatFile;
            }
            catch (Exception)
            {
                return FileFormat.Unknown;
            }
        }

        private static string SafeReadAllLines(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(stream))
            {
                string data = sr.ReadToEnd();
                return data;
            }
        }


        public override Task SaveAsync(List<IAnalogyLogMessage> messages, string fileName)
        {
            return Task.CompletedTask;
        }

        public override bool CanOpenFile(string fileName) => Path.GetExtension(fileName)
            .EndsWith("json", StringComparison.InvariantCultureIgnoreCase);

        public override bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        protected override List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {

            List<FileInfo> files = dirInfo.GetFiles("*.json")
                .Where(f => CanOpenFile(f.FullName)).ToList();
            if (!recursive)
            {
                return files;
            }

            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFilesInternal(dir, true));
                }
            }
            catch (Exception)
            {
                return files;
            }

            return files;
        }
    }
}
