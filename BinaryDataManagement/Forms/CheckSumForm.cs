using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BinaryDataManagement.DataCorrection.CheckSumAlgorithm;

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
                CheckSumAlgorithm checkSumAlgorithm = new CheckSumAlgorithm();
                dataGridView.Rows.Clear();
                btnCheck.Enabled = false;
                dataGridView.Rows.Add("Dato transmitido: " + checkSumAlgorithm.FillWithZeros(_binaryDataSent));
                dataGridView.Rows.Add("Dato recibido: " + checkSumAlgorithm.FillWithZeros(_binaryDataReceived));
                ShowResults(checkSumAlgorithm.CheckSum(_binaryDataSent, _binaryDataReceived));
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

        void ShowResults(CheckSumAlgorithm.Results r) {
            UpdateDataGridFont();
    
            // Agrega las filas al DataGridView
            dataGridView.Rows.Add("Resultado de la suma (recibido + checksum): " + r.MyBinaryDataSum);
            dataGridView.Rows.Add("Checksum (transmitido): " + r.MyCheckSum);
            dataGridView.Rows.Add("Resultado (complemento a 1): " + r.Result);
            dataGridView.Rows.Add("Posiciones donde varía: " + r.Differences);

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
    }
}
