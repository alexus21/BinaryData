using System;
using System.Collections.Generic;

namespace BinaryDataManagement.DataCorrection.CheckSum {
    public static class CheckSum {

        static int _maxBits = 6;
        
        public static void FindCheckSum(List<int[]> dataList) {
            foreach (var binaryNumber in dataList) {
                if (binaryNumber.Length < _maxBits) {
                    
                }
            }
        }

        // Llenamos el numero binario con ceros si este no es de 6 bits:
        static int[] _ComplementArray(int[] arrayToFill) {
            int howManyZeros = _maxBits - arrayToFill.Length;
            
            
        }
    }
}
