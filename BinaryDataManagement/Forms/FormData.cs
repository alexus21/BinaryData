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
            cmbBoxTipeData.Items.Add("Entero con signo (Complemento A1)");
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
                    lblResult.Text = string.Empty;
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
            else if (cmbBoxTipeData.SelectedIndex == 1 || cmbBoxTipeData.SelectedIndex == 2)
            {
                 // Obtener el texto actual en txtData
                string currentText = txtData.Text;

                // Si el usuario presiona Backspace, simplemente permitirlo
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }

                // Permitir el signo "-" o "+" solo en la primera posición
                if ((e.KeyChar == '-' || e.KeyChar == '+') && currentText.Length == 0)
                {
                    return;
                }

                // Verificar si el carácter es un dígito
                if (char.IsDigit(e.KeyChar))
                {
                    // Agregar el nuevo carácter presionado
                    currentText += e.KeyChar;

                    // Verificar si el valor resultante es un número válido y está en el rango deseado
                    if (!IsValidSignedInteger(currentText, int.MinValue, int.MaxValue))
                    {
                        e.Handled = true; // Suprimir el carácter ingresado
                        MessageBox.Show("El valor debe ser un número entero con signo en el rango de -2,147,483,648 a 2,147,483,647.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    e.Handled = true; // Suprimir el carácter ingresado
                    MessageBox.Show("Solo se permiten números enteros con signo en esta opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool IsValidSignedInteger(string input, int min, int max)
        {
            if (int.TryParse(input, out int number))
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
                    string binaryValue = Convert.ToString(inputValue, 2).PadLeft(32, '0'); // 32 bits

                    // Formatear la cadena binaria con separación de 4 bits por 4 bits
                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar el resultado en lblResult
                    lblResult.Text = "Valor Binario: " + formattedBinary;
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 1)
            {
                // Obtener el valor entero con signo ingresado por el usuario
                string inputText = txtData.Text.Trim();

                // Verificar si el valor es un número entero con signo válido
                if (int.TryParse(inputText, out int signedValue))
                {
                    // Convertir el valor a su representación de complemento a uno (complemento a 1)
                    int complementoUno = ~signedValue;

                    // Formatear el valor en 32 bits
                    string binaryValue = Convert.ToString(complementoUno, 2).PadLeft(32, '0');

                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar el valor en el Label lblResult
                    lblResult.Text = "Valor Binario: " + formattedBinary;
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 2)
            {
                // Obtener el valor entero con signo ingresado por el usuario
                string inputText = txtData.Text.Trim();

                // Verificar si el valor es un número entero con signo válido
                if (int.TryParse(inputText, out int signedValue))
                {
                    // Obtener el bit más significativo
                    int msb = (signedValue >> 31) & 1;

                    // Convertir el valor entero a su representación binaria
                    string binaryValue = Convert.ToString(signedValue, 2);

                    // Añadir ceros a la izquierda para que tenga 32 bits
                    binaryValue = binaryValue.PadLeft(32, '0');

                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar el bit más significativo y el valor binario completo en el Label lblResult
                    lblResult.Text = "Bit más significativo: " + msb.ToString() + Environment.NewLine + "Valor binario: " + formattedBinary;
                }
            }
        }
    }        
}