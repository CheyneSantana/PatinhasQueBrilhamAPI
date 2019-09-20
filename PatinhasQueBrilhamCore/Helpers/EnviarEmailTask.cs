using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Helpers
{
    public class EnviarEmailTask
    {
        private MailMessage _message;
        private PatinhasContext _context;
        private string _newPassword;
        private string emailTo;
        private string emailFrom;
        private string senhaEmail;
        private string smtpServer;
        private string smtpPort;
        private string body;
        private string subject;
        private Attachment attachment;

        public EnviarEmailTask(string body, string subject, PatinhasContext context)
        {
            _context = context;
            this.body = body;
            this.subject = subject;
            this.emailTo = this._context.settings.Where(w => w.Chave == "EMAIL_TO").Select(s => s.Valor).FirstOrDefault();
            this.emailFrom = this._context.settings.Where(w => w.Chave == "EMAIL_FROM").Select(s => s.Valor).FirstOrDefault();
            this.senhaEmail = this._context.settings.Where(w => w.Chave == "EMAIL_SENHA").Select(s => s.Valor).FirstOrDefault();
            this.smtpServer = this._context.settings.Where(w => w.Chave == "SMTP_SERVER").Select(s => s.Valor).FirstOrDefault();
            this.smtpPort = this._context.settings.Where(w => w.Chave == "SMTP_PORT").Select(s => s.Valor).FirstOrDefault();
        }

        private void send()
        {
            MailMessage mailMessage = new MailMessage(emailFrom, emailTo);

            mailMessage.Body = this.body;
            mailMessage.Subject = this.subject;
            if (this.attachment != null)
                mailMessage.Attachments.Add(this.attachment);

            using (SmtpClient client = new SmtpClient(this.smtpServer, int.Parse(this.smtpPort)))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential(this.emailFrom, this.senhaEmail);

                client.Send(mailMessage);

                client.Dispose();
                mailMessage.Dispose();
            }
        }

        /// <summary>
        /// Envia email para o usuário padrão
        /// </summary>
        public void Enviar()
        {
            this.send();
        }

        /// <summary>
        /// Para enviar email para outro usuário
        /// </summary>
        /// <param name="emailTo"></param>
        public void Enviar(string emailTo)
        {
            this.emailTo = emailTo;
            this.send();
        }

        /// <summary>
        /// Para envios com anexo para o usário padrão
        /// </summary>
        /// <param name="attachment"></param>
        public void Enviar(Attachment attachment)
        {
            this.attachment = attachment;

            this.send();
        }
    }
}
