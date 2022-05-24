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
using PdfSharpCore.Drawing;
using static Mobile.Helpers.AppConstant;
#endregion	  

namespace Mobile.PDF {
    public static class PdfParameter {
        //public static PdfImage LogoImage = new PdfImage(PdfPaperProperties.LOGO_IMAGE_WIDTH, PdfPaperProperties.LOGO_IMAGE_HEIGHT);
        //public static PdfImage SignatureImage = new PdfImage(PdfPaperProperties.SIGNATURE_IMAGE_WIDTH, PdfPaperProperties.SIGNATURE_IMAGE_HEIGHT);

        public static float PaperWidth { get; set; } = PdfPaperProperties.PAPER_WIDTH;
        public static float PaperHeight { get; set; } = PdfPaperProperties.PAPER_HEIGHT;

        public static float PaperMarginLeft { get; set; } = PdfPaperProperties.PAPER_MARGIN_LEFT;
        public static float PaperMarginRight { get; set; } = PdfPaperProperties.PAPER_MARGIN_RIGHT;
        public static float PaperMarginTop { get; set; } = PdfPaperProperties.PAPER_MARGIN_TOP;
        public static float PaperMarginBottom { get; set; } = PdfPaperProperties.PAPER_MARGIN_BOTTOM;
        public static float ProductNumber { get; set; } = PdfPaperProperties.PRODUCT_NUM_MARGIN;
        public static float ProductDescNumber { get; set; } = PdfPaperProperties.PRODUCT_DESC_MARGIN;
        public static float UomNumberMargin { get; set; } = PdfPaperProperties.UOM_NUM_MARGIN;



        public static float ColumnTwo { get; set; } = PdfPaperProperties.COLUMN_TWO;

        //BodyMargin
        public static float DocketMargin { get; set; } = PdfPaperProperties.DOCKET_MARGIN;
        public static float CompanyMargin { get; set; } = PdfPaperProperties.COMPANY_MARGIN;
        public static float DeliveredMargin { get; set; } = PdfPaperProperties.DELIVERED_MARGIN;
        public static float StartingHoldingMargin { get; set; } = PdfPaperProperties.STARTING_HOLDINGMARGIN;
        public static float EndingHoldingMargin { get; set; } = PdfPaperProperties.ENDING_HOLDINGMARGIN;

        public static float ReturnedMargin { get; set; } = PdfPaperProperties.RETURNED_MARGIN;
        public static float QuantityMargin { get; set; } = PdfPaperProperties.QUANTITY_MARGIN;
        public static float DelValMargin { get; set; } = PdfPaperProperties.DEL_VAL_MARGIN;
        public static float StartHoldValMargin { get; set; } = PdfPaperProperties.START_HOLD_VAL_MARGIN;
        public static float EndHoldValMargin { get; set; } = PdfPaperProperties.END_HOLD_VAL_MARGIN;

        public static float RetValMargin { get; set; } = PdfPaperProperties.RET_VAL_MARGIN;
        public static float QtyValMargin { get; set; } = PdfPaperProperties.QTY_VAL_MARGIN;
        public static float UomMargin { get; set; } = PdfPaperProperties.UOM_MARGIN;
        public static float QtyMargin { get; set; } = PdfPaperProperties.QTY_MARGIN;
        public static float SignerMargin { get; set; } = PdfPaperProperties.SIGNER_MARGIN;
        public static float DocNumberMargin { get; set; } = PdfPaperProperties.DOC_NO_MARGIN;
        public static float AddressMargin { get; set; } = PdfPaperProperties.ADDRESS_MARGIN;


        // English
        public static XFont Heading1Font { get; set; } = new XFont(PrintConstant.ENGLISH_FONT, PdfPaperProperties.HEADING_1_FONT_SIZE, XFontStyle.Bold);
        public static XFont Heading2Font { get; set; } = new XFont(PrintConstant.ENGLISH_FONT, PdfPaperProperties.HEADING_2_FONT_SIZE, XFontStyle.Regular);
        public static XFont Heading3Font { get; set; } = new XFont(PrintConstant.ENGLISH_FONT, PdfPaperProperties.HEADING_3_FONT_SIZE, XFontStyle.Bold);
        public static XFont BodyFont { get; set; } = new XFont(PrintConstant.ENGLISH_FONT, PdfPaperProperties.BODY_FONT_SIZE);
        public static XFont FooterFont { get; set; } = new XFont(PrintConstant.ENGLISH_FONT, PdfPaperProperties.FOOTER_FONT_SIZE);
        public static XFont BodyFontItalic { get; set; } = new XFont(PrintConstant.ENGLISH_ITALIC_FONT, PdfPaperProperties.BODY_FONT_SIZE);
        public static XFont BodyFontUnderLine { get; set; } = new XFont(PrintConstant.ENGLISH_FONT, PdfPaperProperties.BODY_FONT_SIZE, XFontStyle.Underline);

    }


    public static class PdfPaperProperties {

        public static float PAPER_WIDTH = 303.12F;
        public static float PAPER_HEIGHT = 480;

        public static float LOGO_IMAGE_WIDTH = 100;
        public static float LOGO_IMAGE_HEIGHT = 30;

        public static float PAPER_MARGIN_LEFT = 5;
        public static float PAPER_MARGIN_RIGHT = 5;
        public static float PAPER_MARGIN_TOP = 5;
        public static float PAPER_MARGIN_BOTTOM = 5;

        #region English Font Sizes
        public static float BODY_FONT_SIZE = 7;
        public static float HEADING_1_FONT_SIZE = 16;
        public static float HEADING_2_FONT_SIZE = 12;
        public static float HEADING_3_FONT_SIZE = 8;
        public static float FOOTER_FONT_SIZE = 6;
        #endregion


        public static float COLUMN_TWO = 180;
        public static float COLUMN_TWO_CHINA = 170;
        public static float DOCKET_MARGIN = 72;
        public static float COMPANY_MARGIN = 14.4F;
        public static float STARTING_HOLDINGMARGIN = 100;
        public static float DELIVERED_MARGIN = 150;
        public static float RETURNED_MARGIN = 185.2F;
        public static float QUANTITY_MARGIN = 225.4F;
        public static float ENDING_HOLDINGMARGIN = 250.2F;
        public static float START_HOLD_VAL_MARGIN = 140;
        public static float DEL_VAL_MARGIN = 160.4F;
        public static float RET_VAL_MARGIN = 200.6F;
        public static float QTY_VAL_MARGIN = 230.8F;
        public static float END_HOLD_VAL_MARGIN = 250;
        public static float UOM_MARGIN = 180;
        public static float QTY_MARGIN = 180;
        public static float SIGNER_MARGIN = 93.6F;
        public static float DOC_NO_MARGIN = 93.6F;
        public static float ADDRESS_MARGIN = 79.2F;
        public static float PRODUCT_NUM_MARGIN = 20;
        public static float UOM_NUM_MARGIN = 100;
        public static float PRODUCT_DESC_MARGIN = 180;

        public static double SIGNATURE_IMAGE_WIDTH = 50;
        public static double SIGNATURE_IMAGE_HEIGHT = 50;

        public static int NO_OF_CHARACTERS_PER_PAGE_ENG = 30;

    }
}
