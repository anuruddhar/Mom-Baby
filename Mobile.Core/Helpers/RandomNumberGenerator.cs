
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.Text;
#endregion	  


namespace Mobile.Core.Helpers
{
    public static class RandomNumberGenerator {
        public static string CreateUniqueId(int length = 64) {
            var bytes = PCLCrypto.WinRTCrypto.CryptographicBuffer.GenerateRandom(length);
            return ByteArrayToString(bytes);
        }

        private static string ByteArrayToString(byte[] array) {
            var hex = new StringBuilder(array.Length * 2);
            foreach (byte b in array) {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
