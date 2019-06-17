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

        public FindAnimaisAdocaoTask(PatinhasContext context)
        {
            _context = context;
        }

        private void getAnimais()
        {
            animais = this._context.adocao.Where(w => w.Adotado == (int)AppSettings.KdAtivo.Não);
        }

        public void buscar()
        {
            this.getAnimais();
        }
    }
}
