using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.NLogProvider.Properties;

namespace Analogy.LogViewer.NLogProvider
{

    public class JsonParserFactory : IAnalogyFactory
    {
        public static Guid AnalogyNLogGuid { get; } = new Guid("38DE52E6-AB82-48CC-B3D3-BC0E4880AAEE");
        public Guid FactoryID { get; } = AnalogyNLogGuid;
        public string Title { get; } = "Analogy Json Parser";
        public IAnalogyDataProvidersFactory DataProviders { get; }
        public IAnalogyCustomActionsFactory Actions { get; }
        public IEnumerable<IAnalogyChangeLog> ChangeLog => NLogProvider.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Json Parser";
        public JsonParserFactory()
        {
            DataProviders = new AnalogyNLogDataProviderFactory();
            Actions = new AnalogyNLogCustomActionFactory();

        }


    }

    public class AnalogyNLogDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy Json Parser";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public AnalogyNLogDataProviderFactory()
        {
            var builtInItems = new List<IAnalogyDataProvider>();
            var adpnlog = new JsonParserNLogDataProvider(UserSettingsManager.UserSettings.LogParserSettings);
            builtInItems.Add(adpnlog);
            Items = builtInItems;
        }
    }

    public class AnalogyNLogCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public string Title { get; } = "Analogy Json Built-In tools";
        public IEnumerable<IAnalogyCustomAction> Items { get; }

        public AnalogyNLogCustomActionFactory()
        {
            Items = new List<IAnalogyCustomAction>(0);
        }
    }

    public class AnalogyJsonParserSettings : IAnalogyDataProviderSettings
    {

        public Guid ID { get; } = new Guid("681E2633-9E5B-4421-BA06-A906431B6457");

        public string Title { get; } = "Json Parser Settings";
        public UserControl DataProviderSettings { get; } = new JsonParserSettings();
        public Image Icon { get; } = Resources.nlog;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}
