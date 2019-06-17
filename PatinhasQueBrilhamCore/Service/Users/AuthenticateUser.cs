using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class AuthenticateUser
    {
        private PatinhasContext _context;
        public User _user;
        private string _email;
        private string _password;
        private AppAccount appAccount;

        public AuthenticateUser(PatinhasContext context, string email, string password)
        {
            this._context = context;
            this._email = email;
            this._password = password;
            appAccount = new AppAccount();
        }

        public User Authenticate()
        {
            if (string.IsNullOrEmpty(this._email) || string.IsNullOrEmpty(this._password))
                return null;

            User user = this._context.users.SingleOrDefault(s => s.Email == this._email);

            if (user == null)
                return null;

            if (!appAccount.VerifyPasswordHash(this._password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public void autenticar()
        {
            this._user = this.Authenticate();
        }
    }
}
