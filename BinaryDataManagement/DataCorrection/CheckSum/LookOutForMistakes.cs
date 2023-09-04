using System;

namespace BinaryDataManagement.DataCorrection.CheckSum {
    public static class LookOutForMistakes {
        public static string FindMistakes(string data) {
            string result = BinarySum.Sum(data);
            string hasMistakes = FindOutCheckSum.ReturnCheckSum(result);
            return hasMistakes;
        }
    }
}
