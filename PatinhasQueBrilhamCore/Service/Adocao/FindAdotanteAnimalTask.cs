using PatinhasQueBrilham.Models;
using PatinhasQueBrilham.Repository;
using PatinhasQueBrilhamCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Service
{
    public class FindAdotanteAnimalTask
    {
        private int animaisAdocaoId;
        private PatinhasContext _context;
        public IList<AdotanteDTO> adotantes;

        public FindAdotanteAnimalTask(int animaisAdocaoId, PatinhasContext context)
        {
            this.animaisAdocaoId = animaisAdocaoId;
            _context = context;
            this.adotantes = new List<AdotanteDTO>();
        }

        private void getAdotantes()
        {
            IEnumerable<AdotanteAnimalAdocao> adotanteAnimalAdocao;
            adotanteAnimalAdocao = this._context.adotanteAnimalAdocao.Where(w => w.AnimaisAdocaoId == this.animaisAdocaoId);

            foreach (AdotanteAnimalAdocao adotanteAnimal in adotanteAnimalAdocao)
            {
                Adotante adotante = this._context.adotante.Where(w => w.AdotanteId == adotanteAnimal.AdotanteId).FirstOrDefault();
                if (adotante != null)
                {
                    AdotanteDTO adotanteDTO = new AdotanteDTO()
                    {
                        adotanteId = adotante.AdotanteId,
                        adotanteAnimalAdocaoId = adotanteAnimal.AdotanteAnimalAdocaoId,
                        bairro = adotante.Bairro,
                        cep = adotante.CEP,
                        cidade = adotante.Cidade,
                        complemento = adotante.Complemento,
                        cpf = adotante.CPF,
                        dtNascimento = adotante.DtNascimento,
                        endereco = adotante.Endereco,
                        estado = adotanteAnimal.Estado,
                        nome = adotante.Nome,
                        nroEndereco = adotante.NroEndereco,
                        profissao = adotante.Profissao,
                        rg = adotante.RG,
                        telCel = adotante.TelCel,
                        telRes = adotante.TelRes,
                        uf = adotante.UF
                    };

                    this.adotantes.Add(adotanteDTO);
                }
            }
        }

        public void Find()
        {
            this.getAdotantes();
        }
    }
}
