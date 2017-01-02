using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public static class Shared
    {
        private static ClassDiagramContainer istanzaCDC = null;
        public static Utente utente { get; set; }
        public static ClassDiagramContainer cdc
        {
            get
            {
                if (Shared.istanzaCDC == null)
                {
                    Shared.istanzaCDC = new ClassDiagramContainer();
                }
                return Shared.istanzaCDC;
            }
        }
    }
}
