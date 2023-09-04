﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BinaryDataManagement.Forms {
    public partial class CheckSumForm :Form {

        // Acá se almacenarán los datos a transmitir:
        string _binaryData;

        public CheckSumForm() {
            InitializeComponent();
        }

        void txtEnterData_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
                MessageBox.Show("Solo números están permitidos");
                return;
            }

            // Si se ingresan valores diferentes a 0 y 1:
            if (e.KeyChar != '0' && e.KeyChar != '1') {
                e.Handled = true;
                MessageBox.Show("Solo se permiten datos binarios (0s y 1s)");
                return;
            }

            // Todo OK, guardar a la cadena:
            _binaryData += e.KeyChar.ToString();
        }

        void btnSendData_Click(object sender, EventArgs e) {
            if (txtEnterData.Text == "") {
                MessageBox.Show("Error: debes proveer un dato a transmitir.");
            }
            else {
                CheckSum(_binaryData);
            }
            
            txtEnterData.Clear();
        }

        void ShowResults(string binarySum, string checksum, string completeData, string result) {
            Console.WriteLine(binarySum);
            Console.WriteLine(checksum);
            Console.WriteLine(completeData);
            Console.WriteLine(result);

            lblBinarySumResult.Text = binarySum;
            lblCheckSumResult.Text = checksum;
            lblDataSentResult.Text = completeData;
            lblShowFinalResult.Text = result;
        }

        #region CheckSumAlgorithm
        #region MainPart
        void CheckSum(string binaryDataString) {
            const int maxBits = 6;
            
            Console.WriteLine("\n");

            // Primero, comprobamos que sea de 6 bits; caso contrario, rellenamos con 0s:
            if (binaryDataString.Length % maxBits != 0) {
                binaryDataString = FillWithZeros(binaryDataString);
            }
            
            // Ahora, procedemos a hacer la suma binaria:
            string myBinaryDataSender = Sum(binaryDataString);
            string myCheckSum = ReturnCheckSum(myBinaryDataSender);
            string sentValue = myCheckSum + myBinaryDataSender;
            string result = FindMistakes(sentValue);

            bool isAllOk = true;
            
            for (int i = 0; i < result.Length; i++) {
                if (result[i] != '0') {
                    isAllOk = false;
                }
            }

            if (isAllOk) result += " (todo correcto)";
            else result += " (error de transmisión)";

            ShowResults(myBinaryDataSender, myCheckSum, sentValue, result);
        }
        #endregion
        
        #region FillString
        string FillWithZeros(string bdq) {
            while (bdq.Length % 6 != 0) {
                bdq = "0" + bdq;
            }

            return bdq;
        }
        #endregion
        
        #region BinarySum
        string Sum(string binaryData) {

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
        #endregion
        
        #region FindCheckSum
        string ReturnCheckSum(string binaryData) {
            
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
        #endregion
        
        #region VerifyData
        string FindMistakes(string data) {
            string result = Sum(data);
            string hasMistakes = ReturnCheckSum(result);
            return hasMistakes;
        }
        
        #endregion
        #endregion
    }
}
