using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class SalvarReservaTask
    {
        private PatinhasContext _context;
        private Reserva _reserva;
        public SalvarReservaTask(Reserva reserva, PatinhasContext context)
        {
            _reserva = reserva;
            _context = context;
        }

        private void salvar()
        {
            _reserva.ticket = this.GenerateNextTicket();
            _reserva.estado = (int)Reserva.KdEstado.Criado;

            this._context.reserva.Add(_reserva);
            this._context.SaveChanges();
        }

        private int GenerateNextTicket()
        {
            int lResult = 0;
            int lastTicket = this._context.reserva.Select(s => s.ticket).OrderByDescending(o => o).FirstOrDefault();
            int lastNumbers = 0;
            if (lastTicket != 0)
                lastNumbers = int.Parse(lastTicket.ToString().Substring(4, 4)) + 1;

            if (lastTicket.ToString().Contains(DateTime.Now.Year.ToString()))
                lResult = int.Parse(DateTime.Now.Year.ToString() + (lastNumbers.ToString().PadLeft(4,'0')));
            else
                lResult = int.Parse(DateTime.Now.Year.ToString() + "0001");

            return lResult;
        }

        public void SalvarReserva()
        {
            salvar();
        }
    }
}
