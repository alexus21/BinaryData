using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BinaryDataManagement.DataCorrection.CheckSum;

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

            CheckSum.FindCheckSum(_binaryData);
        }
    }
}
