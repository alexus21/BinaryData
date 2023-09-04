using System;
using System.Windows.Forms;

namespace BinaryDataManagement.Forms {
    public partial class FormMethod :Form {
        public FormMethod() {
            InitializeComponent();
        }

        private void btnSelectCheckSum_Click(object sender, EventArgs e) {
            CheckSumForm checkSum = new CheckSumForm();
            checkSum.Show();
        }
    }
}
