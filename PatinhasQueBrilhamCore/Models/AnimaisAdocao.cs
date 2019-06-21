using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Models
{
    public class AnimaisAdocao
    {
        [Key]
        public int AnimaisAdocaoId { get; set; }
        public string NomeAntigo { get; set; }
        [Required]
        public string NomeAtual { get; set; }
        [Required]
        public int Especie { get; set; }
        [Required]
        public int Sexo { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public int Adulto { get; set; }
        [Required]
        public string Raca { get; set; }
        [Required]
        public string CorPelagem { get; set; }
        [Required]
        public int Porte { get; set; }
        [Required]
        public int Castrado { get; set; }
        [Required]
        public int Vermifugado { get; set; }
        [Required]
        public int Raiva { get; set; }
        [Required]
        public int V10 { get; set; }
        [Required]
        public int Quadrupla { get; set; }
        [Required]
        public int Dose { get; set; }
        public int Microchip { get; set; }
        public int RGA { get; set; }
        [Required]
        public string PathFoto { get; set; }
        [Required]
        public int Adotado { get; set; }

        public enum KdAtivo
        {
            Não = 0,
            Sim = 1
        }

        public enum KdSexo
        {
            Fêmea = 0,
            Macho = 1
        }

        public enum KdEspecie
        {
            Cão = 0,
            Gato = 1
        }

        public enum KdAdulto
        {
            Filhote = 0,
            Adulto = 1
        }

        public enum KdPorte
        {
            Pequeno = 0,
            Médio = 1,
            Grande = 2
        }

        public enum KdVermifugado
        {
            Não = 0,
            Sim = 1,
            SemInformação = 2
        }
    }
}
