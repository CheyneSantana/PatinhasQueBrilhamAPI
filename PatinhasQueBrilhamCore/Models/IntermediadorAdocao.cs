using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Models
{
    public class IntermediadorAdocao
    {
        public int IntermediadorAdocaoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int NroEndereco { get; set; }
        public string TelRes { get; set; }
        public string TelCel { get; set; }
        public int Ativo { get; set; }
    }
}
