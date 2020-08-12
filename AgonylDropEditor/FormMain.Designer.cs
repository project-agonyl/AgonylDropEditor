namespace AgonylDropEditor
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurrentMonsterFolderLabel = new System.Windows.Forms.Label();
            this.ReloadDataButton = new System.Windows.Forms.Button();
            this.ChooseNPCFolderButton = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 110);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(713, 431);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.dataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrentMonsterFolderLabel);
            this.groupBox1.Controls.Add(this.ReloadDataButton);
            this.groupBox1.Controls.Add(this.ChooseNPCFolderButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 88);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // CurrentMonsterFolderLabel
            // 
            this.CurrentMonsterFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMonsterFolderLabel.Location = new System.Drawing.Point(6, 16);
            this.CurrentMonsterFolderLabel.Name = "CurrentMonsterFolderLabel";
            this.CurrentMonsterFolderLabel.Size = new System.Drawing.Size(701, 23);
            this.CurrentMonsterFolderLabel.TabIndex = 5;
            this.CurrentMonsterFolderLabel.Text = "No Folder Chosen";
            this.CurrentMonsterFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReloadDataButton
            // 
            this.ReloadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadDataButton.Location = new System.Drawing.Point(389, 50);
            this.ReloadDataButton.Name = "ReloadDataButton";
            this.ReloadDataButton.Size = new System.Drawing.Size(166, 23);
            this.ReloadDataButton.TabIndex = 3;
            this.ReloadDataButton.Text = "Reload Data";
            this.ReloadDataButton.UseVisualStyleBackColor = true;
            this.ReloadDataButton.Click += new System.EventHandler(this.ReloadDataButton_Click);
            // 
            // ChooseNPCFolderButton
            // 
            this.ChooseNPCFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseNPCFolderButton.Location = new System.Drawing.Point(145, 50);
            this.ChooseNPCFolderButton.Name = "ChooseNPCFolderButton";
            this.ChooseNPCFolderButton.Size = new System.Drawing.Size(166, 23);
            this.ChooseNPCFolderButton.TabIndex = 2;
            this.ChooseNPCFolderButton.Text = "Choose NPC Folder";
            this.ChooseNPCFolderButton.UseVisualStyleBackColor = true;
            this.ChooseNPCFolderButton.Click += new System.EventHandler(this.ChooseNPCFolderButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 549);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agonyl Drop Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label CurrentMonsterFolderLabel;
        private System.Windows.Forms.Button ReloadDataButton;
        private System.Windows.Forms.Button ChooseNPCFolderButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}

