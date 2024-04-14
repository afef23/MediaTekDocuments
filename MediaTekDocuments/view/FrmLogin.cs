using System;
using MediaTekDocuments.controller;
using System.Windows.Forms;
using MediaTekDocuments.model;
namespace MediaTekDocuments.view
{
    public partial class FrmLogin : Form
    {
        private FrmLoginController controller;
        public FrmLogin()
        {
            InitializeComponent();
            controller = new FrmLoginController();
            this.AcceptButton = btnConnec;
        }



        /// <summary>
        /// Demande de connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnec_Click(object sender, EventArgs e)
        {
            if (controller.GetConnexion(txbLogin.Text, txbPwd.Text))
            {
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Mauvais mdp ou identifiant utilisateur");

            }

        }
    }
}
