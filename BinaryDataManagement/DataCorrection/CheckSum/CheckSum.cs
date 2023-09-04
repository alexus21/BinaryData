using System;
using System.Collections.Generic;

namespace BinaryDataManagement.DataCorrection.CheckSum {
    public static class CheckSum {
        const int MaxBits = 6;

        public static void FindCheckSum(string binaryDataString) {
            Console.WriteLine("\n");

            // Primero, comprobamos que sea de 6 bits; caso contrario, rellenamos con 0s:
            if (binaryDataString.Length % 6 != 0) {
                binaryDataString = CompleteBits.FillWithZeros(binaryDataString);
            }
            
            // Ahora, procedemos a hacer la suma binaria:
            string myBinaryDataSender = BinarySum.Sum(binaryDataString);
            string myCheckSum = FindOutCheckSum.ReturnCheckSum(myBinaryDataSender);
            
            Console.WriteLine("Sum: " + myBinaryDataSender);
            Console.WriteLine("CheckSum: " + myCheckSum);
            
        }
    }
}
