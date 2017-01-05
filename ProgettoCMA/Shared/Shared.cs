using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public static class Shared
    {
        private static ClassDiagramContainer istanzaCDC = null;
        public static Home home { get; set; }
        public static Utente utente { get; set; }
        public static Commessa commessaAttiva { get; set; }
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
        public static DialogResult messageBox(String text, String caption = "MessageBox", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
    }
}
