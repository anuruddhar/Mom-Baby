#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Helpers
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
08/03/2022         1.0      Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Data;
using Mobile.Helpers;
using Mobile.Models.PDF;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.IO;
using Xamarin.Forms;
#endregion

namespace Mobile.PDF.PdfSharpCore {
    public class PdfSharpCoreGenerator {

        private XGraphics gfx;
        private IPDTFileDataService _pDTFileDataService;
        private XSolidBrush xSolidBrush = new XSolidBrush(XColor.FromArgb(0, 0, 0));
        private XSolidBrush xSolidBrushBlue = new XSolidBrush(XColor.FromArgb(0, 0, 250));

        public PdfSharpCoreGenerator(IPDTFileDataService pDTFileDataService, double height, double width = 300) {
            _pDTFileDataService = pDTFileDataService;
            Document = new PdfDocument();
            AddPage(height, width);
        }

        public PdfDocument Document { get; set; }


        public void AddText(string text, double x, double y, XFont font = null) {
            font = font ?? PdfParameter.BodyFont;
            gfx.DrawString(text, font, xSolidBrush, x, y);
        }

        public void AddHyperLink(string text, double x, double y) {
            gfx.DrawString(text, PdfParameter.BodyFontUnderLine, xSolidBrushBlue, x, y);
        }


        public double AddTextWithIncrement(string text, double x, double y, XFont font, int noOnCharsPerPage) {
            int numberOfLines = (int)Math.Ceiling(text.Length / Convert.ToDecimal(noOnCharsPerPage));
            if (numberOfLines > 1) {
                int textLength = text.Length;
                for (int i = 0; i < numberOfLines; i++) {
                    if (i == numberOfLines - 1) { // printing last line
                        AddText(text.Substring(i * noOnCharsPerPage, (textLength % noOnCharsPerPage)), x, y, font);
                    } else { // printing other lines
                        AddText(text.Substring(i * noOnCharsPerPage, noOnCharsPerPage), x, y, font);
                        y = IncrementY(y, font.Size);
                    }
                }
            } else {
                AddText(text, x, y, font);
            }
            return y;
        }

        public void DrawHorizontalLine(double xStart, double xEnd, double y) {
            XColor xColor = new XColor();
            XPen xPen = new XPen(xColor);
            gfx.DrawLine(xPen, xStart, y, xEnd, y);
        }

        public double IncrementY(double currentY, double height) {
            currentY += height;
            return currentY;
        }

        private double DecrementY(double currentY, double height) {
            currentY -= height;
            return currentY;
        }

        public void AddPage(double height, double width = 300) {
            try {
                PdfPage page = new PdfPage();
                //page.Size = PageSize.Post;
                page.Width = width;
                page.Height = height;// 479; 
                page.Orientation = PageOrientation.Portrait;
                page.Rotate = 0;
                Document.Pages.Add(page);

                gfx = XGraphics.FromPdfPage(page);
            } catch (Exception ex) {
                throw ex;
            }

        }

        public void AddImage(string imagePath, double x, double y, double width, double height) {
            XImage img = XImage.FromFile(imagePath);
            gfx.DrawImage(img, x, y, width, height);
        }

        public void Save(string mother, string fileName, bool saveInLocalDb = true, bool launchFile = true) {
            using (MemoryStream ms = new MemoryStream()) {
                Document.Save(ms);

                // 1. Save Pdf File as a file.
                var saveCommand = DependencyService.Get<IFileHelper>().SavePdfFileAsync(fileName, ms);

                // 2. Save Pdf File in Local DB.
                if (saveInLocalDb) {
                    // _pDTFileDataService.DeleteItemByNoAsync(docNo);
                    PDTFile pDTFile = new PDTFile() {
                        MotherId = mother
                        // PDFFile = ms.ToArray()
                    };
                    _pDTFileDataService.SaveItemAsync(pDTFile);
                }

            }
        }

    }
}
