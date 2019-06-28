using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class CreateUser
    {
        private PatinhasContext _context;
        private User _user;
        private string _password;
        private AppAccount appAccount;

        public CreateUser(PatinhasContext context, User user, string password)
        {
            _context = context;
            _user = user;
            _password = password;
            appAccount = new AppAccount();
        }

        private User insert()
        {
            this._user.Email = this._user.Email.Trim();
            if (string.IsNullOrWhiteSpace(this._password))
                throw new AppException("A senha é requerida");

            if (_context.users.Any(x => x.Email == this._user.Email))
                throw new AppException("O Email - " + this._user.Email + " - já está cadastrado");

            byte[] passwordHash, passwordSalt;
            appAccount.CreatePasswordHash(this._password, out passwordHash, out passwordSalt);

            this._user.PasswordHash = passwordHash;
            this._user.PasswordSalt = passwordSalt;

            _context.users.Add(this._user);
            _context.SaveChanges();

            return this._user;
        }

        public User Create()
        {
            return this.insert();
        }
    }
}
