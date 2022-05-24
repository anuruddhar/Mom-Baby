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
#endregion	  

namespace Mobile.PDF {
    public class PdfImage {
        public byte[] ByteArray = null;
        public float Width = 100;
        public float Height = 30;

        public PdfImage(float width, float height) {
            Width = width;
            Height = height;
        }
    }
}
