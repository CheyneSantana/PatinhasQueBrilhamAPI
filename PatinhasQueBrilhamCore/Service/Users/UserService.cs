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
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        void ValidarSenha(UserDTO userDto);
        void ResetarSenha(string email);
    }

    public class UserService : IUserService
    {
        private PatinhasContext _context;

        public UserService(PatinhasContext context)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            AuthenticateUser authenticateUser = new AuthenticateUser(this._context, email, password);
            authenticateUser.autenticar();
            return authenticateUser._user;
        }

        public User Create(User user, string password)
        {
            CreateUser createUser = new CreateUser(this._context, user, password);
            return createUser.Create();
        }

        public void Delete(int id)
        {
            var user = _context.users.Find(id);
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.users;
        }

        public User GetById(int id)
        {
            return _context.users.Find(id);
        }

        public void ResetarSenha(string email)
        {
            ResetPassword resetPassword = new ResetPassword(this._context, email);
            resetPassword.resetar();
        }

        public void Update(User prUser, string password = null)
        {
            UpdateUser updateUser = new UpdateUser(this._context, prUser, password);
            updateUser.Atualizar();
        }

        public void ValidarSenha(UserDTO userDto)
        {
            ValidatePassword validatePassword = new ValidatePassword(this._context, userDto);
            validatePassword.validar();
        }
    }
}
