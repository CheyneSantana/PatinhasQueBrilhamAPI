using AutoMapper;
using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Service
{
    public class SolicitarAdocaoTask
    {
        private PatinhasContext _context;
        private FormularioDTO formulario;
        private AnimaisAdocao animal;
        private IMapper _mapper;
        private Adotante adotante;

        public SolicitarAdocaoTask(PatinhasContext context, FormularioDTO formulario, IMapper mapper)
        {
            _context = context;
            this.formulario = formulario;
            _mapper = mapper;
        }

        private void getAnimal()
        {
            this.animal = this._context.adocao.Where(w => w.AnimaisAdocaoId == this.formulario.AnimaisAdocaoId).FirstOrDefault();
        }

        private void createAdotante()
        {
            Adotante adotante = this._context.adotante.Where(w => w.CPF == this.formulario.CPF).FirstOrDefault();
            if (adotante == null)
            {
                this.adotante = this._mapper.Map<Adotante>(this.formulario);
                this._context.adotante.Add(this.adotante);
                this._context.SaveChanges();
            }
            else
                this.adotante = adotante;
        }

        private void createAdotanteAnimal()
        {
            AdotanteAnimalAdocao adotanteAnimalAdocao = this._context.adotanteAnimalAdocao.Where(w => w.AdotanteId == this.adotante.AdotanteId && w.AnimaisAdocaoId == this.animal.AnimaisAdocaoId).FirstOrDefault();
            if (adotanteAnimalAdocao == null)
            {
                adotanteAnimalAdocao = new AdotanteAnimalAdocao();
                adotanteAnimalAdocao.AdotanteId = this.adotante.AdotanteId;
                adotanteAnimalAdocao.AnimaisAdocaoId = this.animal.AnimaisAdocaoId;
                adotanteAnimalAdocao.Estado = (int)AdotanteAnimalAdocao.KdEstado.Enviado;
                this._context.adotanteAnimalAdocao.Add(adotanteAnimalAdocao);
                this._context.SaveChanges();
            }
        }

        private IntermediadorAdocao getIntemediador()
        {
            FindIntermediadorTask findIntermediadorTask = new FindIntermediadorTask(this._context);
            findIntermediadorTask.find();
            return findIntermediadorTask.intermediador;
        }

        private void enviarEmail()
        {
            EnviarEmailSolicitacaoAdocao enviarEmail = new EnviarEmailSolicitacaoAdocao(this._context, this.adotante, this.animal, this.getIntemediador());
            enviarEmail.enviarSolicitacao();
        }

        public void Solicitar()
        {
            this.getAnimal();
            this.createAdotante();
            this.createAdotanteAnimal();
            this.enviarEmail();
        }
    }
}
