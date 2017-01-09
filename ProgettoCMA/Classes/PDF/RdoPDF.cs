using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using static iTextSharp.text.Font;
using System.Diagnostics;

namespace ProgettoCMA
{
    class RdoPDF
    {

        public RdoPDF(RDO rdo)
        {
            Document doc = new Document(PageSize.A4, 30, 30, 290, 220);
            String name = "RDO_" + rdo.Codice + ".pdf";
            FileStream f = File.Create(name);
            PdfWriter wrt = PdfWriter.GetInstance(doc, f);
            PDFGestioneTabelle mainTable = new PDFGestioneTabelle();
            float[] dim = { 1, 5, 1, 2 };
            RDOEvent t = new RDOEvent(rdo);
            int count = 1;
            wrt.PageEvent = t;
            doc.Open();

            mainTable.addElementInList(t.CreaParagrafo("N°", t.ftParagraphBold, Element.ALIGN_CENTER));
            mainTable.addElementInList(t.CreaParagrafo("DESCRIZIONE", t.ftParagraphBold, Element.ALIGN_CENTER));
            mainTable.addElementInList(t.CreaParagrafo("U.M.", t.ftParagraphBold, Element.ALIGN_CENTER));
            mainTable.addElementInList(t.CreaParagrafo("QUANTITA", t.ftParagraphBold, Element.ALIGN_CENTER));
            foreach (var item in rdo.RDO_Composizione)
            {
                mainTable.addElementInList(t.CreaParagrafo(count.ToString(), t.ftSmall, Element.ALIGN_CENTER, 8));
                mainTable.addElementInList(t.CreaParagrafo(item.Lista_RDO_Composizione.Descrizione, t.ftSmall, Element.ALIGN_LEFT, 8));
                mainTable.addElementInList(t.CreaParagrafo(item.Lista_RDO_Composizione.UnitaMisura, t.ftSmall, Element.ALIGN_CENTER, 8));
                mainTable.addElementInList(t.CreaParagrafo(item.Lista_RDO_Composizione.Quantita.ToString(), t.ftSmall, Element.ALIGN_CENTER, 8));
                count++;
            }

            doc.Add(mainTable.CreaTabella(dim));
            doc.Close();
            Process.Start(name);
        }

    }
}
