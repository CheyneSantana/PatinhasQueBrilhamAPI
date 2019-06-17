using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Models
{
    public class Reserva
    {
        [Key]
        public int reservaId { get; set; }
        [Required]
        public string nomeDono { get; set; }
        [Required]
        public string nomePet { get; set; }
        [Required]
        public string tipoPet { get; set; }
        [Required]
        public string raca { get; set; }
        [Required]
        public int idadePet { get; set; }
        [Required]
        public string portePet { get; set; }
        public string residencial { get; set; }
        [Required]
        public string celular { get; set; }
        [Required]
        public string email { get; set; }
        public string comentario { get; set; }
        [Required]
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        [Required]
        public int ticket { get; set; }
        public int estado { get; set; }
        [Required]
        public int userId { get; set; }


        public enum KdEstado
        {
            Criado = 0,
            Usado = 1,
            Cancelado = 2
        }
    }
}
