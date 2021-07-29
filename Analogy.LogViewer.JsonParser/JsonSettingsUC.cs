using Analogy.LogViewer.JsonParser.Managers;
using System;
using System.Windows.Forms;

namespace Analogy.LogViewer.JsonParser
{
    public partial class JsonSettingsUC : UserControl
    {
        private JsonSettings Settings => UserSettingsManager.UserSettings.Settings;

        public JsonSettingsUC()
        {
            InitializeComponent();
        }

        private void JsonSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
        private void LoadSettings()
        {
            rbtnJsonPerLine.Checked = Settings.Format == FileFormat.JsonFormatPerLine;
            rbtnJsonFile.Checked = Settings.Format == FileFormat.JsonFormatFile;
            rbtnReset.Checked = Settings.Format == FileFormat.Unknown;
            rbDetectionModeAutomatic.Checked = Settings.FileFormatDetection == FileFormatDetection.Automatic;
            rbDetectionModeManual.Checked = Settings.FileFormatDetection == FileFormatDetection.Manual;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();

        }

        public void SaveSettings()
        {

            Settings.FileFormatDetection = rbDetectionModeAutomatic.Checked
                ? FileFormatDetection.Automatic
                : FileFormatDetection.Manual;
            if (rbtnReset.Checked)
            {
                Settings.Format = FileFormat.Unknown;
            }
            else if (rbtnJsonPerLine.Checked)
            {
                Settings.Format = FileFormat.JsonFormatPerLine;
            }
            else if (rbtnJsonFile.Checked)
            {
                Settings.Format = FileFormat.JsonFormatFile;
            }
            UserSettingsManager.UserSettings.Save();
        }

    }
}
