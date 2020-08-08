using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.LogViewer.JsonParser.Managers;

namespace Analogy.LogViewer.JsonParser
{
    public partial class JsonColumnsMatcherUC : UserControl
    {
        public Dictionary<string, AnalogyLogMessagePropertyName> Mapping => GetMapping();
        public JsonColumnsMatcherUC()
        {
            InitializeComponent();
        }


        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex <= 0) return;
            var selectedIndex = lstBAnalogyColumns.SelectedIndex;
            var currentValue = lstBAnalogyColumns.Items[selectedIndex];
            lstBAnalogyColumns.Items[selectedIndex] = lstBAnalogyColumns.Items[selectedIndex - 1];
            lstBAnalogyColumns.Items[selectedIndex - 1] = currentValue;
            lstBAnalogyColumns.SelectedIndex = lstBAnalogyColumns.SelectedIndex - 1;
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex == lstBAnalogyColumns.Items.Count - 1) return;
            var selectedIndex = lstBAnalogyColumns.SelectedIndex;
            var currentValue = lstBAnalogyColumns.Items[selectedIndex + 1];
            lstBAnalogyColumns.Items[selectedIndex + 1] = lstBAnalogyColumns.Items[selectedIndex];
            lstBAnalogyColumns.Items[selectedIndex] = currentValue;
            lstBAnalogyColumns.SelectedIndex = lstBAnalogyColumns.SelectedIndex + 1;
        }

        private void lstBAnalogyColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstBAnalogyColumns.SelectedIndex > lstBoxItems.Items.Count - 1) return;
            lstBoxItems.SelectedIndex = lstBAnalogyColumns.SelectedIndex;


        }

        public void SetColumns(string[] columns)
        {
            lstBoxItems.Items.Clear();
            lstBoxItems.Items.AddRange(columns);
        }

        public void AddKey(string key) => lstBoxItems.Items.Add(key);
        public void LoadMapping(ILogParserSettings parser)
        {
            lstBoxItems.Items.Clear();
            lstBoxItems.Items.AddRange(parser.Maps.Keys.ToArray());

        }
        private Dictionary<string, AnalogyLogMessagePropertyName> GetMapping()
        {
            int minimum = Math.Min(lstBoxItems.Items.Count, lstBAnalogyColumns.Items.Count);
            var maps = new Dictionary<string, AnalogyLogMessagePropertyName>(minimum);
            for (int i = 0; i < minimum; i++)
            {
                maps.Add(lstBoxItems.Items[i].ToString(), (AnalogyLogMessagePropertyName)Enum.Parse(typeof(AnalogyLogMessagePropertyName), lstBAnalogyColumns.Items[i].ToString()));
            }

            return maps;
        }

        private void AnalogyColumnsMatcherUC_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            lstBAnalogyColumns.Items.Clear();
            lstBAnalogyColumns.Items.AddRange(AnalogyLogMessage.AnalogyLogMessagePropertyNames.Keys.ToArray());
            LoadMapping(UserSettingsManager.UserSettings.LogParserSettings);
        }
    }
}
