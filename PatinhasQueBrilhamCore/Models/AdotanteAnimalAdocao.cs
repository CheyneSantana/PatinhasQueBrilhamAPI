using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Models
{
    public class AdotanteAnimalAdocao
    {
        [Key]
        public int AdotanteAnimalAdocaoId { get; set; }
        [Required]
        public int AdotanteId { get; set; }
        [Required]
        public int AnimaisAdocaoId { get; set; }
        public int Estado { get; set; }

        public enum KdEstado
        {
            Enviado = 0,
            Finalizado = 1,
            Cancelado = 2
        }
    }
}
