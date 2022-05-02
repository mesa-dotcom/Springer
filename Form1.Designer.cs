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
            this.gbStore = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbChooseGroup = new System.Windows.Forms.CheckBox();
            this.txtStore = new System.Windows.Forms.RichTextBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.ofdChooseGroup = new System.Windows.Forms.OpenFileDialog();
            this.gbDevices = new System.Windows.Forms.GroupBox();
            this.flpCheckboxes = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpTxt = new System.Windows.Forms.TableLayoutPanel();
            this.gbStore.SuspendLayout();
            this.gbDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStore
            // 
            this.gbStore.Controls.Add(this.btnBrowse);
            this.gbStore.Controls.Add(this.cbChooseGroup);
            this.gbStore.Controls.Add(this.txtStore);
            this.gbStore.Controls.Add(this.lblStore);
            this.gbStore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStore.Location = new System.Drawing.Point(12, 12);
            this.gbStore.Name = "gbStore";
            this.gbStore.Size = new System.Drawing.Size(775, 120);
            this.gbStore.TabIndex = 0;
            this.gbStore.TabStop = false;
            this.gbStore.Text = "Select Store/Stores";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(626, 51);
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
            this.cbChooseGroup.Location = new System.Drawing.Point(10, 27);
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
            this.txtStore.Location = new System.Drawing.Point(206, 58);
            this.txtStore.Name = "txtStore";
            this.txtStore.Size = new System.Drawing.Size(372, 30);
            this.txtStore.TabIndex = 1;
            this.txtStore.Text = "";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(6, 61);
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
            this.gbDevices.Location = new System.Drawing.Point(12, 138);
            this.gbDevices.Name = "gbDevices";
            this.gbDevices.Size = new System.Drawing.Size(775, 260);
            this.gbDevices.TabIndex = 1;
            this.gbDevices.TabStop = false;
            this.gbDevices.Text = "Devices";
            // 
            // flpCheckboxes
            // 
            this.flpCheckboxes.Location = new System.Drawing.Point(6, 29);
            this.flpCheckboxes.Name = "flpCheckboxes";
            this.flpCheckboxes.Size = new System.Drawing.Size(763, 41);
            this.flpCheckboxes.TabIndex = 4;
            // 
            // tlpTxt
            // 
            this.tlpTxt.ColumnCount = 4;
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTxt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpTxt.Location = new System.Drawing.Point(6, 76);
            this.tlpTxt.Name = "tlpTxt";
            this.tlpTxt.RowCount = 3;
            this.tlpTxt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTxt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTxt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTxt.Size = new System.Drawing.Size(763, 178);
            this.tlpTxt.TabIndex = 5;
            // 
            // springer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 625);
            this.Controls.Add(this.gbDevices);
            this.Controls.Add(this.gbStore);
            this.Name = "springer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Springer";
            this.gbStore.ResumeLayout(false);
            this.gbStore.PerformLayout();
            this.gbDevices.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}

