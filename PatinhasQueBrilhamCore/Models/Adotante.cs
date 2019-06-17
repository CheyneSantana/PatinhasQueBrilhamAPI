﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Models
{
    public class Adotante
    {
        [Key]
        public int AdotanteId { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int NroEndereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Profissao { get; set; }
        public string TelRes { get; set; }
        public string TelCel { get; set; }
    }
}
