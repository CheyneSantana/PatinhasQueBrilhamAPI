using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.DTO
{
    public class AdotanteDTO
    {
        public int adotanteId { get; set; }
        public int adotanteAnimalAdocaoId { get; set; }
        public string nome { get; set; }
        public DateTime dtNascimento { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public int nroEndereco { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string profissao { get; set; }
        public string telRes { get; set; }
        public string telCel { get; set; }
        public int estado { get; set; }
    }
}
