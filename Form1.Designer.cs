namespace Springer
{
    partial class springer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(springer));
            this.gbStore = new System.Windows.Forms.GroupBox();
            this.cbSameDir = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbChooseGroup = new System.Windows.Forms.CheckBox();
            this.txtStore = new System.Windows.Forms.RichTextBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.ofdChooseGroup = new System.Windows.Forms.OpenFileDialog();
            this.gbDevices = new System.Windows.Forms.GroupBox();
            this.tlpTxt = new System.Windows.Forms.TableLayoutPanel();
            this.flpCheckboxes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblApp = new System.Windows.Forms.Label();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.pbApp = new System.Windows.Forms.PictureBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.gbStore.SuspendLayout();
            this.gbDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbApp)).BeginInit();
            this.SuspendLayout();
            // 
            // gbStore
            // 
            this.gbStore.Controls.Add(this.cbSameDir);
            this.gbStore.Controls.Add(this.btnBrowse);
            this.gbStore.Controls.Add(this.cbChooseGroup);
            this.gbStore.Controls.Add(this.txtStore);
            this.gbStore.Controls.Add(this.lblStore);
            this.gbStore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStore.Location = new System.Drawing.Point(12, 116);
            this.gbStore.Name = "gbStore";
            this.gbStore.Size = new System.Drawing.Size(775, 124);
            this.gbStore.TabIndex = 0;
            this.gbStore.TabStop = false;
            this.gbStore.Text = "Select Store/Stores";
            // 
            // cbSameDir
            // 
            this.cbSameDir.AutoSize = true;
            this.cbSameDir.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSameDir.Location = new System.Drawing.Point(168, 31);
            this.cbSameDir.Name = "cbSameDir";
            this.cbSameDir.Size = new System.Drawing.Size(206, 23);
            this.cbSameDir.TabIndex = 3;
            this.cbSameDir.Text = "Same directory (node.txt)";
            this.cbSameDir.UseVisualStyleBackColor = true;
            this.cbSameDir.CheckedChanged += new System.EventHandler(this.cbSameDir_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(626, 59);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(121, 39);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbChooseGroup
            // 
            this.cbChooseGroup.AutoSize = true;
            this.cbChooseGroup.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChooseGroup.Location = new System.Drawing.Point(10, 31);
            this.cbChooseGroup.Name = "cbChooseGroup";
            this.cbChooseGroup.Size = new System.Drawing.Size(130, 23);
            this.cbChooseGroup.TabIndex = 1;
            this.cbChooseGroup.Text = "Choose Group";
            this.cbChooseGroup.UseVisualStyleBackColor = true;
            this.cbChooseGroup.CheckedChanged += new System.EventHandler(this.cbChooseGroup_CheckedChanged);
            // 
            // txtStore
            // 
            this.txtStore.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(168, 66);
            this.txtStore.Name = "txtStore";
            this.txtStore.Size = new System.Drawing.Size(410, 30);
            this.txtStore.TabIndex = 1;
            this.txtStore.Text = "";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(6, 69);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(100, 19);
            this.lblStore.TabIndex = 0;
            this.lblStore.Text = "Store/Stores:";
            // 
            // ofdChooseGroup
            // 
            this.ofdChooseGroup.FileName = "ofdChooseGroup";
            // 
            // gbDevices
            // 
            this.gbDevices.Controls.Add(this.tlpTxt);
            this.gbDevices.Controls.Add(this.flpCheckboxes);
            this.gbDevices.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDevices.Location = new System.Drawing.Point(12, 246);
            this.gbDevices.Name = "gbDevices";
            this.gbDevices.Size = new System.Drawing.Size(775, 284);
            this.gbDevices.TabIndex = 1;
            this.gbDevices.TabStop = false;
            this.gbDevices.Text = "Devices";
            // 
            // tlpTxt
            // 
            this.tlpTxt.ColumnCount = 6;
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tlpTxt.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpTxt.Location = new System.Drawing.Point(6, 76);
            this.tlpTxt.Name = "tlpTxt";
            this.tlpTxt.RowCount = 3;
            this.tlpTxt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTxt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTxt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTxt.Size = new System.Drawing.Size(763, 199);
            this.tlpTxt.TabIndex = 5;
            // 
            // flpCheckboxes
            // 
            this.flpCheckboxes.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpCheckboxes.Location = new System.Drawing.Point(6, 29);
            this.flpCheckboxes.Name = "flpCheckboxes";
            this.flpCheckboxes.Size = new System.Drawing.Size(763, 41);
            this.flpCheckboxes.TabIndex = 4;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApp.Location = new System.Drawing.Point(100, 16);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(99, 25);
            this.lblApp.TabIndex = 4;
            this.lblApp.Text = "Springer";
            // 
            // lblSlogan
            // 
            this.lblSlogan.AutoSize = true;
            this.lblSlogan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan.Location = new System.Drawing.Point(101, 51);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(175, 19);
            this.lblSlogan.TabIndex = 5;
            this.lblSlogan.Text = "Get closer to the store";
            // 
            // pbApp
            // 
            this.pbApp.Image = global::Springer.Properties.Resources.flowers__2_;
            this.pbApp.Location = new System.Drawing.Point(12, 12);
            this.pbApp.Name = "pbApp";
            this.pbApp.Size = new System.Drawing.Size(82, 78);
            this.pbApp.TabIndex = 3;
            this.pbApp.TabStop = false;
            // 
            // btnSetting
            // 
            this.btnSetting.Image = global::Springer.Properties.Resources.mechanical_gears___1_;
            this.btnSetting.Location = new System.Drawing.Point(726, 17);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(61, 57);
            this.btnSetting.TabIndex = 2;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnClearForm
            // 
            this.btnClearForm.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearForm.Location = new System.Drawing.Point(253, 536);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(106, 38);
            this.btnClearForm.TabIndex = 6;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnPing
            // 
            this.btnPing.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPing.Location = new System.Drawing.Point(434, 536);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(106, 38);
            this.btnPing.TabIndex = 7;
            this.btnPing.Text = "Start Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // springer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 586);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.lblSlogan);
            this.Controls.Add(this.lblApp);
            this.Controls.Add(this.pbApp);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.gbDevices);
            this.Controls.Add(this.gbStore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "springer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Springer";
            this.gbStore.ResumeLayout(false);
            this.gbStore.PerformLayout();
            this.gbDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.RichTextBox txtStore;
        private System.Windows.Forms.CheckBox cbChooseGroup;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdChooseGroup;
        private System.Windows.Forms.GroupBox gbDevices;
        private System.Windows.Forms.FlowLayoutPanel flpCheckboxes;
        private System.Windows.Forms.TableLayoutPanel tlpTxt;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.PictureBox pbApp;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.CheckBox cbSameDir;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnPing;
    }
}

