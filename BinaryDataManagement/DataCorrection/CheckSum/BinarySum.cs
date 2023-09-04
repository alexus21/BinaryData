using System;
using System.Collections.Generic;

namespace BinaryDataManagement.DataCorrection.CheckSum {
    public static class BinarySum {
        public static string Sum(string binaryData) {

            // Dividir la cadena en subcadenas de 6 bits c/u
            List<string> subStrings = new List<string>();
            for (int i = 0; i < binaryData.Length; i += 6) {
                subStrings.Add(binaryData.Substring(i, 6));
            }

            int[] result = new int[6];
            int carry = 0;

            // Sumar los elementos de cada posición aplicando la lógica de suma binaria
            foreach (string s in subStrings) {
                for (int i = 5, j = s.Length - 1; i >= 0; i--, j--) {
                    int valor = int.Parse(s[j].ToString()) + result[i] + carry;
                    result[i] = valor % 2;
                    carry = valor / 2;
                }
            }

            // Convertir el resultado en una cadena de 0s y 1s
            string resultStr = string.Join("", result);
            return resultStr;
        }
    }
}
