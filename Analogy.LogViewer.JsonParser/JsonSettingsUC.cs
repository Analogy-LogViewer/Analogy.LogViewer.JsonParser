using Analogy.Interfaces;
using Analogy.LogViewer.JsonParser.Managers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.LogViewer.JsonParser
{
    public partial class JsonSettingsUC : UserControl
    {
        private JsonSettings Settings => UserSettingsManager.UserSettings.Settings;
        private AnalogyLogMessagePropertyName SelectedField { get; set; }
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
            lstbAnalogy.DataSource = AnalogyLogMessage.LogMessagePropertyNames.Values.ToList();
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

        private void lstbAnalogy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedField = (AnalogyLogMessagePropertyName)lstbAnalogy.SelectedItem;
            btnAddField.Enabled = true;
            lblSelectedField.Text = $@"Analogy Message Field: {SelectedField}";
            lstMapped.DataSource = null;
            lstMapped.DataSource = Settings.GetValues(SelectedField);
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewField.Text))
            {
                Settings.AddField(SelectedField, txtNewField.Text);
                lstMapped.DataSource = null;
                lstMapped.DataSource = Settings.GetValues(SelectedField);
            }
        }

        private void lstMapped_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelectedValue.Text = $@"Selected Value: {lstMapped.SelectedItem}";
            btnDeleteField.Enabled = true;
        }

        private void btnDeleteField_Click(object sender, EventArgs e)
        {
            if (lstMapped.SelectedItem is string value)
            {
                Settings.DeleteField(SelectedField, value);
                lstMapped.DataSource = null;
                lstMapped.DataSource = Settings.GetValues(SelectedField);
            }
        }
    }
}
