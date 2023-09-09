using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryDataManagement.ParidadCorrection;

namespace BinaryDataManagement.Forms
{
    public partial class ParidadForm : Form
    {
        public ParidadForm()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            comboBox1.SelectedIndex = 0;
            lblError.Text = string.Empty;
            timer1.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Deshabilita el ErrorProvider y detiene el temporizador
            errorProvider1.Clear();
            timer1.Stop();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtén el carácter ingresado
            char keyChar = e.KeyChar;

            // Verifica si el carácter es 0, 1, Backspace o Delete
            if (keyChar != '0' && keyChar != '1' && keyChar != '\b' && keyChar != (char)Keys.Delete)
            {
                // Si no es uno de los caracteres permitidos, suprime el evento de tecla
                e.Handled = true;
                errorProvider1.SetError(textBox1, "Ingresa 0 o 1");
                timer1.Start();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            if (!Validations.ValidateDataTextBox(textBox1))
            {
                lblError.Text = @"Ingresa el binario recibido";
                return;
            }

            if (!Validations.ValidateSelection(comboBox1))
            {
                lblError.Text = @"Selecciona par o impar en la lista desplegable";
                return;
            }
            lblError.Text = string.Empty;
            Paridad.ValidateParidad(textBox1.Text, richTextBox1, (ParityType) (comboBox1.SelectedIndex - 1));
        }
    }
}
