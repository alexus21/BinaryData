namespace BinaryDataManagement.DataCorrection.CheckSum {
    public class FindOutCheckSum {
        public static string ReturnCheckSum(string binaryData) {
            
            // Crear una cadena mutable para realizar los reemplazos
            char[] modifiedData = binaryData.ToCharArray();

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
    }
}
