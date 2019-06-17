using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class ValidatePassword
    {
        private UserDTO _userDto;
        private PatinhasContext _context;
        private AppAccount appAccount;

        public ValidatePassword(PatinhasContext context, UserDTO userDto)
        {
            _context = context;
            _userDto = userDto;
            appAccount = new AppAccount();
        }

        private void ValidarSenha()
        {
            User user = _context.users.Where(w => w.Id == this._userDto.Id).FirstOrDefault();
            if (user != null)
            {
                if (!appAccount.VerifyPasswordHash(this._userDto.Password, user.PasswordHash, user.PasswordSalt))
                    throw new AppException("Senha antiga não confere");
            }
        }

        public void validar()
        {
            this.ValidarSenha();
        }
    }
}
