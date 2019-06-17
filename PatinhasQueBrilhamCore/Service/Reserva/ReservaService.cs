using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class ReservaService
    {
        private PatinhasContext _context;
        public Reserva _reserva;
        public ReservaService(PatinhasContext context)
        {
            this._context = context;
        }

        public void EnviarEmailReserva(Reserva reserva)
        {
            EnviarEmailReservaTask enviarEmailReservaTask = new EnviarEmailReservaTask(reserva, this._context);
            enviarEmailReservaTask.EnviarEmailReserva();
            enviarEmailReservaTask.EnviarEmailConfirmacaoReserva();
        }

        public void EnviarEmailCancelamento(Reserva reserva)
        {
            EnviarEmailReservaTask enviarEmailReservaTask = new EnviarEmailReservaTask(reserva, this._context);
            enviarEmailReservaTask.EnviarEmailCancelamento();
        }

        public void EnviarEmailAlteracao(Reserva reserva)
        {
            EnviarEmailReservaTask enviarEmailReservaTask = new EnviarEmailReservaTask(reserva, this._context);
            enviarEmailReservaTask.EnviarEmailAlteracao(this._context);
        }

        public void Salvar(Reserva reserva)
        {
            SalvarReservaTask salvarReservaTask = new SalvarReservaTask(reserva, this._context);
            salvarReservaTask.SalvarReserva();
        }

        public void BuscarReserva(Reserva prReserva)
        {
            FindReservaTask findReservaTask = new FindReservaTask(prReserva, this._context);
            findReservaTask.buscar();
            _reserva = findReservaTask.reservaRetorno;
        }

        public void CancelarReserva(Reserva reserva)
        {
            CancelarReserva cancelarReserva = new CancelarReserva(reserva, this._context);
            cancelarReserva.Cancelar();
        }

        public void AtualizarReserva(Reserva reserva)
        {
            AlterarReservaTask alterarReserva = new AlterarReservaTask(reserva, this._context);
            alterarReserva.Alterar();
        }
    }
}
