using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class UpdateUser
    {
        private PatinhasContext _context;
        private User _user;
        private string _password;
        private AppAccount appAccount;

        public UpdateUser(PatinhasContext context, User user, string password = null)
        {
            _context = context;
            _user = user;
            _password = password;
            appAccount = new AppAccount();
        }

        private void Update()
        {
            var user = _context.users.Find(this._user.Id);

            if (user == null)
                throw new AppException("Usuário não encontrado");

            if (this._user.Email != user.Email)
            {
                if (_context.users.Any(a => a.Email == this._user.Email))
                    throw new AppException("O Email - " + this._user.Email + " - já está cadastrado");
            }

            user.Nome = this._user.Nome;
            user.Sobrenome = this._user.Sobrenome;
            user.Email = this._user.Email;
            user.TelCel = this._user.TelCel;
            user.TelRes = this._user.TelRes;

            if (!string.IsNullOrWhiteSpace(this._password))
            {
                byte[] passwordHash, passwordSalt;
                appAccount.CreatePasswordHash(this._password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.users.Update(user);
            _context.SaveChanges();
        }

        public void Atualizar()
        {
            this.Update();
        }

    }
}
