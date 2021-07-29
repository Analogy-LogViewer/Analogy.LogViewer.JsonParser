
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
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtnReset);
            this.groupBox1.Controls.Add(this.rbtnJsonFile);
            this.groupBox1.Controls.Add(this.rbtnJsonPerLine);
            this.groupBox1.Location = new System.Drawing.Point(3, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 95);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format:";
            // 
            // rbtnReset
            // 
            this.rbtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnReset.AutoSize = true;
            this.rbtnReset.Location = new System.Drawing.Point(583, 26);
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
            this.btnSave.Location = new System.Drawing.Point(602, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 47);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // JsonSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbDetectionModeManual);
            this.Controls.Add(this.rbDetectionModeAutomatic);
            this.Controls.Add(this.label1);
            this.Name = "JsonSettingsUC";
            this.Size = new System.Drawing.Size(744, 473);
            this.Load += new System.EventHandler(this.JsonSettingsUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}
