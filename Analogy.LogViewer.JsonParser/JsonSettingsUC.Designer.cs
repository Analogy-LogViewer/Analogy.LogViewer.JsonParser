
namespace Analogy.LogViewer.JsonParser
{
    partial class JsonSettingsUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbDetectionModeManual = new System.Windows.Forms.RadioButton();
            this.rbDetectionModeAutomatic = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnReset = new System.Windows.Forms.RadioButton();
            this.rbtnJsonFile = new System.Windows.Forms.RadioButton();
            this.rbtnJsonPerLine = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstbAnalogy = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNewField = new System.Windows.Forms.TextBox();
            this.lblSelectedValue = new System.Windows.Forms.Label();
            this.lstMapped = new System.Windows.Forms.ListBox();
            this.lblSelectedField = new System.Windows.Forms.Label();
            this.btnDeleteField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDetectionModeManual
            // 
            this.rbDetectionModeManual.AutoSize = true;
            this.rbDetectionModeManual.Location = new System.Drawing.Point(437, 16);
            this.rbDetectionModeManual.Name = "rbDetectionModeManual";
            this.rbDetectionModeManual.Size = new System.Drawing.Size(79, 24);
            this.rbDetectionModeManual.TabIndex = 56;
            this.rbDetectionModeManual.Text = "Manual";
            this.rbDetectionModeManual.UseVisualStyleBackColor = true;
            // 
            // rbDetectionModeAutomatic
            // 
            this.rbDetectionModeAutomatic.AutoSize = true;
            this.rbDetectionModeAutomatic.Checked = true;
            this.rbDetectionModeAutomatic.Location = new System.Drawing.Point(266, 16);
            this.rbDetectionModeAutomatic.Name = "rbDetectionModeAutomatic";
            this.rbDetectionModeAutomatic.Size = new System.Drawing.Size(99, 24);
            this.rbDetectionModeAutomatic.TabIndex = 55;
            this.rbDetectionModeAutomatic.TabStop = true;
            this.rbDetectionModeAutomatic.Text = "Automatic";
            this.rbDetectionModeAutomatic.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "File Detection Mode:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtnReset);
            this.groupBox1.Controls.Add(this.rbtnJsonFile);
            this.groupBox1.Controls.Add(this.rbtnJsonPerLine);
            this.groupBox1.Location = new System.Drawing.Point(3, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(841, 89);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format:";
            // 
            // rbtnReset
            // 
            this.rbtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnReset.AutoSize = true;
            this.rbtnReset.Location = new System.Drawing.Point(686, 26);
            this.rbtnReset.Name = "rbtnReset";
            this.rbtnReset.Size = new System.Drawing.Size(149, 24);
            this.rbtnReset.TabIndex = 52;
            this.rbtnReset.Text = "Reset to Unknown";
            this.rbtnReset.UseVisualStyleBackColor = true;
            // 
            // rbtnJsonFile
            // 
            this.rbtnJsonFile.AutoSize = true;
            this.rbtnJsonFile.Location = new System.Drawing.Point(6, 56);
            this.rbtnJsonFile.Name = "rbtnJsonFile";
            this.rbtnJsonFile.Size = new System.Drawing.Size(271, 24);
            this.rbtnJsonFile.TabIndex = 51;
            this.rbtnJsonFile.Text = "File is one json object (array are log)";
            this.rbtnJsonFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.rbtnJsonFile.UseVisualStyleBackColor = true;
            // 
            // rbtnJsonPerLine
            // 
            this.rbtnJsonPerLine.AutoSize = true;
            this.rbtnJsonPerLine.Location = new System.Drawing.Point(6, 26);
            this.rbtnJsonPerLine.Name = "rbtnJsonPerLine";
            this.rbtnJsonPerLine.Size = new System.Drawing.Size(191, 24);
            this.rbtnJsonPerLine.TabIndex = 15;
            this.rbtnJsonPerLine.Text = "Json Object per line/row";
            this.rbtnJsonPerLine.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(711, 542);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 47);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstbAnalogy
            // 
            this.lstbAnalogy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstbAnalogy.FormattingEnabled = true;
            this.lstbAnalogy.ItemHeight = 20;
            this.lstbAnalogy.Location = new System.Drawing.Point(3, 23);
            this.lstbAnalogy.Name = "lstbAnalogy";
            this.lstbAnalogy.Size = new System.Drawing.Size(194, 365);
            this.lstbAnalogy.TabIndex = 59;
            this.lstbAnalogy.SelectedIndexChanged += new System.EventHandler(this.lstbAnalogy_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtNewField);
            this.groupBox2.Controls.Add(this.lblSelectedValue);
            this.groupBox2.Controls.Add(this.lstMapped);
            this.groupBox2.Controls.Add(this.lblSelectedField);
            this.groupBox2.Controls.Add(this.btnDeleteField);
            this.groupBox2.Controls.Add(this.btnAddField);
            this.groupBox2.Controls.Add(this.lstbAnalogy);
            this.groupBox2.Location = new System.Drawing.Point(3, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(841, 391);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Json Fields Mapping";
            // 
            // txtNewField
            // 
            this.txtNewField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewField.Location = new System.Drawing.Point(206, 50);
            this.txtNewField.Name = "txtNewField";
            this.txtNewField.Size = new System.Drawing.Size(485, 27);
            this.txtNewField.TabIndex = 65;
            // 
            // lblSelectedValue
            // 
            this.lblSelectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedValue.AutoEllipsis = true;
            this.lblSelectedValue.Location = new System.Drawing.Point(206, 348);
            this.lblSelectedValue.Name = "lblSelectedValue";
            this.lblSelectedValue.Size = new System.Drawing.Size(488, 22);
            this.lblSelectedValue.TabIndex = 64;
            this.lblSelectedValue.Text = "Selected Value:";
            // 
            // lstMapped
            // 
            this.lstMapped.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMapped.FormattingEnabled = true;
            this.lstMapped.ItemHeight = 20;
            this.lstMapped.Location = new System.Drawing.Point(203, 81);
            this.lstMapped.Name = "lstMapped";
            this.lstMapped.Size = new System.Drawing.Size(632, 224);
            this.lstMapped.TabIndex = 63;
            this.lstMapped.SelectedIndexChanged += new System.EventHandler(this.lstMapped_SelectedIndexChanged);
            // 
            // lblSelectedField
            // 
            this.lblSelectedField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedField.AutoEllipsis = true;
            this.lblSelectedField.Location = new System.Drawing.Point(205, 24);
            this.lblSelectedField.Name = "lblSelectedField";
            this.lblSelectedField.Size = new System.Drawing.Size(488, 22);
            this.lblSelectedField.TabIndex = 62;
            this.lblSelectedField.Text = "Analogy Message Field:";
            // 
            // btnDeleteField
            // 
            this.btnDeleteField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteField.Enabled = false;
            this.btnDeleteField.Location = new System.Drawing.Point(700, 334);
            this.btnDeleteField.Name = "btnDeleteField";
            this.btnDeleteField.Size = new System.Drawing.Size(133, 47);
            this.btnDeleteField.TabIndex = 61;
            this.btnDeleteField.Text = "Delete Field";
            this.btnDeleteField.UseVisualStyleBackColor = true;
            this.btnDeleteField.Click += new System.EventHandler(this.btnDeleteField_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddField.Enabled = false;
            this.btnAddField.Location = new System.Drawing.Point(702, 48);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(133, 30);
            this.btnAddField.TabIndex = 60;
            this.btnAddField.Text = "Add Field";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // JsonSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbDetectionModeManual);
            this.Controls.Add(this.rbDetectionModeAutomatic);
            this.Controls.Add(this.label1);
            this.Name = "JsonSettingsUC";
            this.Size = new System.Drawing.Size(853, 592);
            this.Load += new System.EventHandler(this.JsonSettingsUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDetectionModeManual;
        private System.Windows.Forms.RadioButton rbDetectionModeAutomatic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnReset;
        private System.Windows.Forms.RadioButton rbtnJsonFile;
        private System.Windows.Forms.RadioButton rbtnJsonPerLine;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstbAnalogy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnDeleteField;
        private System.Windows.Forms.ListBox lstMapped;
        private System.Windows.Forms.Label lblSelectedField;
        private System.Windows.Forms.Label lblSelectedValue;
        private System.Windows.Forms.TextBox txtNewField;
    }
}
