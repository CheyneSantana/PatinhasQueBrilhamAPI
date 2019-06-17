using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class CancelarReserva
    {
        private Reserva _reserva;
        private PatinhasContext _context;

        public CancelarReserva(Reserva reserva, PatinhasContext context)
        {
            this._reserva = reserva;
            this._context = context;
        }

        private void alterarEstado()
        {
            if (this._reserva.estado != (int)Reserva.KdEstado.Cancelado)
                this._reserva.estado = (int)Reserva.KdEstado.Cancelado;

            this._context.reserva.Update(this._reserva);
            this._context.SaveChanges();
        }

        public void Cancelar()
        {
            alterarEstado();
        }
    }
}
