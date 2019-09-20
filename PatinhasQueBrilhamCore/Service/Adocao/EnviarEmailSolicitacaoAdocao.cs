using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilhamCore.Helpers;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatinhasQueBrilham.Service
{
    public class EnviarEmailSolicitacaoAdocao
    {
        private Adotante adotante;
        private AnimaisAdocao animal;
        private IntermediadorAdocao intermediador;
        private PatinhasContext context;

        public EnviarEmailSolicitacaoAdocao(PatinhasContext context, Adotante adotante, AnimaisAdocao animal, IntermediadorAdocao intermediador)
        {
            this.adotante = adotante;
            this.animal = animal;
            this.intermediador = intermediador;
            this.context = context;
        }

        private void enviarEmail()
        {
            string body = "Segue me anexo solicitação para adoção do(a): " + this.adotante.Nome;

            EnviarEmailTask enviarEmailTask = new EnviarEmailTask(body, "Solicitação de Adoção", this.context);
            enviarEmailTask.Enviar(this.montarDoc());
        }

        private Attachment montarDoc()
        {
            Attachment attachment;
            string pathOriginal = this.context.settings.Where(w => w.Chave == "CAMINHO_DOC").Select(s => s.Valor).FirstOrDefault();

            string pathTemp = Path.GetTempPath() + "TermoDeTutela.pdf";

            if (File.Exists(pathTemp))
                File.Delete(pathTemp);

            Document document = new Document(pathOriginal);

            #region Animal
            document.Replace("[NomeAntigo]", string.IsNullOrEmpty(this.animal.NomeAntigo) ? string.Empty : this.animal.NomeAntigo, true, true);
            document.Replace("[NomeAtual]", string.IsNullOrEmpty(this.animal.NomeAtual) ? string.Empty : this.animal.NomeAtual, true, true);
            document.Replace("[Especie]", ((AnimaisAdocao.KdEspecie)this.animal.Especie).ToString(), true, true);
            document.Replace("[SexoAnimal]", ((AnimaisAdocao.KdSexo)this.animal.Sexo).ToString(), true, true);
            document.Replace("[IdadeAnimal]", this.animal.Idade.ToString(), true, true);
            document.Replace("[Adulto]", ((AnimaisAdocao.KdAdulto)this.animal.Adulto).ToString(), true, true);
            document.Replace("[Raca]", string.IsNullOrEmpty(this.animal.Raca) ? string.Empty : this.animal.Raca, true, true);
            document.Replace("[CorPelagem]", string.IsNullOrEmpty(this.animal.CorPelagem) ? string.Empty : this.animal.CorPelagem, true, true);
            document.Replace("[Porte]", ((AnimaisAdocao.KdPorte)this.animal.Porte).ToString(), true, true);
            document.Replace("[Castrado]", ((AppSettings.KdAtivo)this.animal.Castrado).ToString(), true, true);
            document.Replace("[Vermifugado]", ((AnimaisAdocao.KdVermifugado)this.animal.Vermifugado).ToString(), true, true);
            document.Replace("[Raiva]", ((AppSettings.KdAtivo)this.animal.Raiva).ToString(), true, true);
            document.Replace("[V10]", ((AppSettings.KdAtivo)this.animal.V10).ToString(), true, true);
            document.Replace("[Quadrupla]", ((AppSettings.KdAtivo)this.animal.Quadrupla).ToString(), true, true);
            document.Replace("[Dose]", this.animal.Dose.ToString(), true, true);
            document.Replace("[Microship]", this.animal.Microchip.ToString(), true, true);
            document.Replace("[RGA]", this.animal.RGA.ToString(), true, true);
            #endregion

            #region Adotante
            document.Replace("[NomeAdotante]", string.IsNullOrEmpty(this.adotante.Nome) ? string.Empty : this.adotante.Nome, true, true);
            document.Replace("[DtNascimento]", this.adotante.DtNascimento.ToString("dd/MM/yyyy"), true, true);
            document.Replace("[RG]", string.IsNullOrEmpty(this.adotante.RG) ? string.Empty : this.adotante.RG, true, true);
            document.Replace("[CPF]", string.IsNullOrEmpty(this.adotante.CPF) ? string.Empty : this.adotante.CPF, true, true);
            document.Replace("[CEP]", string.IsNullOrEmpty(this.adotante.CEP) ? string.Empty : this.adotante.CEP, true, true);
            string endereco = string.IsNullOrEmpty(this.adotante.Endereco) ? string.Empty : this.adotante.Endereco + ", " + this.adotante.NroEndereco.ToString();
            if (!string.IsNullOrEmpty(this.adotante.Complemento)) endereco += ", " + this.adotante.Complemento;
            document.Replace("[EnderecoAdotante]", endereco, true, true);
            document.Replace("[Bairro]", string.IsNullOrEmpty(this.adotante.Bairro) ? string.Empty : this.adotante.Bairro, true, true);
            document.Replace("[Cidade]", string.IsNullOrEmpty(this.adotante.Cidade) ? string.Empty : this.adotante.Cidade, true, true);
            document.Replace("[UF]", string.IsNullOrEmpty(this.adotante.UF) ? string.Empty : this.adotante.UF, true, true);
            document.Replace("[Profissao]", string.IsNullOrEmpty(this.adotante.Profissao) ? string.Empty : this.adotante.Profissao, true, true);
            document.Replace("[TelResAdotante]", string.IsNullOrEmpty(this.adotante.TelRes) ? string.Empty : this.adotante.TelRes, true, true);
            document.Replace("[TelCelAdotante]", string.IsNullOrEmpty(this.adotante.TelCel) ? string.Empty : this.adotante.TelCel, true, true);
            #endregion

            #region Intermediario
            document.Replace("[NomeIntermediador]", string.IsNullOrEmpty(this.intermediador.Nome) ? string.Empty : this.intermediador.Nome, true, true);
            document.Replace("[EnderecoIntermediador]", string.IsNullOrEmpty(this.intermediador.Endereco) ? string.Empty : this.intermediador.Endereco + ", " + this.intermediador.NroEndereco.ToString(), true, true);
            document.Replace("[TelCelIntermediador]", string.IsNullOrEmpty(this.intermediador.TelCel) ? string.Empty : this.intermediador.TelCel, true, true);
            document.Replace("[TelResIntermediador]", string.IsNullOrEmpty(this.intermediador.TelRes) ? string.Empty : this.intermediador.TelRes, true, true);
            #endregion


            document.SaveToFile(pathTemp, FileFormat.PDF);

            attachment = new Attachment(pathTemp);

            document.Close();

            return attachment;
        }

        public void enviarSolicitacao()
        {
            this.enviarEmail();
        }
    }
}
