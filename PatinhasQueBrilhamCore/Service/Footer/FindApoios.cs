using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service.Footer
{
    public class FindApoios
    {
        private PatinhasContext _context;
        public IList<Apoio> apoios;

        public FindApoios(PatinhasContext context)
        {
            _context = context;
        }

        private void getApoios()
        {
            this.apoios = this._context.apoio.Where(w => w.ativo == (int)AppSettings.KdAtivo.Sim).ToList();
        }

        public void find()
        {
            this.getApoios();
        }

    }
}
