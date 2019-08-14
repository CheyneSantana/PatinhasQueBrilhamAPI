using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatinhasQueBrilham.DTO;
using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilhamCore.DTO;
using PatinhasQueBrilhamCore.Service;
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
        public IEnumerable<AdotanteDTO> adotanteDTOs;

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
            findAnimaisAdocao.buscarTodos();
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

        public void ExcluirAnimal(int prAnimalId)
        {
            ExcluirAnimalAdocaoTask excluirAnimalAdocaoTask = new ExcluirAnimalAdocaoTask(prAnimalId, this._context);
            excluirAnimalAdocaoTask.excluir();
        }

        public void AtualizarAnimal(AnimaisAdocao animal)
        {
            AtualizarAnimalTaks atualizarAnimal = new AtualizarAnimalTaks(animal, this._context);
            atualizarAnimal.Atualizar();
        }

        public void FindAdotantes(AnimaisAdocao animal)
        {
            FindAdotanteAnimalTask findAdotanteAnimal = new FindAdotanteAnimalTask(animal, this._context);
            findAdotanteAnimal.Find();
            this.adotanteDTOs = findAdotanteAnimal.adotantes;
        }

        public void AtualizarSolicitacao(AdotanteDTO adotanteDTO, int estado)
        {
            AtualizarAdotanteAnimalAdocaoTask atualizarAdotanteAnimalAdocaoTask = new AtualizarAdotanteAnimalAdocaoTask(adotanteDTO, estado, this._context);
            atualizarAdotanteAnimalAdocaoTask.atualizar();
        }

        public void InserirAnimalAdocao(AnimaisAdocao animal)
        {
            InserirAnimalAdocaoTask inserirAnimalAdocaoTask = new InserirAnimalAdocaoTask(animal, this._context);
            inserirAnimalAdocaoTask.inserir();
        }

        public void UploadImagem(IFormFile file)
        {
            UploadImagemTask uploadImagemTask = new UploadImagemTask(file, this._context);
            uploadImagemTask.upload();
        }
    }
}
