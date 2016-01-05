namespace PasswordHasher
{
    partial class frmPasswordHasher
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblPasswordLength = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.txtMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtHashedPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuResultsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.mnuResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(8, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Password Hasher";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(9, 52);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(251, 20);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Enter a password to be encrypted:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(13, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(710, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(9, 129);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(172, 20);
            this.lblResults.TabIndex = 3;
            this.lblResults.Text = "Password hash results:";
            // 
            // lblPasswordLength
            // 
            this.lblPasswordLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordLength.Location = new System.Drawing.Point(338, 52);
            this.lblPasswordLength.Name = "lblPasswordLength";
            this.lblPasswordLength.Size = new System.Drawing.Size(385, 20);
            this.lblPasswordLength.TabIndex = 7;
            this.lblPasswordLength.Text = "Length: 0";
            this.lblPasswordLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtMethod,
            this.txtHashedPassword,
            this.txtLength,
            this.txtTime});
            this.dgvResults.ContextMenuStrip = this.mnuResults;
            this.dgvResults.Location = new System.Drawing.Point(13, 152);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.Size = new System.Drawing.Size(710, 325);
            this.dgvResults.TabIndex = 8;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            this.dgvResults.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResults_CellMouseUp);
            // 
            // txtMethod
            // 
            this.txtMethod.FillWeight = 120.8127F;
            this.txtMethod.HeaderText = "Method";
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.ReadOnly = true;
            // 
            // txtHashedPassword
            // 
            this.txtHashedPassword.FillWeight = 175F;
            this.txtHashedPassword.HeaderText = "Hashed Password";
            this.txtHashedPassword.Name = "txtHashedPassword";
            this.txtHashedPassword.ReadOnly = true;
            // 
            // txtLength
            // 
            this.txtLength.FillWeight = 35F;
            this.txtLength.HeaderText = "Length";
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            // 
            // txtTime
            // 
            this.txtTime.FillWeight = 55F;
            this.txtTime.HeaderText = "Time (ms)";
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            // 
            // mnuResults
            // 
            this.mnuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuResultsCopy});
            this.mnuResults.Name = "mnuResults";
            this.mnuResults.Size = new System.Drawing.Size(145, 26);
            // 
            // mnuResultsCopy
            // 
            this.mnuResultsCopy.Name = "mnuResultsCopy";
            this.mnuResultsCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuResultsCopy.Size = new System.Drawing.Size(144, 22);
            this.mnuResultsCopy.Text = "&Copy";
            this.mnuResultsCopy.Click += new System.EventHandler(this.mnuResultsCopy_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(610, 103);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(113, 43);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmPasswordHasher
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(735, 489);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblPasswordLength);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(751, 528);
            this.Name = "frmPasswordHasher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Hasher";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.mnuResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblPasswordLength;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.ContextMenuStrip mnuResults;
        private System.Windows.Forms.ToolStripMenuItem mnuResultsCopy;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtHashedPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTime;
    }
}

