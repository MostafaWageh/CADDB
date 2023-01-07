namespace CADDB
{
    partial class BlockExtractorForm
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
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkLstDwgs = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBLockname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExtractBlock = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(10, 293);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(82, 20);
            this.chkSelectAll.TabIndex = 4;
            this.chkSelectAll.Text = "select all";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkLstDwgs
            // 
            this.chkLstDwgs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chkLstDwgs.FormattingEnabled = true;
            this.chkLstDwgs.Location = new System.Drawing.Point(10, 79);
            this.chkLstDwgs.Name = "chkLstDwgs";
            this.chkLstDwgs.Size = new System.Drawing.Size(508, 208);
            this.chkLstDwgs.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(134, 37);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(290, 22);
            this.textPath.TabIndex = 1;
            this.textPath.Text = "C:\\Users\\workstation\\Desktop\\Test-2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drawing Path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.chkLstDwgs);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 415);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBLockname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(10, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 96);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // txtBLockname
            // 
            this.txtBLockname.Location = new System.Drawing.Point(18, 47);
            this.txtBLockname.Name = "txtBLockname";
            this.txtBLockname.Size = new System.Drawing.Size(467, 22);
            this.txtBLockname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter the Block Specific Name";
            // 
            // btnExtractBlock
            // 
            this.btnExtractBlock.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExtractBlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtractBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtractBlock.Location = new System.Drawing.Point(157, 436);
            this.btnExtractBlock.Name = "btnExtractBlock";
            this.btnExtractBlock.Size = new System.Drawing.Size(146, 33);
            this.btnExtractBlock.TabIndex = 3;
            this.btnExtractBlock.Text = "Extract";
            this.btnExtractBlock.UseVisualStyleBackColor = false;
            this.btnExtractBlock.Click += new System.EventHandler(this.btnExtractBlock_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(89, 436);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 16);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Info";
            // 
            // BlockExtractorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 484);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnExtractBlock);
            this.Controls.Add(this.groupBox1);
            this.Name = "BlockExtractorForm";
            this.Text = "BlockExtractorForm";
            this.Load += new System.EventHandler(this.BlockExtractorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckedListBox chkLstDwgs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBLockname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExtractBlock;
        private System.Windows.Forms.Label lblInfo;
    }
}