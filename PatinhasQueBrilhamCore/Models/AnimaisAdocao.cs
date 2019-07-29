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
        public string NomeAtual { get; set; }
        public int Especie { get; set; }
        public int Sexo { get; set; }
        public int Idade { get; set; }
        public int Adulto { get; set; }
        public string Raca { get; set; }
        public string CorPelagem { get; set; }
        public int Porte { get; set; }
        public int Castrado { get; set; }
        public int Vermifugado { get; set; }
        public int Raiva { get; set; }
        public int V10 { get; set; }
        public int Quadrupla { get; set; }
        public int Dose { get; set; }
        public int Microchip { get; set; }
        public int RGA { get; set; }
        public string PathFoto { get; set; }
        public int Ativo { get; set; }

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
