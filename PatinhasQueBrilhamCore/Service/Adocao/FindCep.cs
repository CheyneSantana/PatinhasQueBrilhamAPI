using PatinhasQueBrilham.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaCEP;

namespace PatinhasQueBrilham.Service
{
    public class FindCep
    {
        public ViaCEPResult viaCEPResult;
        private string _cep;
        public FindCep(string cep)
        {
            this._cep = cep;
        }

        private void BuscarCep()
        {
            if (!string.IsNullOrEmpty(this._cep))
                this.viaCEPResult = ViaCEPClient.Search(this._cep);
            else
                throw new AppException("Cep está vazio");
        }

        public void buscar()
        {
            this.BuscarCep();
        }
    }
}
