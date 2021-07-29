using Analogy.LogViewer.JsonParser.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.JsonParser.IAnalogy
{
    public class JsonUserSettingsFactory : Analogy.LogViewer.Template.UserSettingsFactory
    {
        public override string Title { get; set; } = "Serilog User Settings";
        public override UserControl DataProviderSettings { get; set; } = new JsonSettingsUC();
        public override Image SmallImage { get; set; } = Resources.jsonfile16x16;
        public override Image LargeImage { get; set; } = Resources.jsonfile32x32;
        public override Guid FactoryId { get; set; } = JsonFactory.Id;
        public override Guid Id { get; set; } = new Guid("f5cdfa1e-0853-4269-b8be-acfdd6069f2a");

        public override Task SaveSettingsAsync()
        {
            ((JsonSettingsUC)DataProviderSettings)?.SaveSettings();
            return Task.CompletedTask;
        }
    }


}
