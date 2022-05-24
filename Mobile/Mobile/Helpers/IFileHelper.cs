
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System.IO;
using System.Threading.Tasks;
#endregion

namespace Mobile.Helpers {
    public interface IFileHelper {

        string GetLogoFilePath();
        string GetLocalDbPath();

        string GetLocalDbPathToCopy();

        #region Signature
        byte[] GetSignatureImageBytes(string fileName);

        Task<bool> SaveSignature(string fileName, Stream bitmap);

        void SaveSignatureFile(string fileName, byte[] stream);

        void DeleteSignatureFile(string fileName);

        void DeleteAllSignatureFile();

        string GetSignatureFileLocationPath(string fileName);

        bool IsSignatureFileExists(string fileName);
        #endregion


        #region Font
        void CreateAppFolderPath();

        string GetEnglishFontPath();

        string GetEnglishItalicFontPath();

        #endregion

        #region PDF
        Task SavePdfFileAsync(string fileName, MemoryStream s);

        bool IsPdfFileExists(string fileName);

        byte[] GetPdfFileBytes(string fileName);

        void DeletePdfFile(string fileName);

        void DeleteAllPdfFile();

        string GetPdfFileLocationPath(string fileName);

        #endregion
    }
}
