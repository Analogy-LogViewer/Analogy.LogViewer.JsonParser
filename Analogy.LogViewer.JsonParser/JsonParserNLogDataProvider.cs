using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Newtonsoft.Json;

namespace Analogy.LogViewer.NLogProvider
{
    public class JsonParserNLogDataProvider : IAnalogyOfflineDataProvider
    {
        public string OptionalTitle { get; } = "Analogy Built-In Json Parser";

        public Guid ID { get; } = new Guid("B636700C-7465-45DC-A657-24014A7D667F");

        public bool CanSaveToLogFile { get; } = false;
        public string FileOpenDialogFilters { get; } = "Json files (*.json)|*.json";
        public string FileSaveDialogFilters { get; } = string.Empty;
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.json" };

        public string InitialFolderFullPath => Directory.Exists(UserSettings?.Directory)
            ? UserSettings.Directory
            : Environment.CurrentDirectory;
        public JsonFileLoader nLogFileParser { get; set; }

        private ILogParserSettings UserSettings { get; set; }
        public JsonParserNLogDataProvider(ILogParserSettings userSettings)
        {
            UserSettings = userSettings;
        }
        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            nLogFileParser = new JsonFileLoader(UserSettingsManager.UserSettings.LogParserSettings);
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }
        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
                return await nLogFileParser.Process(fileName, token, messagesHandler);
            return new List<AnalogyLogMessage>(0);

        }

        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
            => GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            throw new NotSupportedException("Saving is not supported for Json");
        }

        public bool CanOpenFile(string fileName) => UserSettingsManager.UserSettings.LogParserSettings.CanOpenFile(fileName);

        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        public static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.json")
                .ToList();
            if (!recursive)
                return files;
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
