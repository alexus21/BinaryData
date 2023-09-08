using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDataManagement
{
    public static class ThemeColor
    {
        // Lista de cadena llamada ColorList e inicializa la lista con una serie de códigos de colores en formato hexadecimal.
        public static List<string> ColorList = new List<string>() { "#3F51B5",
                                                                    "#009688",
                                                                    "#FF5722",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#EA676C",
                                                                    "#E41A4A",
                                                                    "#5978BB",
                                                                    "#018790",
                                                                    "#0E3441",
                                                                    "#00B0AD",
                                                                    "#721D47",
                                                                    "#EA4833",
                                                                    "#EF937E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#126881",
                                                                    "#8BC240",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0094BC",
                                                                    "#E4126B",
                                                                    "#43B76E",
                                                                    "#7BCFE9",
                                                                    "#B71C46"};
        
        // El objetivo de este método es ajustar el brillo del color en función del factor de corrección proporcionado.
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            // Este bloque de código se ejecuta si correctionFactor es menor que 0, lo que significa que se quiere oscurecer el color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            // Este bloque se ejecuta si correctionFactor es igual o mayor que 0, lo que significa que se quiere aclarar el color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            
            // Esto crea un nuevo objeto Color con los componentes de color ajustados y lo devuelve como resultado del método.
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
