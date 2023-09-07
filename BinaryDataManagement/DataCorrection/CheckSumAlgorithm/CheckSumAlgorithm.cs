using System;

namespace BinaryDataManagement.DataCorrection.CheckSumAlgorithm {
    public class CheckSumAlgorithm {

        // Estructura para almacenar los resultados de la verificación
        public struct Results {
            public string MyBinaryDataSum { get; set; }
            public string MyCheckSum { get; set; }
            public string Result { get; set; }
            public string Differences { get; set; }
        }
        
        // Función principal que realiza la comprobación de suma de comprobación
        public Results CheckSum(string binaryDataSent, string binaryDataReceived) {
            const int maxBits = 6; // Definimos el número máximo de bits

            bool isAllOk = true; // Variable para rastrear si todo está correcto
            
            // Primero, comprobamos si las cadenas no tienen una longitud múltiplo de 6 bits y, en ese caso, las rellenamos con ceros.
            if (binaryDataSent.Length % maxBits != 0) {
                binaryDataSent = FillWithZeros(binaryDataSent);
            }
            
            if (binaryDataReceived.Length % maxBits != 0) {
                binaryDataReceived = FillWithZeros(binaryDataReceived);
            }
            
            // Luego, calculamos la suma de comprobación y la suma de datos binarios
            string myCheckSum = ReturnCheckSum(binaryDataSent);
            string myBinaryDataSum = Sum(binaryDataReceived, myCheckSum);
            
            // Calculamos una segunda suma de comprobación para verificar la integridad
            string result = ReturnCheckSum(myBinaryDataSum);
            string differences = "";
            
            // Verificamos si todos los bits en la segunda suma de comprobación son ceros
            for (int i = 0; i < result.Length; i++) {
                if (result[i] != '0') {
                    isAllOk = false;
                    differences = SolveErrors(binaryDataSent, binaryDataReceived);
                }
            }
            
            // Agregamos un mensaje al resultado según si todo está correcto o si hay errores
            if (isAllOk) result += " (envío correcto)";
            else result += " (error de transmisión de datos)";

            // Creamos una instancia de la estructura Results y la devolvemos
            var r = new Results() {
                MyBinaryDataSum = myBinaryDataSum,
                MyCheckSum = myCheckSum,
                Result = result,
                Differences = differences
            };

            return r;
        }
        
        // Función para rellenar con ceros hasta que la cadena tenga una longitud múltiplo de 6
        public string FillWithZeros(string bdq) {
            while (bdq.Length % 6 != 0) {
                bdq = "0" + bdq;
            }
            return bdq;
        }
        
        // Función para realizar la suma binaria
        string Sum(string binaryDataSent, string checksum) {
            int[] result = new int[6];
            int carry = 0;

            // Sumar los elementos de cada posición aplicando la lógica de suma binaria
            for (int i = 5; i >= 0; i--) {
                // Esta línea de código realiza la suma binaria
                // en las posiciones de las cadenas, teniendo en cuenta cualquier 
                // acarreo previo.
                int valor = int.Parse(binaryDataSent[i].ToString()) + int.Parse(checksum[i].ToString()) + carry;
                result[i] = valor % 2;
                carry = valor / 2;
            }

            // Convertir el resultado (quitar los espacios):
            string resultStr = string.Join("", result);
            Console.Write("Suma: " + resultStr);
            return resultStr;
        }

        // Función para invertir los bits de una cadena binaria
        string ReturnCheckSum(string binaryData) {
            
            // Crear una cadena mutable para realizar los reemplazos
            char[] modifiedData = binaryData.ToCharArray();

            // Cambiamos los valores al otro (1 -> 0; 0 -> 1). Es decir, complemento a 1.
            for (int i = 0; i < modifiedData.Length; i++) {
                if (modifiedData[i] == '0') {
                    modifiedData[i] = '1';
                }
                else if (modifiedData[i] == '1') {
                    modifiedData[i] = '0';
                }
            }
            
            // Convertir la cadena mutable de nuevo a una cadena
            string result = new string(modifiedData);
            return result;
        }
        
        // Función para resolver errores:
        string SolveErrors(string sent, string received) {
            string positionsWhereAreDifferents = "";
    
            // Verificamos que los valores en las posiciones de cada cadena sea diferente
            // y adjuntamos a un arreglo las posiciones que son distintas
            for (int i = 0; i <= 5; i++) {
                if (sent[i] != received[i]) {
                    positionsWhereAreDifferents += (i + 1) + ", ";
                }
            }

            if (positionsWhereAreDifferents.Length == 0) {
                positionsWhereAreDifferents = "Ninguna";
            }
    
            return positionsWhereAreDifferents;
        }
    }
}
