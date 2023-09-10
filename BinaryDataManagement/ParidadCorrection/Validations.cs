using System.Windows.Forms;

namespace BinaryDataManagement.ParidadCorrection
{
    public class Validations
    {
        /// <summary>
        /// </summary>
        /// <param name="comboBox">Control de donde se obtendrá la selección</param>
        /// <returns>Devuelve true si el indice seleccionado es mayor a cero, falso en caso contrario</returns>
        public static bool ValidateSelection(ComboBox comboBox)
        {
            //Devuelve verdadero si el índice seleccionado en la lista desplegable es mayor que 0, falso en caso contrario;
            return comboBox.SelectedIndex > 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="textBox">Componente de tipo TextBox a evaluar</param>
        /// <returns>Retorna si el textBox evaluado no se encuentra vacio, devuelve true si no está vacio, false en caso contrario</returns>
        public static bool ValidateDataTextBox(TextBox textBox)
        {
            //Retorna verdadero en caso de que la longitud del texto en el control sea mayor que 0, falso en caso contrario
            return textBox.Text.Length > 0;
        }
    }
}