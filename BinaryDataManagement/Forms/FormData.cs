using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // Configuración inicial al cargar el formulario.
            cmbBoxTipeData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxTipeData.Items.Add("Entero sin signo");
            cmbBoxTipeData.Items.Add("Entero con signo (Complemento A1)");
            cmbBoxTipeData.Items.Add("Entero con signo (Bit mas significativo)");
            cmbBoxTipeData.Items.Add("Flotante");
            cmbBoxTipeData.Items.Add("Caracter");
            cmbBoxTipeData.Items.Add("Cadena de caracteres");
            txtData.Enabled = false; // El cuadro de texto está deshabilitado inicialmente.
        }

        private void cmbBoxTipeData_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Maneja el evento cuando se selecciona un elemento en el ComboBox.
            // Habilita o deshabilita el cuadro de texto según la selección.
            switch (cmbBoxTipeData.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    txtData.Enabled = true; // Habilita el cuadro de texto.
                    txtData.Clear(); // Limpia el cuadro de texto.
                    lblResult.Text = string.Empty; // Borra el contenido del resultado.
                    break;
                default:
                    txtData.Enabled = false; // Deshabilita el cuadro de texto para otras opciones
                    break;
            }
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbBoxTipeData.SelectedIndex == 0)
            {
                // Validación para entrada de números enteros sin signo.
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; // Suprimir el carácter ingresado.
                    MessageBox.Show("Solo se permiten números en esta opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    // Obtener el texto actual en txtData.
                    string currentText = txtData.Text;

                    // Agregar el nuevo carácter presionado.
                    currentText += e.KeyChar;

                    // Verificar si el valor resultante es un número válido y está en el rango deseado.
                    if (!IsValidUnsignedInteger(currentText, 0, 4294967295))
                    {
                        e.Handled = true; // Suprimir el carácter ingresado.
                        MessageBox.Show("El valor debe ser un número entero sin signo en el rango de 0 a 4294967295.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 1 || cmbBoxTipeData.SelectedIndex == 2)
            {
                /* Validación para entrada de números enteros con signo
                (Complemento A1 o Bit más significativo). */
                
                // Obtener el texto actual en txtData.
                string currentText = txtData.Text;

                // Si el usuario presiona Backspace, simplemente permitirlo.
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }

                // Permitir el signo "-" o "+" solo en la primera posición.
                if ((e.KeyChar == '-' || e.KeyChar == '+') && currentText.Length == 0)
                {
                    return;
                }

                // Verificar si el carácter es un dígito.
                if (char.IsDigit(e.KeyChar))
                {
                    // Agregar el nuevo carácter presionado.
                    currentText += e.KeyChar;

                    // Verificar si el valor resultante es un número válido y está en el rango deseado.
                    if (!IsValidSignedInteger(currentText, int.MinValue, int.MaxValue))
                    {
                        e.Handled = true; // Suprimir el carácter ingresado.
                        MessageBox.Show("El valor debe ser un número entero con signo en el rango de -2,147,483,648 a 2,147,483,647.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    e.Handled = true; // Suprimir el carácter ingresado.
                    MessageBox.Show("Solo se permiten números enteros con signo en esta opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 3)
            {
                // Obtener el texto actual en txtData.
                string currentText = txtData.Text;

                // Si el usuario presiona Backspace, simplemente permitirlo.
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }

                // Permitir el signo "-" o "+" solo en la primera posición.
                if ((e.KeyChar == '-' || e.KeyChar == '+') && currentText.Length == 0)
                {
                    return;
                }
                
                // Permitir solo un punto decimal en toda la cadena.
                if (e.KeyChar == '.')
                {
                    if (currentText.Contains("."))
                    {
                        e.Handled = true; // Suprimir el carácter ingresado.
                        MessageBox.Show("Solo se permite un punto decimal en esta opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Verificar si el carácter es un dígito o un punto decimal.
                if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
                {
                    // Agregar el nuevo carácter presionado.
                    currentText += e.KeyChar;

                    // Verificar si el valor resultante es válido en términos de representación de punto flotante de 32 bits.
                    if (!IsValidFloat32(currentText))
                    {
                        e.Handled = true; // Suprimir el carácter ingresado.
                        MessageBox.Show("El valor no puede exceder la representación de punto flotante de 32 bits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    e.Handled = true; // Suprimir el carácter ingresado.
                    MessageBox.Show("Solo se permiten números de punto flotante en esta opción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 4)
            {
                // Obtener el texto actual en txtData.
                string currentText = txtData.Text;

                // Verificar si el usuario presiona Backspace, simplemente permitirlo.
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }

                // Crear una expresión regular para validar caracteres ASCII de 7 bits.
                Regex regex = new Regex("^[\\x00-\\x7F]$");

                // Verificar si el carácter ingresado es válido.
                if (!regex.IsMatch(currentText + e.KeyChar))
                {
                    e.Handled = true; // Suprimir el carácter ingresado.
                    MessageBox.Show("Ingrese exactamente un carácter ASCII válido de 7 bits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 5)
            {
                // Obtener el texto actual en txtData.
                string currentText = txtData.Text;

                // Calcular la cantidad total de bits en la cadena.
                int totalBits = currentText.Length * 8;

                // Verificar si el usuario presiona Backspace, simplemente permitirlo.
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
                
                // Verificar si la cadena tiene más de 32 bits.
                if (totalBits >= 32)
                {
                    e.Handled = true; // Suprimir el caracter ingresado.
                    MessageBox.Show("La cadena no puede tener más de 32 bits en total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        // Función para validar si el número de punto flotante no excede la representación de 32 bits.
        private bool IsValidFloat32(string input)
        {
            float floatValue;
            if (float.TryParse(input, out floatValue))
            {
                // Verificar si el valor absoluto es menor o igual a 2^31 (rango de 32 bits con signo).
                return Math.Abs(floatValue) <= Math.Pow(2, 31);
            }
            return false;
        }

        // Función para validar si una cadena es un número entero sin signo en un rango específico(Entero sin signo es válido).
        private bool IsValidUnsignedInteger(string input, uint min, uint max)
        {
            if (uint.TryParse(input, out uint number))
            {
                return number >= min && number <= max;
            }
            return false;
        }

        // Otro método para validar números enteros con signo(Entero con signo es valido).
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
            // Verificar si se ha seleccionado una opción en cmbBox.
            if (cmbBoxTipeData.SelectedIndex == -1) // El valor -1 indica que no se ha seleccionado ninguna opción.
            {
                MessageBox.Show("Por favor, seleccione una opción en el ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método porque la validación ha fallado
            }

            // Verificar si el cuadro de texto txtData está vacío.
            if (string.IsNullOrWhiteSpace(txtData.Text))
            {
                MessageBox.Show("Por favor, ingrese datos en el cuadro de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método porque la validación ha fallado.
            }

            if (cmbBoxTipeData.SelectedIndex == 0)
            {
                // Convertir el texto del cuadro de texto a un número entero sin signo.
                if (uint.TryParse(txtData.Text, out uint inputValue))
                {
                    // Realizar la conversión a formato binario de 32 bits.
                    string binaryValue = Convert.ToString(inputValue, 2).PadLeft(32, '0'); // 32 bits

                    // Formatear la cadena binaria con separación de 4 bits por 4 bits.
                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar el resultado en lblResult.
                    lblResult.Text = "Valor Binario: " + formattedBinary;
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 1)
            {
                // Obtener el valor entero con signo ingresado por el usuario.
                string inputText = txtData.Text.Trim();

                // Verificar si el valor es un número entero con signo válido.
                if (int.TryParse(inputText, out int signedValue))
                {
                    // Convertir el valor a su representación de complemento a uno (complemento a 1).
                    int complementoUno = ~signedValue;

                    // Formatear el valor en 32 bits.
                    string binaryValue = Convert.ToString(complementoUno, 2).PadLeft(32, '0');
                    
                    // Formatear la cadena binaria con separación de 4 bits por 4 bits.
                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar el valor en el Label lblResult.
                    lblResult.Text = "Valor Binario: " + formattedBinary;
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 2)
            {
                // Obtener el valor entero con signo ingresado por el usuario.
                string inputText = txtData.Text.Trim();

                // Verificar si el valor es un número entero con signo válido.
                if (int.TryParse(inputText, out int signedValue))
                {
                    // Obtener el bit más significativo.
                    int msb = (signedValue >> 31) & 1;

                    // Convertir el valor entero a su representación binaria.
                    string binaryValue = Convert.ToString(signedValue, 2);

                    // Añadir ceros a la izquierda para que tenga 32 bits.
                    binaryValue = binaryValue.PadLeft(32, '0');
                    
                    // Formatear la cadena binaria con separación de 4 bits por 4 bits.
                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar el bit más significativo y el valor binario completo en el Label lblResult.
                    lblResult.Text = "Bit más significativo: " + msb.ToString() + Environment.NewLine + "Valor binario: " + formattedBinary;
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 3)
            {
                // Obtener el texto actual en txtData
                string currentText = txtData.Text.Trim();

                // Validar que el texto no termine con un punto
                if (currentText.EndsWith("."))
                {
                    // e.Handled = true; // Suprimir el carácter ingresado
                    MessageBox.Show("El carácter '.' no puede estar al final del cuadro de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtData.Focus(); // Regresar el enfoque al cuadro de texto
                    return;
                }

                // Convertir el texto a un número de punto flotante
                if (float.TryParse(currentText, out float floatValue))
                {
                    // Convertir el valor a su representación binaria de 32 bits
                    int intValue = BitConverter.ToInt32(BitConverter.GetBytes(floatValue), 0);
                    string binaryValue = Convert.ToString(intValue, 2).PadLeft(32, '0');

                    // Formatear la cadena binaria con separación de 4 bits por 4 bits
                    string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                    // Mostrar la representación binaria en el Label lblResult
                    lblResult.Text = "Número Flotante: " + txtData.Text + Environment.NewLine + "Valor Binario: " + formattedBinary;
                }
            }
            else if (cmbBoxTipeData.SelectedIndex == 4)
            {
                // Obtener el texto actual en txtData.
                string currentText = txtData.Text;

                char inputChar = currentText[0];

                // Convertir el carácter a su representación binaria de 32 bits.
                string binaryValue = Convert.ToString(inputChar, 2).PadLeft(32, '0');

                // Formatear la cadena binaria con separación de 4 bits por 4 bits.
                string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                // Mostrar la representación binaria en el Label lblResult.
                lblResult.Text = "Caracter: " + txtData.Text + Environment.NewLine + "Valor Binario: " + formattedBinary;
            }
            else if (cmbBoxTipeData.SelectedIndex == 5)
            {
                // Obtener el texto actual en txtData.
                string currentText = txtData.Text;
                
                // Convertir cada carácter a su representación binaria de 8 bits.
                string binaryValue = string.Join("", currentText.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')));
                
                // Añadir ceros a la izquierda para que tenga 32 bits.
                binaryValue = binaryValue.PadLeft(32, '0');
                
                // Formatear la cadena binaria con separación de 4 bits por 4 bits.
                string formattedBinary = string.Join(" ", Enumerable.Range(0, 8).Select(i => binaryValue.Substring(i * 4, 4)));

                // Mostrar la representación binaria en el Label lblResult.
                lblResult.Text = "Cadena: " + txtData.Text + Environment.NewLine + "Valor Binario: " + formattedBinary;
            }
            
            txtData.Clear();
            txtData.Focus();
        }
    }        
}