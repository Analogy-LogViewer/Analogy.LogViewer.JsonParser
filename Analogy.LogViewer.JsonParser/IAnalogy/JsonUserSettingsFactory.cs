using Analogy.Interfaces;
using Analogy.LogViewer.JsonParser.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonUserSettingsFactory : Template.TemplateUserSettingsFactoryWinForms
    {
        public override string Title { get; set; } = "Json User Settings";
        public override UserControl DataProviderSettings { get; set; }
        public override Image SmallImage { get; set; } = Resources.jsonfile16x16;
        public override Image LargeImage { get; set; } = Resources.jsonfile32x32;
        public override Guid FactoryId { get; set; } = JsonFactory.Id;
        public override Guid Id { get; set; } = new Guid("f5cdfa1e-0853-4269-b8be-acfdd6069f2a");

        public override void CreateUserControl(ILogger logger)
        {
            DataProviderSettings = new JsonSettingsUC();
        }

        public override Task SaveSettingsAsync()
        {
            ((JsonSettingsUC)DataProviderSettings)?.SaveSettings();
            return Task.CompletedTask;
        }
    }
}