using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service.Home
{
    
    public class HomeService
    {
        public IList<Capa> _capas;
        private PatinhasContext _context;

        public HomeService(PatinhasContext context)
        {
            _context = context;
        }

        public void findCapas()
        {
            FindCapasTask findCapasTask = new FindCapasTask(this._context);
            findCapasTask.find();
            this._capas = findCapasTask._capas;
        }
    }
}
