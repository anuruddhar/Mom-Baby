
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
using System.IO;
using System.Text;

#endregion	  


namespace Mobile.Core.Helpers {
    public class StreamHelper {


        public static byte[] ReadFully(Stream input) {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream()) {
                int read;
                while (( read = input.Read(buffer, 0, buffer.Length) ) > 0) {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static byte[] StreamToByteArray(Stream stream) {
            long originalPosition = 0;

            if (stream.CanSeek) {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while (( bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead) ) > 0) {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length) {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1) {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead) {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            } finally {
                if (stream.CanSeek) {
                    stream.Position = originalPosition;
                }
            }
        }

        public static Stream ByteArrayToStream(byte[] byteArray){
            Stream stream = new MemoryStream(byteArray);
            return stream;
        }

    }
}
