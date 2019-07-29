using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class FindAnimaisAdocaoTask
    {
        private PatinhasContext _context;
        public IEnumerable<AnimaisAdocao> animais;
        private string NomeAnimal;

        public FindAnimaisAdocaoTask(PatinhasContext context)
        {
            _context = context;
        }

        private void getAnimais()
        {
            animais = this._context.adocao.Where(w => w.Ativo == (int)AppSettings.KdAtivo.Sim);
        }

        private void getAll()
        {
            animais = this._context.adocao;
        }

        private void getNomeAnimal()
        {
            animais = this._context.adocao.Where(w => w.NomeAtual.ToUpper().Contains(this.NomeAnimal.ToUpper()));
            if (animais == null)
                throw new AppException("Nenhum animal encontrado com esse nome");
        }

        public void buscar()
        {
            this.getAnimais();
        }

        public void buscarTodos()
        {
            this.getAll();
        }

        public void buscarNome(string prNomeAnimal)
        {
            this.NomeAnimal = prNomeAnimal;
            this.getNomeAnimal();
        }
    }
}
