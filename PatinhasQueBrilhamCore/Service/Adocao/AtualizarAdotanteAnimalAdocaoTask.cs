using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilhamCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Service
{
    public class AtualizarAdotanteAnimalAdocaoTask
    {
        private AdotanteDTO adotanteDTO;
        private PatinhasContext _context;
        private int estado;

        public AtualizarAdotanteAnimalAdocaoTask(AdotanteDTO adotanteDTO, int estado, PatinhasContext context)
        {
            this.adotanteDTO = adotanteDTO;
            this.estado = estado;
            _context = context;
        }

        private void AtualizarAAA()
        {
            AdotanteAnimalAdocao adotanteAnimalAdocao = this._context.adotanteAnimalAdocao.Where(w => w.AdotanteAnimalAdocaoId == adotanteDTO.adotanteAnimalAdocaoId).FirstOrDefault();
            if (adotanteAnimalAdocao != null)
            {
                adotanteAnimalAdocao.Estado = this.estado;
                this._context.adotanteAnimalAdocao.Update(adotanteAnimalAdocao);
                this._context.SaveChanges();
            }
        }

        public void atualizar()
        {
            this.AtualizarAAA();
        }
    }
}
