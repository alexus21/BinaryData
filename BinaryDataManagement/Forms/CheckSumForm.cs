using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BinaryDataManagement.Forms {
    public partial class CheckSumForm :Form {

        // Acá se almacenarán los datos a transmitir:
        string _binaryDataSent, _binaryDataReceived;

        public CheckSumForm() {
            InitializeComponent();
            btnReset.Enabled = false;
        }

        void txtSent_KeyPress(object sender, KeyPressEventArgs e) {
            // Si se ingresan valores diferentes a 0 y 1:
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != (char)Keys.Back) {
                e.Handled = true;
                MessageBox.Show("Solo se permiten datos binarios (0s y 1s)");
                return;
            }

            _binaryDataSent += e.KeyChar.ToString();
        }

        void txtReceived_KeyPress(object sender, KeyPressEventArgs e) {
            // Si se ingresan valores diferentes a 0 y 1:
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != (char)Keys.Back) {
                e.Handled = true;
                MessageBox.Show("Solo se permiten datos binarios (0s y 1s)");
                return;
            }

            _binaryDataReceived += e.KeyChar.ToString();
        }

        void txtSent_TextChanged(object sender, EventArgs e) {
            // Elimina cualquier carácter no válido
            _binaryDataSent = new string(txtSent.Text.Where(c => c == '0' || c == '1').ToArray());

            // Limita la longitud a 6 dígitos
            if (_binaryDataSent.Length > 6) {
                MessageBox.Show("Límite de bits alcanzado");
                _binaryDataSent = _binaryDataSent.Substring(0, 6);
            }
            
            // Actualiza el valor del cuadro de texto
            txtSent.Text = _binaryDataSent; 
            // Coloca el cursor al final del texto
            txtSent.SelectionStart = _binaryDataSent.Length; 
        }

        void txtReceived_TextChanged(object sender, EventArgs e) {
            // Elimina cualquier carácter no válido
            _binaryDataReceived = new string(txtReceived.Text.Where(c => c == '0' || c == '1').ToArray());

            // Limita la longitud a 6 dígitos
            if (_binaryDataReceived.Length > 6) {
                MessageBox.Show("Límite de bits alcanzado");
                _binaryDataReceived = _binaryDataReceived.Substring(0, 6);
            }
            
            // Actualiza el valor del cuadro de texto
            txtReceived.Text = _binaryDataReceived; 
            // Coloca el cursor al final del texto
            txtReceived.SelectionStart = _binaryDataReceived.Length; 
        }

        void btnCheck_Click(object sender, EventArgs e) {
            
            if (txtSent.Text == "" || txtReceived.Text == "") {
                MessageBox.Show("Error: debes proveer un dato a transmitir.");
            } else {
                btnCheck.Enabled = false;
                dataGridView.Rows.Add("Dato transmitido: " + FillWithZeros(_binaryDataSent));
                dataGridView.Rows.Add("Dato recibido: " + FillWithZeros(_binaryDataReceived));
                CheckSum(_binaryDataSent, _binaryDataReceived);
                txtSent.Enabled = false;
                txtReceived.Enabled = false;
                btnReset.Enabled = true;
            }
        }

        void btnReset_Click(object sender, EventArgs e) {
            _binaryDataSent = "";
            txtSent.Clear();
            txtReceived.Clear();
            txtSent.Enabled = true;
            txtReceived.Enabled = true;
            dataGridView.Rows.Clear();
            btnCheck.Enabled = true;
            btnReset.Enabled = false;
        }

        void ShowResults(string binarySum, string checksum, string result) {
            UpdateDataGridFont();
    
            // Agrega las filas al DataGridView
            dataGridView.Rows.Add("Resultado de la suma: " + binarySum);
            dataGridView.Rows.Add("Checksum: " + checksum);
            dataGridView.Rows.Add("Resultado: " + result);

            // Marca las filas como no editables
            for (int i = 0; i < dataGridView.Rows.Count; i++) {
                dataGridView.Rows[i].ReadOnly = true;
            }
        }
        
        void UpdateDataGridFont() {
            //Change cell font
            foreach(DataGridViewColumn c in dataGridView.Columns) {
                c.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14F, GraphicsUnit.Pixel);
            }
        }

        #region CheckSumAlgorithm
        #region MainPart
        void CheckSum(string binaryDataSent, string binaryDataReceived) {
            const int maxBits = 6;
            
            // Primero, comprobamos que sea de 6 bits; caso contrario, rellenamos con 0s:
            if (binaryDataSent.Length % maxBits != 0) {
                binaryDataSent = FillWithZeros(binaryDataSent);
            }
            
            if (binaryDataReceived.Length % maxBits != 0) {
                binaryDataReceived = FillWithZeros(binaryDataReceived);
            }
            
            // Ahora, procedemos a hacer la suma binaria:
            string myCheckSum = ReturnCheckSum(binaryDataSent);
            string myBinaryDataSum = Sum(binaryDataReceived, myCheckSum);
            string result = ReturnCheckSum(myBinaryDataSum);

            bool isAllOk = true;
            
            for (int i = 0; i < result.Length; i++) {
                if (result[i] != '0') {
                    isAllOk = false;
                }
            }
            
            if (isAllOk) result += " (envío correcto)";
            else result += " (error de transmisión de datos)";

            ShowResults(myBinaryDataSum,  myCheckSum, result);
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
        string Sum(string binaryDataSent, string checksum) {
            List<string> subStrings = new List<string>();
            
            subStrings.Add(binaryDataSent);
            subStrings.Add(checksum);

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

            // Convertir el resultado (quitar los espacios):
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
        
        #region SolveMistake

        string SolveErrors(string sentData, string receivedData) {
            if (sentData != receivedData) {
                return "Error de transmisión";
            }
            
            return "XD";
        }
        #endregion

        #endregion

        
    }
}
