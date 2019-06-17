using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service.Footer
{
    public class FooterService
    {
        private PatinhasContext _context;
        public IList<Apoio> apoios;

        public FooterService(PatinhasContext context)
        {
            _context = context;
        }

        public void GetApoios()
        {
            FindApoios findApoios = new FindApoios(this._context);
            findApoios.find();
            this.apoios = findApoios.apoios;
        }
    }
}
