using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilhamCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class ResetPassword
    {
        private PatinhasContext _context;
        private string _email;
        private AppAccount appAccount;
        private User _user;
        private string _newPassword;

        public ResetPassword(PatinhasContext context, string email)
        {
            this. _context = context;
            this._email = email;
            this.appAccount = new AppAccount();
        }

        private void GenerateNewPassword()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < 9; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(ch);
            }

            this._newPassword = sb.ToString();

            this.CreateHash();
        }

        private void CreateHash()
        {
            byte[] passwordHash, passwordSalt;
            appAccount.CreatePasswordHash(this._newPassword, out passwordHash, out passwordSalt);

            this._user.PasswordHash = passwordHash;
            this._user.PasswordSalt = passwordSalt;

            this.UpdateUser();
        }

        private void UpdateUser()
        {
            this._context.users.Update(this._user);
            this._context.SaveChanges();

            this.sendNewPassword();
        }

        private void sendNewPassword()
        {
            string body = "Sua nova senha no patinhas é " + this._newPassword + " após acessar, por favor alterar a senha";

            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(body, "Alteração de senha", this._context);
            enviarEmailTask.Enviar(this._email);
        }

        private void getUser()
        {
            this._user = this._context.users.Where(w => w.Email == this._email).FirstOrDefault();
            if (this._user == null)
                throw new AppException("Usuário não existe");
        }

        public void resetar()
        {
            this.getUser();
            this.GenerateNewPassword();
        }
    }
}
