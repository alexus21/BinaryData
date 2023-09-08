using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryDataManagement {
    public partial class Form1 :Form {

        //  Almacena el botón actualmente seleccionado en el menú.
        private Button currentButton;
        // Un objeto Random utilizado para generar números aleatorios.
        private Random random;
        // Una variable temporal para evitar que se elija el mismo color repetidamente.
        private int tempIndex;
        // Almacena la instancia del formulario activo actualmente.
        private Form activeForm;

        // En el constructor, se inicializan las variables y se oculta el botón btnClose
        public Form1() {
            InitializeComponent();
            random = new Random();
            btnClose.Visible = false;
        }

        // Este método selecciona un color aleatorio de una lista predefinida de colores en formato hexadecimal.
        public Color SelectThemeColor() {
            int index = random.Next(ThemeColor.ColorList.Count);

            while (tempIndex == index) {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        /* Este método se utiliza para resaltar el botón del menú seleccionado.
        Cambia el color de fondo, el color de fuente y otros aspectos visuales del botón seleccionado. */
        private void ActivateButton(object btnSender) {
            if (btnSender != null) {
                if (currentButton != (Button)btnSender) {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.TextAlign = ContentAlignment.MiddleCenter;
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnClose.Visible = true;
                }
            }
        }

        // Este método desactiva todos los botones del menú, restableciendo sus estilos.
        private void DisableButton() {
            foreach (Control previousBtn in panelMenu.Controls) {
                if (previousBtn.GetType() == typeof(Button)) {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /* Este método se utiliza para abrir un formulario secundario dentro del formulario principal.
        Cierra cualquier formulario secundario abierto anteriormente y luego muestra el nuevo formulario seleccionado. */
        public void OpenChildForm(Form childForm, object btnSender) {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        /* Estos manejadores de eventos se activan cuando se hace clic en los botones del menú.
        Llaman al método OpenChildForm para abrir el formulario secundario correspondiente. */
        private void btnData_Click(object sender, EventArgs e) {
            OpenChildForm(new Forms.FormData(), sender);
        }

        private void btnMethodError_Click(object sender, EventArgs e) {
            OpenChildForm(new Forms.CheckSumForm(), sender);
        }

        private void btnClose_Click(object sender, EventArgs e) {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        // Este método restablece la apariencia del menú y el título del formulario principal.
        private void Reset() {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnClose.Visible = false;
        }

        private void btnPariedad_Click(object sender, EventArgs e) {
            OpenChildForm(new Forms.ParidadForm(), sender);
        }
    }
}