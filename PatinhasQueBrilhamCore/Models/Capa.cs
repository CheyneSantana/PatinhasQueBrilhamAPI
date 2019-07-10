using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Models
{
    public class Capa
    {
        [Key]
        public int capaId { get; set; }
        [Required]
        public string path { get; set; }
        public string link { get; set; }
        [Required]
        public int ativo { get; set; }
        public enum KdAtivo
        {
            Não = 0,
            Sim = 1
        }
    }
}
