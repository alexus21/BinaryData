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
            //Centrando el texto del área principal
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            //Hacer que la selección del comboBox sea el primer item
            comboBox1.SelectedIndex = 0;
            //Vaciar el texto del label que muestra si hay un error al seleccionar o ingresar los datos
            lblError.Text = string.Empty;
            //Se asigna la función que eliminará la data del errorProvider después de 3 segundos
            timer1.Tick += Timer_Tick;
        }

        //Método que se le asigna al timer creado
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
                //Limpia la data del errorProvider
                errorProvider1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Limpia el texto del área principal
            richTextBox1.Text = string.Empty;
            
            //Valida si el dato binario ingresado está vacio
            if (!Validations.ValidateDataTextBox(textBox1))
            {
                //Muestra un mensaje indicando que la data del textBox donde debe ingresar el valor binario está vacío
                lblError.Text = @"Ingresa el binario recibido";
                return;
            }

            //Valida si seleccionó un dato válido de la lista desplegable, siendo estos los valores válidos entre par e impar
            if (!Validations.ValidateSelection(comboBox1))
            {
                //Muestra un mensaje indicando que el item seleccionado noi es válido y que deberá de seleccionar otro
                lblError.Text = @"Selecciona par o impar en la lista desplegable";
                return;
            }
            
            //Limpia el texto del label que muestra uno de los posibles errores
            lblError.Text = string.Empty;
            
            //Se llama al método que me permite mostrar la información correspondiente con los datos ingresados por el usuario
            Paridad.ValidateParidad(textBox1.Text, richTextBox1, (ParityType) (comboBox1.SelectedIndex - 1));
        }
    }
}
