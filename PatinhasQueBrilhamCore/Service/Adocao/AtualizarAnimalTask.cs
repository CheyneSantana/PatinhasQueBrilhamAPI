using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Service
{
    public class AtualizarAnimalTaks
    {
        private AnimaisAdocao animal;
        private PatinhasContext _context;

        public AtualizarAnimalTaks(AnimaisAdocao animal, PatinhasContext context)
        {
            this.animal = animal;
            _context = context;
        }

        private void AtualizarAnimal()
        {
            this._context.adocao.Update(this.animal);
            this._context.SaveChanges();
        }

        public void Atualizar()
        {
            this.AtualizarAnimal();
        }
    }
}
