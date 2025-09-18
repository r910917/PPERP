namespace PPERP_FormDesign
{
    partial class frm9Dataset
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtItemName_Selected = new System.Windows.Forms.TextBox();
            this.txtItemId_Selected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBPGroup = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBGId = new System.Windows.Forms.TextBox();
            this.cbbBPGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurCell = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBPGroup)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCurCell);
            this.groupBox2.Controls.Add(this.txtItemName_Selected);
            this.groupBox2.Controls.Add(this.txtItemId_Selected);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dgvBPGroup);
            this.groupBox2.Location = new System.Drawing.Point(101, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 385);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. DataSet中DataTable資料顯示在DataGridView元件";
            // 
            // txtItemName_Selected
            // 
            this.txtItemName_Selected.Location = new System.Drawing.Point(118, 342);
            this.txtItemName_Selected.Name = "txtItemName_Selected";
            this.txtItemName_Selected.Size = new System.Drawing.Size(298, 25);
            this.txtItemName_Selected.TabIndex = 7;
            // 
            // txtItemId_Selected
            // 
            this.txtItemId_Selected.Location = new System.Drawing.Point(118, 311);
            this.txtItemId_Selected.Name = "txtItemId_Selected";
            this.txtItemId_Selected.Size = new System.Drawing.Size(298, 25);
            this.txtItemId_Selected.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "選取項內容";
            // 
            // dgvBPGroup
            // 
            this.dgvBPGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBPGroup.Location = new System.Drawing.Point(21, 45);
            this.dgvBPGroup.Name = "dgvBPGroup";
            this.dgvBPGroup.RowTemplate.Height = 24;
            this.dgvBPGroup.Size = new System.Drawing.Size(632, 249);
            this.dgvBPGroup.TabIndex = 0;
            this.dgvBPGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBPGroup_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBGId);
            this.groupBox1.Controls.Add(this.cbbBPGroup);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(101, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 146);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1.ComboBox下拉選單元件資料來源";
            // 
            // txtBGId
            // 
            this.txtBGId.Location = new System.Drawing.Point(165, 81);
            this.txtBGId.Name = "txtBGId";
            this.txtBGId.Size = new System.Drawing.Size(209, 25);
            this.txtBGId.TabIndex = 3;
            // 
            // cbbBPGroup
            // 
            this.cbbBPGroup.FormattingEnabled = true;
            this.cbbBPGroup.Location = new System.Drawing.Point(165, 50);
            this.cbbBPGroup.Name = "cbbBPGroup";
            this.cbbBPGroup.Size = new System.Drawing.Size(209, 23);
            this.cbbBPGroup.TabIndex = 2;
            this.cbbBPGroup.SelectedValueChanged += new System.EventHandler(this.cbbBPGroup_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "客戶群組";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "選取代碼";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(101, 651);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(673, 147);
            this.txtResult.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(98, 633);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "執行結果";
            // 
            // txtCurCell
            // 
            this.txtCurCell.Location = new System.Drawing.Point(422, 311);
            this.txtCurCell.Name = "txtCurCell";
            this.txtCurCell.Size = new System.Drawing.Size(231, 25);
            this.txtCurCell.TabIndex = 8;
            // 
            // frm9Dataset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 829);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm9Dataset";
            this.Text = "9.DataSet架構基本操作";
            this.Load += new System.EventHandler(this.frm9Dataset_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBPGroup)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtItemName_Selected;
        private System.Windows.Forms.TextBox txtItemId_Selected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvBPGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBGId;
        private System.Windows.Forms.ComboBox cbbBPGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurCell;
    }
}