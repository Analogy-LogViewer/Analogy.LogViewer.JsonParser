using Analogy.Interfaces;
using Analogy.LogViewer.JsonParser.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonDataProvider : Template.OfflineDataProvider
    {
        public override string OptionalTitle { get; set; } = "Analogy Json Parser";

        public override Guid Id { get; set; } = new Guid("6751686B-DF5D-433A-9EA0-664F4ED13B1E");
        public override Image? LargeImage { get; set; } = null;
        public override Image? SmallImage { get; set; } = null;
        public override bool CanSaveToLogFile { get; set; } = false;
        public override string FileOpenDialogFilters { get; set; } = "Json log files|*.json";
        public override string FileSaveDialogFilters { get; set; } = string.Empty;
        public override IEnumerable<string> SupportFormats { get; set; } = new[] { "*.json" };

        public override string InitialFolderFullPath => Directory.Exists(UserSettings?.Directory)
            ? UserSettings.Directory
            : Environment.CurrentDirectory;
        public override bool DisableFilePoolingOption { get; set; } = false;
        public JsonFileLoader JsonParser { get; set; }

        private ILogParserSettings UserSettings { get; set; }
        public override bool UseCustomColors { get; set; } = false;
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public JsonDataProvider(ILogParserSettings userSettings)
        {
            UserSettings = userSettings;
        }
        public override Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            JsonParser = new JsonFileLoader(UserSettingsManager.UserSettings.LogParserSettings);
            return base.InitializeDataProviderAsync(logger);
        }

        public override void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }
        public override async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                return await JsonParser.Process(fileName, token, messagesHandler);
            }

            return new List<AnalogyLogMessage>(0);

        }


        public override Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            return Task.CompletedTask;
        }

        public override bool CanOpenFile(string fileName) => UserSettingsManager.UserSettings.LogParserSettings.CanOpenFile(fileName);

        public override bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        protected override List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {

            List<FileInfo> files = dirInfo.GetFiles("*.json")
                .Where(f => UserSettings.CanOpenFile(f.FullName)).ToList();
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
