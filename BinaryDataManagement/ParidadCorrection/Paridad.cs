using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinaryDataManagement.ParidadCorrection
{
    public class Paridad
    {
        private static bool StringIsBinary(string data)
        {
            return data.All(variable => variable == '0' || variable == '1');
        }

        private static int CountOnes(string data)
        {
        
            return data.Count(numero => numero == '1');
        }

        private static string GetNameParityType(ParityType parityType)
        {
            return Enum.GetName(typeof(ParityType), parityType);
        }

        private static void FillWithZeros(ref string data)
        {
            int lengthData = data.Length;

            StringBuilder stringBuilder = new StringBuilder(data);
            
            while (stringBuilder.Length != 7)
            {
                stringBuilder.Insert(1, "0");
            }

            data = stringBuilder.ToString();
        }

        private static void GetPositionParity(RichTextBox richTextBox, string searchText)
        {
            int position = richTextBox.Find(searchText);

            if (position < 0) return;
            richTextBox.Select(position + searchText.Length, 1);
            richTextBox.SelectionColor = Color.Red;
        }

        public static void ValidateParidad(string data, RichTextBox richTextBox, ParityType parityType)
        {
            if (!StringIsBinary(data))
            {
                MessageBox.Show(@"Error de data, ingresa un valor binario");
                return;
            }

            string respuesta = "Status: ";
            switch (parityType)
            {
                case ParityType.Par:
                    respuesta += $@"Dato {(CountOnes(data) % 2 == 0 ? "correcto, no se detectó ningún" :
                        "incorrecto, se detectó un")} error";
                    break;
                case ParityType.Impar:
                    respuesta +=
                        $@"Dato {(CountOnes(data) % 2 == 0 ? "incorrecto, se detectó un" : "correcto, no se detectó ningún")} error";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parityType), parityType, null);
            }
            FillWithZeros(ref data);

            richTextBox.AppendText($"Dato binario recibido: {data}\n");
            richTextBox.AppendText($"Paridad seleccionada: {GetNameParityType(parityType)}\n");
            richTextBox.AppendText(respuesta);
            GetPositionParity(richTextBox, "recibido: ");
        }
    }
}