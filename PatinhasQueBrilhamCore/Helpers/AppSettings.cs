using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public enum KdAtivo
        {
            Não = 0,
            Sim = 1
        }
    }
}
