﻿namespace BinaryDataManagement.Forms {
    partial class CheckSumForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.lblSentData = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtSent = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lblReceivedData = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSentData
            // 
            this.lblSentData.AutoSize = true;
            this.lblSentData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblSentData.Location = new System.Drawing.Point(12, 26);
            this.lblSentData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSentData.Name = "lblSentData";
            this.lblSentData.Size = new System.Drawing.Size(468, 24);
            this.lblSentData.TabIndex = 0;
            this.lblSentData.Text = "Por favor, ingrese aquí el dato enviado (máximo 6 bits):";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCheck.Location = new System.Drawing.Point(879, 15);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(135, 41);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Verificar";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtSent
            // 
            this.txtSent.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtSent.Location = new System.Drawing.Point(556, 15);
            this.txtSent.Margin = new System.Windows.Forms.Padding(4);
            this.txtSent.Multiline = true;
            this.txtSent.Name = "txtSent";
            this.txtSent.Size = new System.Drawing.Size(291, 37);
            this.txtSent.TabIndex = 2;
            this.txtSent.TextChanged += new System.EventHandler(this.txtSent_TextChanged);
            this.txtSent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSent_KeyPress);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Column1});
            this.dataGridView.Location = new System.Drawing.Point(16, 209);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(997, 344);
            this.dataGridView.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Resultados";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblReceivedData
            // 
            this.lblReceivedData.AutoSize = true;
            this.lblReceivedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblReceivedData.Location = new System.Drawing.Point(12, 118);
            this.lblReceivedData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceivedData.Name = "lblReceivedData";
            this.lblReceivedData.Size = new System.Drawing.Size(469, 24);
            this.lblReceivedData.TabIndex = 0;
            this.lblReceivedData.Text = "Por favor, ingrese aquí el dato recibido (máximo 6 bits):";
            // 
            // txtReceived
            // 
            this.txtReceived.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtReceived.Location = new System.Drawing.Point(556, 113);
            this.txtReceived.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(291, 37);
            this.txtReceived.TabIndex = 2;
            this.txtReceived.TextChanged += new System.EventHandler(this.txtReceived_TextChanged);
            this.txtReceived.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceived_KeyPress);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnReset.Location = new System.Drawing.Point(879, 118);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(135, 41);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reiniciar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(512, 26);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(35, 28);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // CheckSumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 574);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.txtSent);
            this.Controls.Add(this.lblReceivedData);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblSentData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CheckSumForm";
            this.Text = "CheckSum";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSentData;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtSent;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label lblReceivedData;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnHelp;
    }
}