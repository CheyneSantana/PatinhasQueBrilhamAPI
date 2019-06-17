using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class FindIntermediadorTask
    {
        private PatinhasContext _context;
        public IntermediadorAdocao intermediador;

        public FindIntermediadorTask(PatinhasContext context)
        {
            _context = context;
        }

        private void getIntermediador()
        {
            this.intermediador = this._context.intermediador.Where(w => w.Ativo == (int)AppSettings.KdAtivo.Sim).FirstOrDefault();
        }

        public void find()
        {
            this.getIntermediador();
        }
    }
}
