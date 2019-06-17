using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string TelCel { get; set; }
        public string TelRes { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
