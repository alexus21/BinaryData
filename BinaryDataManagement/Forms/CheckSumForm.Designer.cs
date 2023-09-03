namespace BinaryDataManagement.Forms {
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
        private void InitializeComponent() {
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSendData = new System.Windows.Forms.Button();
            this.txtEnterData = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(41, 36);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(366, 16);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Por favor, ingrese aquí el dato a transmitir (máximo de 6 bits):";
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(420, 73);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(101, 33);
            this.btnSendData.TabIndex = 1;
            this.btnSendData.Text = "Enviar";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // txtEnterData
            // 
            this.txtEnterData.Location = new System.Drawing.Point(44, 73);
            this.txtEnterData.Multiline = true;
            this.txtEnterData.Name = "txtEnterData";
            this.txtEnterData.Size = new System.Drawing.Size(163, 31);
            this.txtEnterData.TabIndex = 2;
            this.txtEnterData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnterData_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(477, 144);
            this.dataGridView1.TabIndex = 3;
            // 
            // CheckSumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 350);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtEnterData);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.lblMessage);
            this.Name = "CheckSumForm";
            this.Text = "CheckSumForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox txtEnterData;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}