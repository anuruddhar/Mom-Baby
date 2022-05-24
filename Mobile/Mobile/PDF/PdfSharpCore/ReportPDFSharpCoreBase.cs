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
using Mobile.Core.Helpers;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.PDF.PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Mobile.Helpers.AppConstant;
#endregion


namespace Mobile.PDF.PdfSharpCore {
    public abstract class ReportPDFSharpCoreBase {

        #region Private Variables
        protected PdfSharpCoreGenerator pdf;
        protected double x = 0;
        protected double x2 = 0;
        protected double y = 0;
        protected XFont font;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ReportPDFSharpCoreBase() {
            x = PdfPaperProperties.PAPER_MARGIN_LEFT;
            x2 = x + PdfPaperProperties.COLUMN_TWO;
            // GlobalFontSettings.FontResolver = new FontResolver();
            font = PdfParameter.BodyFont;
        }
        #endregion

        #region Methods

        protected void PrintBarcodes(List<string> foundBarcodes, bool isPrinting) {
            int barcodeCount = 0;
            string barcodes = string.Empty;
            foreach (string barcode in foundBarcodes) {
                barcodeCount += 1;
                if (barcodeCount == 1) {
                    AddText(barcode, x, y, font, false, isPrinting);
                } else if (barcodeCount == 6) {
                    AddText(barcode, x + (50.2F * (barcodeCount - 1)), y, font, true, isPrinting);
                    barcodeCount = 0;
                } else {
                    AddText(barcode, x + (50.2F * (barcodeCount - 1)), y, font, false, isPrinting);
                }
            }
            IncrementY();
        }


        protected List<string> GetDoMemoByLinesToPrint(string DoMemo, int lineSize) {
            List<string> doMemoLines = new List<string>();
            int start = 0;
            float val = DoMemo.Length / lineSize;
            int noOfLines = Convert.ToInt16(Math.Ceiling(val));
            for (int i = 0; i < noOfLines; i = i + 1) {
                doMemoLines.Add(DoMemo.Substring(start, lineSize));
                start += lineSize;
            }
            doMemoLines.Add(DoMemo.Substring(start, DoMemo.Length - (noOfLines * lineSize)));
            return doMemoLines;
        }

        protected void AddHorizontalLine(double yLoc, bool isPrinting) {
            /*IncrementY(5);
            if (isPrinting) {
                pdf.DrawHorizontalLine(0, PdfPaperProperties.PAPER_WIDTH, y);
            }*/
            AddText("________________________________________________________________________________", 0, (yLoc - 6), font, true, isPrinting);
        }

        #region LogoImage
        protected void PrintLogoImage(bool isPrinting) {
            AddImage(DependencyService.Get<IFileHelper>().GetLogoFilePath(), x, y, PdfPaperProperties.LOGO_IMAGE_WIDTH, PdfPaperProperties.LOGO_IMAGE_HEIGHT, isPrinting, false);
            IncrementY(10);
        }
        #endregion

        protected void AddImage(string imagePath, double xLoc, double yLoc, double width, double height, bool isPrinting, bool isSignature) {
            if (isPrinting) {
                if (isSignature && DependencyService.Get<IFileHelper>().IsSignatureFileExists(imagePath)) {
                    pdf.AddImage(imagePath, xLoc, yLoc, width, height);
                }

                if (!isSignature) {
                    pdf.AddImage(imagePath, xLoc, yLoc, width, height);
                }
            }
            IncrementY(height);
        }

        protected void AddText(string text, double xLoc, double yLoc, XFont pdfFont, bool isIncrement, bool isPrinting) {
            if (StringHelper.IsValid(text)) {
                if (isPrinting) {
                    pdf.AddText(text, xLoc, yLoc, pdfFont);
                }
                if (isIncrement) {
                    IncrementY(font);
                }
            }
        }

        protected void AddHyperLink(string text, double xLoc, double yLoc, bool isIncrement, bool isPrinting) {
            if (StringHelper.IsValid(text)) {
                if (isPrinting) {
                    pdf.AddHyperLink(text, xLoc, yLoc);
                }
                if (isIncrement) {
                    IncrementY(font);
                }
            }
        }


        protected void AddTextMultipleLines(string text, double xLoc, double yLoc, XFont pdfFont, bool isPrinting, int noOfCharatersPerLine) {
            if (StringHelper.IsValid(text)) {
                if (isPrinting) {
                    y = pdf.AddTextWithIncrement(text, xLoc, yLoc, pdfFont, noOfCharatersPerLine);
                } else {
                    int numberOfLines = (int)Math.Ceiling(text.Length / Convert.ToDecimal(noOfCharatersPerLine));
                    if (numberOfLines > 1) {
                        int textLength = text.Length;
                        int subStringTextLength = textLength / numberOfLines;
                        for (int i = 0; i < numberOfLines; i++) {
                            IncrementY(pdfFont);
                        }
                        DecrementY(pdfFont.Size);
                    }
                }
            }
        }

        protected void IncrementY() {
            IncrementY(font.Size);
        }

        protected void IncrementY(XFont font) {
            IncrementY(font.Size);
        }

        protected void IncrementY(double height) {
            y += height;
        }

        private void DecrementY(double height) {
            y -= height;
        }

        #endregion

    }
}
