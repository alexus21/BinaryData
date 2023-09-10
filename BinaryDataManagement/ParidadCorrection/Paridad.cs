using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinaryDataManagement.ParidadCorrection
{
    public class Paridad
    {
        /// <summary>
        /// Permite validar si la cadena de caracteres ingresada es de tipo binaria
        /// </summary>
        /// <param name="data">El dato que se evaluará para validar si es binaria</param>
        /// <returns>Retorna verdadero en caso de que el dato sea binario, falso en caso contrario</returns>
        private static bool StringIsBinary(string data)
        {
            //Retorna true si todos los datos de la cadena son 0 o bien son 1
            return data.All(variable => variable == '0' || variable == '1');
        }

        /// <summary>
        /// Cuenta la cantidad de númerosd 1 que hay en la cadena
        /// </summary>
        /// <param name="data">Dato que se evaluará para saber cuantos 1 hay en su interior</param>
        /// <returns>Retorna la cantidad de 1 que existen en data </returns>
        private static int CountOnes(string data)
        {
        
            //Retorna cuantos 1 hay
            return data.Count(numero => numero == '1');
        }

        /// <summary>
        /// Obtiene el nombre del elemento del tipo de ParityTipe dado
        /// </summary>
        /// <param name="parityType">Elemento de ParityType del cual se quiere obtener su nombre</param>
        /// <returns>Retorna el nombre del tipo de dato pasasdo perteneciente a ParityType</returns>
        private static string GetNameParityType(ParityType parityType)
        {
            //Retorna el nombre del elemento pasado de tipo ParityType
            return Enum.GetName(typeof(ParityType), parityType);
        }

        /// <summary>
        /// Rellena la cadena con los ceros faltantes para rellenar un dato de 6 bits + bit de paridad
        /// </summary>
        /// <param name="data">Cadena de texto que se buscará rellenar con los ceros faltantes</param>
        private static void FillWithZeros(ref string data)
        {

            //Objeto de tpo StringBuilder que servirá para agregar datos en la cadena en específico
            StringBuilder stringBuilder = new StringBuilder(data);
            
            //El bucle se repite hasta que la longitud de la cadena sea de 7 o biuen hasta que se haya llenado con los 0 correspondientes
            while (stringBuilder.Length != 7)
            {
                //Inserta un 0 después del bit de paridad
                stringBuilder.Insert(1, "0");
            }
            
            //Se devuelve la cadena ya reseteada con los datos faltantes ya que esta es por medio de refererencia
            data = stringBuilder.ToString();
        }

        /// <summary>
        /// Muestra en color rojo el bit de paridad
        /// </summary>
        /// <param name="richTextBox">Área en donde se mostrarán los datos devueltos</param>
        /// <param name="searchText">Cadena de caracteres anteriores a donde se encuentra el bit de paridad</param>
        private static void SetParityBitColor(RichTextBox richTextBox, string searchText)
        {
            //Obtiene la pocisión de la cadena buscada
            int position = richTextBox.Find(searchText);

            //Valida que la posición esté dentro del rango permitido
            if (position < 0) return;
            //Selecciona el área que se marcará en color rojo
            richTextBox.Select(position + searchText.Length, 1);
            //Se escribe el dato en el color previsto
            richTextBox.SelectionColor = Color.Red;
        }

        
        /// <summary>
        /// Realiza ttodo el proceso que permitirá mostrar los datos
        /// </summary>
        /// <param name="data">Es el dato binario que se evaluará</param>
        /// <param name="richTextBox">Control en donde se mostrarán los resultados del proceso</param>
        /// <param name="parityType">Tipo de paridad, entre par o impar</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateParidad(string data, RichTextBox richTextBox, ParityType parityType)
        {
            //Valida si el dato evaluado no es un valor binario
            if (!StringIsBinary(data))
            {
                //Muestra un mensaje indicando que el dato ingresado necesita ser un valor de tipo binario
                MessageBox.Show(@"Error de data, ingresa un valor binario");
                return;
            }

            //Variable que se encargará de ir guardando el progreso obtenido
            string respuesta = "Status: ";
            
            //Validación de los tipos de paridad
            switch (parityType)
            {
                //Cuando la paridad es de tipo Par
                case ParityType.Par:
                    //Dependiendo de cuantos números 1, en cuanto a relación con ellos, devolverá correcrto o incorrecto
                    respuesta += $@"Dato {(CountOnes(data) % 2 == 0 ? "correcto, no se detectó ningún" :
                        "incorrecto, se detectó un")} error";
                    break;
                //Validación de los tipos de paridad
                case ParityType.Impar:
                    //Dependiendo de cuantos números 1, en cuanto a relación con ellos, devolverá correcrto o incorrecto
                    respuesta +=
                        $@"Dato {(CountOnes(data) % 2 == 0 ? "incorrecto, se detectó un" : "correcto, no se detectó ningún")} error";
                    break;
                //Valor por default
                default:
                    throw new ArgumentOutOfRangeException(nameof(parityType), parityType, null);
            }
            //Rellenando con ceros
            FillWithZeros(ref data);

            //Agregando el texto obtenido mediante losa procesos realizados
            richTextBox.AppendText($"Dato binario recibido: {data}\n");
            richTextBox.AppendText($"Paridad seleccionada: {GetNameParityType(parityType)}\n");
            richTextBox.AppendText(respuesta);
            //Estavlece el color del bit de paridad
            SetParityBitColor(richTextBox, "recibido: ");
        }
    }
}