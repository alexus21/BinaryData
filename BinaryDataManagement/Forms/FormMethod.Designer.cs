namespace BinaryDataManagement.Forms
{
    partial class FormMethod
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelectCheckSum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 155);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Method";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSelectCheckSum
            // 
            this.btnSelectCheckSum.Location = new System.Drawing.Point(368, 146);
            this.btnSelectCheckSum.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectCheckSum.Name = "btnSelectCheckSum";
            this.btnSelectCheckSum.Size = new System.Drawing.Size(91, 37);
            this.btnSelectCheckSum.TabIndex = 0;
            this.btnSelectCheckSum.Text = "CheckSumForm";
            this.btnSelectCheckSum.UseVisualStyleBackColor = true;
            this.btnSelectCheckSum.Click += new System.EventHandler(this.btnSelectCheckSum_Click);
            // 
            // FormMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnSelectCheckSum);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMethod";
            this.Text = "Correccion de Errores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelectCheckSum;
    }
}