using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryDataManagement.Forms
{
    public partial class ParidadForm : Form
    {
        public ParidadForm()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            comboBox1.SelectedIndex = 0;
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
            }
        }
    }
}
