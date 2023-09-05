namespace BinaryDataManagement.Forms
{
    partial class FormData
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
            this.btnBinaryData = new System.Windows.Forms.Button();
            this.lblTipeData = new System.Windows.Forms.Label();
            this.lblBits = new System.Windows.Forms.Label();
            this.cmbBoxTipeData = new System.Windows.Forms.ComboBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBinaryData
            // 
            this.btnBinaryData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinaryData.Location = new System.Drawing.Point(793, 95);
            this.btnBinaryData.Margin = new System.Windows.Forms.Padding(4);
            this.btnBinaryData.Name = "btnBinaryData";
            this.btnBinaryData.Size = new System.Drawing.Size(201, 36);
            this.btnBinaryData.TabIndex = 0;
            this.btnBinaryData.Text = "Convertir a binario";
            this.btnBinaryData.UseVisualStyleBackColor = true;
            this.btnBinaryData.Click += new System.EventHandler(this.btnBinaryData_Click);
            // 
            // lblTipeData
            // 
            this.lblTipeData.AutoSize = true;
            this.lblTipeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipeData.Location = new System.Drawing.Point(124, 67);
            this.lblTipeData.Name = "lblTipeData";
            this.lblTipeData.Size = new System.Drawing.Size(228, 24);
            this.lblTipeData.TabIndex = 1;
            this.lblTipeData.Text = "Seleccione el tipo de dato";
            // 
            // lblBits
            // 
            this.lblBits.AutoSize = true;
            this.lblBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBits.Location = new System.Drawing.Point(428, 67);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(335, 24);
            this.lblBits.TabIndex = 2;
            this.lblBits.Text = "Ingrese el dato a representar en 32 bits";
            // 
            // cmbBoxTipeData
            // 
            this.cmbBoxTipeData.FormattingEnabled = true;
            this.cmbBoxTipeData.Location = new System.Drawing.Point(92, 104);
            this.cmbBoxTipeData.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBoxTipeData.Name = "cmbBoxTipeData";
            this.cmbBoxTipeData.Size = new System.Drawing.Size(293, 24);
            this.cmbBoxTipeData.TabIndex = 3;
            this.cmbBoxTipeData.SelectedIndexChanged += new System.EventHandler(this.cmbBoxTipeData_SelectedIndexChanged);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(432, 104);
            this.txtData.Margin = new System.Windows.Forms.Padding(4);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(331, 24);
            this.txtData.TabIndex = 4;
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(350, 312);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 29);
            this.lblResult.TabIndex = 5;
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 574);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.cmbBoxTipeData);
            this.Controls.Add(this.lblBits);
            this.Controls.Add(this.lblTipeData);
            this.Controls.Add(this.btnBinaryData);
            this.Name = "FormData";
            this.Text = "Conversion de Datos";
            this.Load += new System.EventHandler(this.FormData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBinaryData;
        private System.Windows.Forms.Label lblTipeData;
        private System.Windows.Forms.Label lblBits;
        private System.Windows.Forms.ComboBox cmbBoxTipeData;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblResult;
    }
}