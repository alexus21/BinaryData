namespace BinaryDataManagement.DataCorrection.CheckSum {
    public static class CompleteBits {
        public static string FillWithZeros(string bdq) {
            while (bdq.Length % 6 != 0) {
                bdq = "0" + bdq;
            }

            return bdq;
        }
    }
}
