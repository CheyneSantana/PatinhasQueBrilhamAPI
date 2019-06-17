using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class FindReservaTask
    {
        private Reserva reserva;
        public Reserva reservaRetorno;
        private PatinhasContext _context;

        public FindReservaTask(Reserva prReserva, PatinhasContext context)
        {
            reserva = prReserva;
            _context = context;
        }

        private void findByTicket()
        {
            reservaRetorno = this._context.reserva.Where(w => w.ticket == reserva.ticket && w.userId == reserva.userId).FirstOrDefault();
            if (reservaRetorno == null)
                throw new AppException("Ticket não existe ou não está atribuido ao usuário conectado");
        }

        public void buscar()
        {
            findByTicket();
        }
    }
}
