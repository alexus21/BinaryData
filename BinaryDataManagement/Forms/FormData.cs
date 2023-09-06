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
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            cmbBoxTipeData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxTipeData.Items.Add("Entero sin signo");
            cmbBoxTipeData.Items.Add("Entero con signo (Complemento 1)");
            cmbBoxTipeData.Items.Add("Entero con signo (Bit mas significativo)");
            cmbBoxTipeData.Items.Add("Flotante");
            cmbBoxTipeData.Items.Add("Caracter");
            cmbBoxTipeData.Items.Add("Cadena de caracteres");
            txtData.Enabled = false;
        }

        private void cmbBoxTipeData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbBoxTipeData.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    txtData.Enabled = true;
                    txtData.Clear();
                    break;
                default:
                    txtData.Enabled = false;
                    break;
            }
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbBoxTipeData.SelectedIndex == 0)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; // Suprimir el carácter ingresado
                    MessageBox.Show("Solo se permiten números en esta opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    // Obtener el texto actual en txtData
                    string currentText = txtData.Text;

                    // Agregar el nuevo carácter presionado
                    currentText += e.KeyChar;

                    // Verificar si el valor resultante es un número válido y está en el rango deseado
                    if (!IsValidUnsignedInteger(currentText, 0, 4294967295)) // Reemplaza 0 y 100 con el rango deseado
                    {
                        e.Handled = true; // Suprimir el carácter ingresado
                        MessageBox.Show("El valor debe ser un número entero sin signo en el rango de 0 a 4294967295.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Función para validar si una cadena es un número entero sin signo en un rango específico(Entero sin signo no válido)
        private bool IsValidUnsignedInteger(string input, uint min, uint max)
        {
            if (uint.TryParse(input, out uint number))
            {
                return number >= min && number <= max;
            }
            return false;
        }

        private void btnBinaryData_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una opción en cmbBox
            if (cmbBoxTipeData.SelectedIndex == -1) // El valor -1 indica que no se ha seleccionado ninguna opción
            {
                MessageBox.Show("Por favor, seleccione una opción en el ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método porque la validación ha fallado
            }

            // Verificar si el cuadro de texto txtData está vacío
            if (string.IsNullOrWhiteSpace(txtData.Text))
            {
                MessageBox.Show("Por favor, ingrese datos en el cuadro de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método porque la validación ha fallado
            }

            if (cmbBoxTipeData.SelectedIndex == 0)
            {
                // Convertir el texto del cuadro de texto a un número entero sin signo
                if (uint.TryParse(txtData.Text, out uint inputValue))
                {
                    // Realizar la conversión a formato binario de 32 bits
                    string binaryString = Convert.ToString(inputValue, 2).PadLeft(32, '0'); // 32 bits

                    // Formatear la cadena binaria con separación de 4 bits por 4 bits
                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryString.Substring(i * 4, 4)));

                    // Mostrar el resultado en lblResult
                    lblResult.Text = formattedBinary;
                }
            }
        }

    }        
}