using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class AlterarReservaTask
    {
        private Reserva _reserva;
        private PatinhasContext _context;

        public AlterarReservaTask(Reserva reserva, PatinhasContext context)
        {
            _reserva = reserva;
            _context = context;
        }

        private void salvarReserva()
        {
            if (this._reserva != null)
            {
                this._context.Update(this._reserva);
                this._context.SaveChanges();
            }
        }

        public void Alterar()
        {
            salvarReserva();
        }
    }
}
