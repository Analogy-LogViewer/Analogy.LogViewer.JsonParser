using Analogy.DataProviders.Extensions;

namespace Analogy.LogViewer.JsonParser
{
    partial class JsonParserSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExportSettings = new System.Windows.Forms.Button();
            this.lblLayout = new System.Windows.Forms.Label();
            this.btnLoadLayout = new System.Windows.Forms.Button();
            this.txtNLogLayout = new System.Windows.Forms.TextBox();
            this.txtNLogExtension = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtbNLogDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.txtbJsonKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPredefined = new System.Windows.Forms.GroupBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlButtom = new System.Windows.Forms.Panel();
            this.gbPredefined.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(643, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSettings.Location = new System.Drawing.Point(524, 7);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(114, 40);
            this.btnExportSettings.TabIndex = 2;
            this.btnExportSettings.Text = "Export Settings";
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            // 
            // lblLayout
            // 
            this.lblLayout.AutoSize = true;
            this.lblLayout.Location = new System.Drawing.Point(12, 8);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(84, 17);
            this.lblLayout.TabIndex = 3;
            this.lblLayout.Text = "Sample Log:";
            // 
            // btnLoadLayout
            // 
            this.btnLoadLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadLayout.Location = new System.Drawing.Point(637, 31);
            this.btnLoadLayout.Name = "btnLoadLayout";
            this.btnLoadLayout.Size = new System.Drawing.Size(114, 25);
            this.btnLoadLayout.TabIndex = 4;
            this.btnLoadLayout.Text = "Apply layout";
            this.btnLoadLayout.UseVisualStyleBackColor = true;
            this.btnLoadLayout.Click += new System.EventHandler(this.btnLoadLayout_Click);
            // 
            // txtNLogLayout
            // 
            this.txtNLogLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNLogLayout.Location = new System.Drawing.Point(140, 6);
            this.txtNLogLayout.Name = "txtNLogLayout";
            this.txtNLogLayout.Size = new System.Drawing.Size(486, 23);
            this.txtNLogLayout.TabIndex = 5;
            // 
            // txtNLogExtension
            // 
            this.txtNLogExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNLogExtension.Location = new System.Drawing.Point(140, 60);
            this.txtNLogExtension.Name = "txtNLogExtension";
            this.txtNLogExtension.Size = new System.Drawing.Size(486, 23);
            this.txtNLogExtension.TabIndex = 9;
            this.txtNLogExtension.Text = "*.Json";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "File Extension:";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(637, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(114, 25);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Import settings";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtbNLogDirectory
            // 
            this.txtbNLogDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbNLogDirectory.Location = new System.Drawing.Point(140, 33);
            this.txtbNLogDirectory.Name = "txtbNLogDirectory";
            this.txtbNLogDirectory.Size = new System.Drawing.Size(451, 23);
            this.txtbNLogDirectory.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Logs Location";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(601, 31);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(28, 25);
            this.btnOpenFolder.TabIndex = 13;
            this.btnOpenFolder.Text = "..";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnAddKey
            // 
            this.btnAddKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddKey.Location = new System.Drawing.Point(585, 16);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(169, 25);
            this.btnAddKey.TabIndex = 16;
            this.btnAddKey.Text = "Add and map below";
            this.btnAddKey.UseVisualStyleBackColor = true;
            // 
            // txtbJsonKey
            // 
            this.txtbJsonKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbJsonKey.Location = new System.Drawing.Point(240, 16);
            this.txtbJsonKey.Name = "txtbJsonKey";
            this.txtbJsonKey.Size = new System.Drawing.Size(339, 23);
            this.txtbJsonKey.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "column name/key in your Json File :";
            // 
            // gbPredefined
            // 
            this.gbPredefined.Controls.Add(this.label1);
            this.gbPredefined.Controls.Add(this.btnAddKey);
            this.gbPredefined.Controls.Add(this.txtbJsonKey);
            this.gbPredefined.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPredefined.Location = new System.Drawing.Point(0, 105);
            this.gbPredefined.Name = "gbPredefined";
            this.gbPredefined.Size = new System.Drawing.Size(760, 351);
            this.gbPredefined.TabIndex = 17;
            this.gbPredefined.TabStop = false;
            this.gbPredefined.Text = "Pre defined Columns";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblLayout);
            this.pnlTop.Controls.Add(this.btnLoadLayout);
            this.pnlTop.Controls.Add(this.btnOpenFolder);
            this.pnlTop.Controls.Add(this.txtNLogLayout);
            this.pnlTop.Controls.Add(this.txtbNLogDirectory);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.txtNLogExtension);
            this.pnlTop.Controls.Add(this.btnImport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(760, 105);
            this.pnlTop.TabIndex = 18;
            // 
            // pnlButtom
            // 
            this.pnlButtom.Controls.Add(this.btnSave);
            this.pnlButtom.Controls.Add(this.btnExportSettings);
            this.pnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtom.Location = new System.Drawing.Point(0, 456);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(760, 50);
            this.pnlButtom.TabIndex = 19;
            // 
            // JsonParserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPredefined);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "JsonParserSettings";
            this.Size = new System.Drawing.Size(760, 506);
            this.Load += new System.EventHandler(this.NLogSettings_Load);
            this.gbPredefined.ResumeLayout(false);
            this.gbPredefined.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AnalogyColumnsMatcherUC analogyColumnsMatcherUC1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExportSettings;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.Button btnLoadLayout;
        private System.Windows.Forms.TextBox txtNLogLayout;
        private System.Windows.Forms.TextBox txtNLogExtension;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtbNLogDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.TextBox txtbJsonKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbPredefined;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlButtom;
    }
}
