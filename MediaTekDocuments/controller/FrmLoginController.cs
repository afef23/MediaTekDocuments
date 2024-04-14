using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System.Security.Cryptography;
using System.Text;
using MediaTekDocuments.view;

namespace MediaTekDocuments.controller
{
    class FrmLoginController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        private Utilisateur utilisateur = null;


        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmLoginController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Lance la vue principale
        /// </summary>


        /// <summary>
        /// Retourne vrai si l'utilisateur existe dans la BDD
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool GetConnexion(string ident, string password)
        {
            password = "salt123" + password;
            string hash = "";

            hash = ComputeSHA256Hash(password);

            utilisateur = access.GetConnexion(ident, hash);
            if (utilisateur != null)
            {
                FrmMediatek mediatek = new FrmMediatek(utilisateur);
                mediatek.Show();
                return true;
            }
            else { return false; }

        }

        /// <summary>
        /// Retourne le hash au format string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
