using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service.Home
{
    public class FindCapasTask
    {
        private PatinhasContext _context;
        public IList<Capa> _capas;
        public FindCapasTask(PatinhasContext context)
        {
            this._context = context;
        }

        private void getCapas()
        {
            this._capas = this._context.capa.Where(w => w.ativo == (int)Capa.KdAtivo.Sim).ToList();
        }

        public void find()
        {
            this.getCapas();
        }
    }
}
