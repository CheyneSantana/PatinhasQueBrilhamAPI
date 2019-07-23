using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Service
{
    public class ExcluirAnimalAdocaoTask
    {
        private AnimaisAdocao animal;
        private PatinhasContext _context;
        private int animalId;

        public ExcluirAnimalAdocaoTask(int prAnimalId, PatinhasContext context)
        {
            this.animalId = prAnimalId;
            _context = context;
        }

        private void excluirAnimal()
        {
            this.animal = this._context.adocao.Where(w => w.AnimaisAdocaoId == this.animalId).FirstOrDefault();
            if (this.animal != null)
            {
                this._context.adocao.Remove(this.animal);
                this._context.SaveChanges();
            }
            else
                throw new AppException("Animal não encontrado!");
        }

        public void excluir()
        {
            this.excluirAnimal();
        }
    }
}
