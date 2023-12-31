using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace diBa_LIB
{
    public class CustomPrint
    {
        private Font tipeFont;
        private StreamReader printToFile;
        private float marginLeft, marginRight, marginTop, marginBottom;

        public CustomPrint(Font fontType, string pathToFile, float leftMargin, float rightMargin,
            float topMargin, float bottomMargin)
        {
            TipeFont = fontType;
            PrintToFile = new StreamReader(pathToFile);
            MarginLeft = leftMargin;
            MarginRight = rightMargin;
            MarginTop = topMargin;
            MarginBottom = bottomMargin;
        }

        public Font TipeFont { get => tipeFont; set => tipeFont = value; }
        public StreamReader PrintToFile { get => printToFile; set => printToFile = value; }
        public float MarginLeft { get => marginLeft; set => marginLeft = value; }
        public float MarginRight { get => marginRight; set => marginRight = value; }
        public float MarginTop { get => marginTop; set => marginTop = value; }
        public float MarginBottom { get => marginBottom; set => marginBottom = value; }

        private void PrintText(object sender, PrintPageEventArgs e)
        {
            int maxBaris = (int)((e.MarginBounds.Height - MarginTop - MarginBottom) / TipeFont.GetHeight(e.Graphics));
            float Y;
            float X = MarginLeft;
            int jumBaris = 0;

            string teksCetak = PrintToFile.ReadLine();
            while (jumBaris < maxBaris && teksCetak != null)
            {
                Y = MarginTop + (jumBaris * TipeFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(teksCetak, TipeFont, Brushes.Navy, X, Y);

                jumBaris++;
                teksCetak = PrintToFile.ReadLine();
            }
            if (teksCetak == null)
            {
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }
        }

        public void KirimkePrinter()
        {
            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            p.PrintPage += new PrintPageEventHandler(PrintText);
            p.Print();

            PrintToFile.Close();
        }
    }
}
