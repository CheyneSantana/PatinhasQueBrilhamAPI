using Microsoft.AspNetCore.Http;
using PatinhasQueBrilham.Helpers;
using PatinhasQueBrilham.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PatinhasQueBrilhamCore.Service
{
    public class UploadImagemTask
    {
        private IFormFile file;
        private PatinhasContext context;
        private string caminhoFotosAdocao;

        public UploadImagemTask(IFormFile file, PatinhasContext context)
        {
            this.file = file;
            this.context = context;
            //this.caminhoFotosAdocao = this.context.settings.Where(w => w.Chave == "PATH_ASSETS").Select(s => s.Valor).FirstOrDefault();
            this.caminhoFotosAdocao = "C:/Users/Cheyne/Documents/Projetos/Pessoal/PatinhasQueBrilhamAngular/ClientApp/src/assets/img/adocao/";
        }

        private void salvarFotoAssets()
        {
            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string fullPath = Path.Combine(this.caminhoFotosAdocao, fileName);

            if (File.Exists(fullPath))
                throw new AppException("Já existe uma foto com esse nome");

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        public void upload()
        {
            this.salvarFotoAssets();
        }
    }
}
