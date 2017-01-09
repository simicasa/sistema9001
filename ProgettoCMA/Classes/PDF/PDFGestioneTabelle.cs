using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using static iTextSharp.text.Font;

namespace ProgettoCMA.Classes.PDF
{
    public class PDFGestioneTabelle
    {

        private List<IElement> ContenitoreTabella;
        private PdfPTable Tabella { get; set; }
        public bool bordi { get; set; }

        public PDFGestioneTabelle()
        {
            ContenitoreTabella = new List<IElement>();
            this.bordi = true;
        }

        public void addElementInList(IElement elemento)
        {
            this.ContenitoreTabella.Add(elemento);
        }


        public PdfPTable CreaTabella(float[] dimcolonne, int width = 100)
        {
            this.Tabella = new PdfPTable(dimcolonne);

            Tabella.WidthPercentage = width;
            Tabella.SpacingBefore = 0;
            Tabella.SpacingAfter = 0;

            riempiTabella();

            return Tabella;
        }

        public PdfPTable CreaTabella(int NColonne, int width = 100)
        {
            this.Tabella = new PdfPTable(NColonne);

            Tabella.WidthPercentage = width;
            Tabella.SpacingBefore = 0;
            Tabella.SpacingAfter = 0;

            riempiTabella();

            return Tabella;
        }

        public PdfPTable CreaTabella(int NColonne, int dimensioni2Col, int numeroCelleConDimDiverse, int width = 100)
        {
            this.Tabella = new PdfPTable(NColonne);

            Tabella.WidthPercentage = width;
            Tabella.SpacingBefore = 0;
            Tabella.SpacingAfter = 0;

            riempiTabella(dimensioni2Col, numeroCelleConDimDiverse);

            return Tabella;
        }

        public PdfPTable CreaTabella(float[] dimcolonne, int dimensioni2Col, int numeroCelleConDimDiverse, int width = 100)
        {
            this.Tabella = new PdfPTable(dimcolonne);

            Tabella.WidthPercentage = width;
            Tabella.SpacingBefore = 0;
            Tabella.SpacingAfter = 0;

            riempiTabella(dimensioni2Col, numeroCelleConDimDiverse);

            return Tabella;
        }

        private void riempiTabella(int dimensioni2Col, int numeroCelleNonDimDiverse)
        {
            foreach (IElement item in this.ContenitoreTabella)
            {
                if (numeroCelleNonDimDiverse == 0)
                {
                    this.CreaCella(item, 50);
                }
                else
                {
                    this.CreaCella(item);
                    numeroCelleNonDimDiverse--;
                }
            }
        }

        private void riempiTabella()
        {
            foreach (IElement item in this.ContenitoreTabella)
            {
                if (item.GetType() == typeof(ImgRaw))
                {
                    PdfPCell cell = new PdfPCell((Image)item, true);
                    cell.Border = 0;
                    Tabella.AddCell(cell);
                }
                else
                {
                    this.CreaCella(item);
                }
            }
        }

        private void CreaCella(IElement elem, int MinimumHeight = 0)
        {
            PdfPCell cella = new PdfPCell();
            cella.MinimumHeight = MinimumHeight;
            if (MinimumHeight != 0) cella.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cella.AddElement(elem);
            if (!bordi)
            {
                cella.Border = 0;
            }
            this.Tabella.AddCell(cella);
        }


    }
}
