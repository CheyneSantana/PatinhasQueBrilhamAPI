using Microsoft.EntityFrameworkCore;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilhamCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class EnviarEmailReservaTask
    {
        private Reserva _reserva;
        private PatinhasContext _context;

        public EnviarEmailReservaTask(Reserva reserva, PatinhasContext context)
        {
            _reserva = reserva;
            this._context = context;
        }

        private string montarBodyReserva()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("O(A): " + this._reserva.nomeDono + " deseja realizar uma reserva");
            sb.AppendLine("para o(a) " + this._reserva.nomePet + " um(a) " + this._reserva.tipoPet + " da raça " + this._reserva.raca);
            sb.AppendLine("com " + this._reserva.idadePet + " de idade e porte " + this._reserva.portePet);
            sb.AppendLine("Ticket da reserva: " + this._reserva.ticket);
            sb.AppendLine("Contatos: ");
            if (!string.IsNullOrEmpty(this._reserva.residencial))
                sb.AppendLine("Telefone Residencial: " + this._reserva.residencial);
            sb.AppendLine("Telefone Celular: " + this._reserva.celular);
            sb.AppendLine("Email: " + this._reserva.email);
            sb.AppendLine("Data da reserva: " + this._reserva.fromDate);
            if (this._reserva.toDate != null && !this._reserva.toDate.ToString().Contains("0001-01-01"))
                sb.AppendLine("Até o dia: " + this._reserva.toDate);
            if (!string.IsNullOrEmpty(this._reserva.comentario))
            {
                sb.AppendLine("Detalhes sobre o pet: ");
                sb.AppendLine(this._reserva.comentario);
            }

            return sb.ToString();
        }

        private string montarBodyCancelamento()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("O(A): " + this._reserva.nomeDono + " cancelou a reserva");
            sb.AppendLine("Numero do Ticket: " + this._reserva.ticket);
            sb.AppendLine("Data da reserva: " + this._reserva.fromDate);
            if (this._reserva.toDate != null && !this._reserva.toDate.ToString().Contains("0001-01-01"))
                sb.AppendLine("Até o dia: " + this._reserva.toDate);

            return sb.ToString();
        }

        private string montarBodyAlteracao()
        {
            Reserva reservaOld = this._context.reserva.Where(w => w.ticket == this._reserva.ticket).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A reserva " + this._reserva.ticket + " sofreu a(s) seguinte(s) alteração(ões)");
            if (this._reserva.nomeDono != reservaOld.nomeDono)
                sb.AppendLine("Antigo nome do dono: " + reservaOld.nomeDono + " novo nome: " + this._reserva.nomeDono);

            if (this._reserva.nomePet != reservaOld.nomePet)
                sb.AppendLine("Antigo nome do pet: " + reservaOld.nomePet + " novo nome: " + this._reserva.nomePet);

            if (this._reserva.fromDate.Date != reservaOld.fromDate.Date)
                sb.AppendLine("Antiga data inicial: " + reservaOld.fromDate + " nova data inicial: " + this._reserva.fromDate);

            if (this._reserva.toDate != null && !this._reserva.toDate.ToString().Contains("0001-01-01"))
            {
                if (reservaOld.toDate != null && !reservaOld.toDate.ToString().Contains("0001-01-01") && this._reserva.toDate.Date != reservaOld.toDate.Date)
                    sb.AppendLine("Antiga data final: " + reservaOld.toDate + " nova data final: " + this._reserva.toDate);
                else
                    sb.AppendLine("Adicionou uma data final: " + this._reserva.toDate);
            }
            else if (reservaOld.toDate != null && !reservaOld.toDate.ToString().Contains("0001-01-01"))
                sb.AppendLine("Removeu a data final");

            if (this._reserva.tipoPet != reservaOld.tipoPet)
                sb.AppendLine("Antigo tipo pet: " + reservaOld.tipoPet + " novo tipo pet: " + this._reserva.tipoPet);

            if (this._reserva.raca != reservaOld.raca)
                sb.AppendLine("Antiga raça: " + reservaOld.raca + " nova raça: " + this._reserva.raca);

            if (this._reserva.idadePet != reservaOld.idadePet)
                sb.AppendLine("Antiga idade: " + reservaOld.idadePet + " nova idade: " + this._reserva.idadePet);

            if (this._reserva.portePet != reservaOld.portePet)
                sb.AppendLine("Antigo porte " + reservaOld.portePet + " novo porte " + this._reserva.portePet);

            if (!string.IsNullOrEmpty(this._reserva.residencial))
            {
                if (!string.IsNullOrEmpty(reservaOld.residencial))
                    sb.AppendLine("Antigo telefone residencial: " + reservaOld.residencial + " novo telefone: " + this._reserva.residencial);
                else
                    sb.AppendLine("Adicionou um telefone residecial: " + this._reserva.residencial);
            }
            else if (!string.IsNullOrEmpty(reservaOld.residencial))
                sb.AppendLine("Removeu o telefone residencial");

            if (this._reserva.celular != reservaOld.celular)
                sb.AppendLine("Antigo telefone celular: " + reservaOld.celular + " novo celular: " + this._reserva.celular);

            if (this._reserva.email != reservaOld.email)
                sb.AppendLine("Antigo email: " + reservaOld.email + " novo email: " + this._reserva.email);

            if (this._reserva.comentario != reservaOld.comentario)
                sb.AppendLine("Novo comentário: " + this._reserva.comentario);

            return sb.ToString();
        }

        private string montarBodyConfirmacaoReserva()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sua reserva no hotel Patinhas que Brilham foi enviado com sucesso");
            sb.AppendLine("O ticket da reserva é " + this._reserva.ticket);
            sb.AppendLine("Caso deseje alterar ou cancelar a reserva, acesse nosso site e insira o ticket");

            return sb.ToString();
        }

        private string montarBodyConfirmacaoCancelamento()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sua reserva no hotel Patinhas que Brilham foi cancelada com sucesso");
            sb.AppendLine("O ticket da reserva é " + this._reserva.ticket);

            return sb.ToString();
        }
        
        public void EnviarEmailReserva()
        {
            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(this.montarBodyReserva(), "Solicitação agendamento hotel", this._context);
            enviarEmailTask.Enviar();
        }

        public void EnviarEmailCancelamento()
        {
            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(this.montarBodyCancelamento(), "Cancelamento de reserva", this._context);
            enviarEmailTask.Enviar();
        }

        public void EnviarEmailAlteracao(PatinhasContext context)
        {
            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(this.montarBodyAlteracao(), "Alteração de reserva", this._context);
            enviarEmailTask.Enviar();

        }

        public void EnviarEmailConfirmacaoReserva()
        {
            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(this.montarBodyConfirmacaoReserva(), "Confirmação reserva Hotel Ong Patinhas que Brilham", this._context);
            enviarEmailTask.Enviar(this._reserva.email);
        }

        public void EnviarEmailConfirmacaoCancelamento()
        {
            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(this.montarBodyConfirmacaoReserva(), "Confirmação cancelamento reserva Hotel Ong Patinhas que Brilham", this._context);
            enviarEmailTask.Enviar(this._reserva.email);
        }
    }
}
