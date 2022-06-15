namespace Springer
{
    partial class ResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.pgbResult = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dgwResult = new System.Windows.Forms.DataGridView();
            this.btnCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbResult
            // 
            this.pgbResult.Location = new System.Drawing.Point(12, 53);
            this.pgbResult.Name = "pgbResult";
            this.pgbResult.Size = new System.Drawing.Size(738, 35);
            this.pgbResult.TabIndex = 0;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(330, 22);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(73, 19);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "Pinging...";
            // 
            // btnExcel
            // 
            this.btnExcel.AutoSize = true;
            this.btnExcel.Enabled = false;
            this.btnExcel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(456, 498);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(153, 35);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dgwResult
            // 
            this.dgwResult.AllowUserToAddRows = false;
            this.dgwResult.AllowUserToDeleteRows = false;
            this.dgwResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgwResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwResult.Location = new System.Drawing.Point(13, 104);
            this.dgwResult.Name = "dgwResult";
            this.dgwResult.ReadOnly = true;
            this.dgwResult.RowHeadersWidth = 51;
            this.dgwResult.RowTemplate.Height = 24;
            this.dgwResult.Size = new System.Drawing.Size(737, 383);
            this.dgwResult.TabIndex = 3;
            this.dgwResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgwResult_CellFormatting);
            // 
            // btnCSV
            // 
            this.btnCSV.AutoSize = true;
            this.btnCSV.Enabled = false;
            this.btnCSV.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSV.Location = new System.Drawing.Point(151, 498);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(153, 35);
            this.btnCSV.TabIndex = 4;
            this.btnCSV.Text = "Export CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 543);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.dgwResult);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pgbResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result Form";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbResult;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridView dgwResult;
        private System.Windows.Forms.Button btnCSV;
    }
}