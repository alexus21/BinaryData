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
            this.lblSentData = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.lblDataSentResult = new System.Windows.Forms.Label();
            this.lblBinarySum = new System.Windows.Forms.Label();
            this.lblCheckSum = new System.Windows.Forms.Label();
            this.lblFinalResult = new System.Windows.Forms.Label();
            this.lblBinarySumResult = new System.Windows.Forms.Label();
            this.lblCheckSumResult = new System.Windows.Forms.Label();
            this.lblShowFinalResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(41, 36);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(304, 20);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Por favor, ingrese aquí el dato a transmitir:";
            // 
            // btnSendData
            // 
            this.btnSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendData.Location = new System.Drawing.Point(420, 73);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(101, 33);
            this.btnSendData.TabIndex = 1;
            this.btnSendData.Text = "Transmitir";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // txtEnterData
            // 
            this.txtEnterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterData.Location = new System.Drawing.Point(44, 73);
            this.txtEnterData.Multiline = true;
            this.txtEnterData.Name = "txtEnterData";
            this.txtEnterData.Size = new System.Drawing.Size(370, 31);
            this.txtEnterData.TabIndex = 2;
            this.txtEnterData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnterData_KeyPress);
            // 
            // lblSentData
            // 
            this.lblSentData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentData.Location = new System.Drawing.Point(44, 135);
            this.lblSentData.Name = "lblSentData";
            this.lblSentData.Size = new System.Drawing.Size(138, 27);
            this.lblSentData.TabIndex = 0;
            this.lblSentData.Text = "Dato transmitido:";
            // 
            // lblDataSentResult
            // 
            this.lblDataSentResult.AutoSize = true;
            this.lblDataSentResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSentResult.Location = new System.Drawing.Point(260, 135);
            this.lblDataSentResult.Name = "lblDataSentResult";
            this.lblDataSentResult.Size = new System.Drawing.Size(0, 20);
            this.lblDataSentResult.TabIndex = 3;
            // 
            // lblBinarySum
            // 
            this.lblBinarySum.AutoSize = true;
            this.lblBinarySum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinarySum.Location = new System.Drawing.Point(44, 183);
            this.lblBinarySum.Name = "lblBinarySum";
            this.lblBinarySum.Size = new System.Drawing.Size(145, 20);
            this.lblBinarySum.TabIndex = 4;
            this.lblBinarySum.Text = "Suma de los datos:";
            // 
            // lblCheckSum
            // 
            this.lblCheckSum.AutoSize = true;
            this.lblCheckSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckSum.Location = new System.Drawing.Point(44, 231);
            this.lblCheckSum.Name = "lblCheckSum";
            this.lblCheckSum.Size = new System.Drawing.Size(172, 20);
            this.lblCheckSum.TabIndex = 5;
            this.lblCheckSum.Text = "CheckSum de la suma:";
            // 
            // lblFinalResult
            // 
            this.lblFinalResult.AutoSize = true;
            this.lblFinalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalResult.Location = new System.Drawing.Point(44, 275);
            this.lblFinalResult.Name = "lblFinalResult";
            this.lblFinalResult.Size = new System.Drawing.Size(86, 20);
            this.lblFinalResult.TabIndex = 6;
            this.lblFinalResult.Text = "Resultado:";
            // 
            // lblBinarySumResult
            // 
            this.lblBinarySumResult.AutoSize = true;
            this.lblBinarySumResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinarySumResult.Location = new System.Drawing.Point(260, 183);
            this.lblBinarySumResult.Name = "lblBinarySumResult";
            this.lblBinarySumResult.Size = new System.Drawing.Size(0, 20);
            this.lblBinarySumResult.TabIndex = 7;
            // 
            // lblCheckSumResult
            // 
            this.lblCheckSumResult.AutoSize = true;
            this.lblCheckSumResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckSumResult.Location = new System.Drawing.Point(260, 231);
            this.lblCheckSumResult.Name = "lblCheckSumResult";
            this.lblCheckSumResult.Size = new System.Drawing.Size(0, 20);
            this.lblCheckSumResult.TabIndex = 7;
            // 
            // lblShowFinalResult
            // 
            this.lblShowFinalResult.AutoSize = true;
            this.lblShowFinalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowFinalResult.Location = new System.Drawing.Point(260, 275);
            this.lblShowFinalResult.Name = "lblShowFinalResult";
            this.lblShowFinalResult.Size = new System.Drawing.Size(0, 20);
            this.lblShowFinalResult.TabIndex = 7;
            // 
            // CheckSumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 350);
            this.Controls.Add(this.lblShowFinalResult);
            this.Controls.Add(this.lblCheckSumResult);
            this.Controls.Add(this.lblBinarySumResult);
            this.Controls.Add(this.lblFinalResult);
            this.Controls.Add(this.lblCheckSum);
            this.Controls.Add(this.lblBinarySum);
            this.Controls.Add(this.lblDataSentResult);
            this.Controls.Add(this.lblSentData);
            this.Controls.Add(this.txtEnterData);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.lblMessage);
            this.Name = "CheckSumForm";
            this.Text = "CheckSumForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox txtEnterData;
        private System.Windows.Forms.Label lblSentData;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label lblDataSentResult;
        private System.Windows.Forms.Label lblBinarySum;
        private System.Windows.Forms.Label lblCheckSum;
        private System.Windows.Forms.Label lblFinalResult;
        private System.Windows.Forms.Label lblBinarySumResult;
        private System.Windows.Forms.Label lblCheckSumResult;
        private System.Windows.Forms.Label lblShowFinalResult;
    }
}