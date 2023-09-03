using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BinaryDataManagement.DataCorrection.CheckSum;

namespace BinaryDataManagement.Forms {
    public partial class CheckSumForm :Form {

        List<int[]> _BinaryList = new List<int[]>();
        // Acá se almacenarán los datos a transmitir:
        readonly int[] _binaryData = new int[6];
        int _nBitsPressed;
        
        public CheckSumForm() {
            InitializeComponent();
        }

        void txtEnterData_KeyPress(object sender, KeyPressEventArgs e) {
            Console.WriteLine(_nBitsPressed);
            
            if (!char.IsNumber(e.KeyChar)) {
                e.Handled = true;
                MessageBox.Show("Solo números están permitidos");
                if (_nBitsPressed == 0) _nBitsPressed = 0;
                if (_nBitsPressed > 0) _nBitsPressed -= 1;
                return;
            }

            if (e.KeyChar != '0' && e.KeyChar != '1') {
                e.Handled = true;
                MessageBox.Show("Solo se permiten datos binarios (0's y 1's)");
                if (_nBitsPressed == 0) _nBitsPressed = 0;
                if (_nBitsPressed > 0) _nBitsPressed -= 1;
                return;
            }

            if (_nBitsPressed == 6) {
                _binaryData[_nBitsPressed] = int.Parse(e.KeyChar.ToString());
                
                _nBitsPressed = 0;
                _BinaryList.Add(_binaryData);
            }
        }
        
        void btnSendData_Click(object sender, EventArgs e) {
            if (txtEnterData.Text == "") {
                MessageBox.Show("Error: debes proveer un dato a transmitir.");
            }
        }
    }
}
