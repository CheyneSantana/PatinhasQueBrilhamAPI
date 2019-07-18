using AutoMapper;
using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaCEP;

namespace PatinhasQueBrilham.Service
{
    public class AdocaoService
    {
        private PatinhasContext _context;
        public IEnumerable<AnimaisAdocao> animais;
        public ViaCEPResult viaCEPResult;
        public IntermediadorAdocao intermediador;

        public AdocaoService(PatinhasContext context)
        {
            _context = context;
        }

        public void FindAnimaisAdocao()
        {
            FindAnimaisAdocaoTask findAnimaisAdocao = new FindAnimaisAdocaoTask(this._context);
            findAnimaisAdocao.buscar();
            this.animais = findAnimaisAdocao.animais;
        }

        public void FindAllAnimais()
        {
            FindAnimaisAdocaoTask findAnimaisAdocao = new FindAnimaisAdocaoTask(this._context);
            findAnimaisAdocao.buscar();
            this.animais = findAnimaisAdocao.animais;
        }

        public void findNomeAnimal(string prNomeAnimal)
        {
            FindAnimaisAdocaoTask findAnimaisAdocao = new FindAnimaisAdocaoTask(this._context);
            findAnimaisAdocao.buscarNome(prNomeAnimal);
            this.animais = findAnimaisAdocao.animais;
        }

        public void FindCep(string cep)
        {
            FindCep findCep = new FindCep(cep);
            findCep.buscar();
            this.viaCEPResult = findCep.viaCEPResult;
        }

        public void FindIntermediador()
        {
            FindIntermediadorTask findIntermediadorTask = new FindIntermediadorTask(this._context);
            findIntermediadorTask.find();
            this.intermediador = findIntermediadorTask.intermediador;
        }

        public void EnviarFormularioAdocao(FormularioDTO formulario, IMapper mapper)
        {
            SolicitarAdocaoTask solicitarAdocaoTask = new SolicitarAdocaoTask(this._context, formulario, mapper);
            solicitarAdocaoTask.Solicitar();
        }
    }
}
