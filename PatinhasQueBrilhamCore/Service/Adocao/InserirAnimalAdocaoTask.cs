using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Service
{
    public class InserirAnimalAdocaoTask
    {
        private AnimaisAdocao animal;
        private PatinhasContext context;

        public InserirAnimalAdocaoTask(AnimaisAdocao animal, PatinhasContext context)
        {
            this.animal = animal;
            this.context = context;
        }

        private void salvar()
        {
            this.context.adocao.Add(this.animal);
        }

        public void inserir()
        {
            this.salvar();
        }
    }
}
