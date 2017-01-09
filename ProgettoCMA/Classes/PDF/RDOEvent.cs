using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using static iTextSharp.text.Font;

namespace ProgettoCMA
{
    class RDOEvent : iTextSharp.text.pdf.PdfPageEventHelper
    {
        public Font ftTitle = new Font(FontFamily.TIMES_ROMAN, 16, Font.BOLD);
        public Font ftSubTitle = new Font(FontFamily.TIMES_ROMAN, 12, Font.BOLD);
        public Font ftParagraph = new Font(FontFamily.TIMES_ROMAN, 10);
        public Font ftParagraphBold = new Font(FontFamily.TIMES_ROMAN, 14, Font.BOLD);
        public Font ftSmall = new Font(FontFamily.TIMES_ROMAN, 8);
        RDO rdo;
        
        public RDOEvent(RDO rdo)
        {
            this.rdo = rdo;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);


            ColumnText ct = new ColumnText(writer.DirectContent);
            Rectangle r = new Rectangle(30, PageSize.A4.Height - 40, PageSize.A4.Width - 30, PageSize.A4.Height - 320);
            ct.SetSimpleColumn(r);
            Image img = Image.GetInstance(new Uri("C:\\Users\\angelotm\\Source\\Repos\\sistema9001\\Immagine.png"));



            //Contiene informazioni sul tipo di documento
            PDFGestioneTabelle tbTipoDoc = new PDFGestioneTabelle();
            tbTipoDoc.bordi = false;
            tbTipoDoc.addElementInList(this.CreaParagrafo("RICHIESTA DI OFFERTA", ftTitle, Element.ALIGN_RIGHT));
            tbTipoDoc.addElementInList(this.CreaParagrafo("RDO_" + this.rdo.Codice, ftSmall, Element.ALIGN_RIGHT));

            //Contiene Immagine e tipo di documento
            PDFGestioneTabelle tbIntestazione = new PDFGestioneTabelle();
            tbIntestazione.bordi = false;
            tbIntestazione.addElementInList(img);
            tbIntestazione.addElementInList(tbTipoDoc.CreaTabella(1));
            ct.AddElement(tbIntestazione.CreaTabella(2));
            ct.AddElement(Chunk.NEWLINE);

            //Tabbella con informazione azienda
            PDFGestioneTabelle tbIntestazionesin = new PDFGestioneTabelle();
            tbIntestazionesin.bordi = false;
            tbIntestazionesin.addElementInList(this.CreaParagrafo("CMA s.r.l", ftSubTitle));
            tbIntestazionesin.addElementInList(this.CreaParagrafo("Via dei Gelsomini, 14", ftParagraph));
            tbIntestazionesin.addElementInList(this.CreaParagrafo("80029 - Sant'Antimo (NA)", ftParagraph));
            tbIntestazionesin.addElementInList(this.CreaParagrafo("P. IVA 06823661217", ftParagraph));

            //Tabella informazioni Fornitore
            PDFGestioneTabelle tbIntestazionedes = new PDFGestioneTabelle();
            tbIntestazionedes.bordi = false;
            tbIntestazionedes.addElementInList(this.CreaParagrafo("Spett.le", ftSubTitle));
            tbIntestazionedes.addElementInList(this.CreaParagrafo(this.rdo.Fornitore.Ragione, ftSubTitle));
            tbIntestazionedes.addElementInList(this.CreaParagrafo(this.rdo.Fornitore.Indirizzo.Via, ftParagraph));
            tbIntestazionedes.addElementInList(this.CreaParagrafo(this.rdo.Fornitore.Indirizzo.Cap + " " + this.rdo.Fornitore.Indirizzo.Citta, ftParagraph));
            tbIntestazionedes.addElementInList(this.CreaParagrafo(this.rdo.Fornitore.Piva, ftParagraph));

            //tabella info fornitore e azienda
            tbIntestazione = new PDFGestioneTabelle();
            tbIntestazione.addElementInList(tbIntestazionesin.CreaTabella(1));
            tbIntestazione.addElementInList(tbIntestazionedes.CreaTabella(1));
            ct.AddElement(tbIntestazione.CreaTabella(2));
            ct.AddElement(Chunk.NEWLINE);

            //Tabella riferimenti
            tbIntestazione = new PDFGestioneTabelle();
            tbIntestazione.addElementInList(this.CreaParagrafo("Data    " + this.rdo.Creazione, ftSmall, Element.ALIGN_LEFT));
            tbIntestazione.addElementInList(this.CreaParagrafo("Prego citare nostro rif. su vs. Offerta", ftSmall));
            ct.AddElement(tbIntestazione.CreaTabella(2));

            ct.Go();


            r = new Rectangle(30, 40, PageSize.A4.Width - 30, 200);
            ct.SetSimpleColumn(r);

            float[] fl = { 6, 3 };
            //Creo tabella note
            tbIntestazione = new PDFGestioneTabelle();
            tbIntestazione.addElementInList(this.CreaParagrafo("Condizioni particolari:", ftParagraphBold, Element.ALIGN_CENTER));
            tbIntestazione.addElementInList(this.CreaParagrafo("Elaborato ACQ", ftParagraphBold, Element.ALIGN_CENTER));
            tbIntestazione.addElementInList(this.CreaParagrafo(this.rdo.Lista_RDO.CondizioniParticolari, ftParagraph, Element.ALIGN_CENTER));
            tbIntestazione.addElementInList(this.CreaParagrafo(Shared.utente.Nome + " " + Shared.utente.Cognome, ftParagraph, Element.ALIGN_CENTER));
            ct.AddElement(tbIntestazione.CreaTabella(fl, 50, 2));
            ct.AddElement(Chunk.NEWLINE);


            //Creo tabella numero pagine e versione documento
            tbIntestazione = new PDFGestioneTabelle();
            tbIntestazione.addElementInList(this.CreaParagrafo("RDO V1", ftSmall, Element.ALIGN_LEFT));
            tbIntestazione.addElementInList(this.CreaParagrafo("Pag    " + document.PageNumber.ToString(), ftSmall, Element.ALIGN_LEFT));
            ct.AddElement(tbIntestazione.CreaTabella(2));

            ct.Go();


        }

        public Paragraph CreaParagrafo(String testo, Font font, int allinea = Element.ALIGN_LEFT, int approdo = 10)
        {
            Paragraph p = new Paragraph();
            p.Add(testo);
            p.Alignment = allinea;
            p.Leading = approdo;
            p.Font = font;
            return p;
        }

    }
}
