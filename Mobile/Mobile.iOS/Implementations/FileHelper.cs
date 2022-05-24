
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.IOS
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
30/11/2018         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Data;
using Mobile.iOS.Implementations;
using Xamarin.Forms;
using System.IO;
using System;
using System.Threading.Tasks;
using Mobile.Helpers;
#endregion	  


[assembly: Dependency(typeof(FileHelper))]
namespace Mobile.iOS.Implementations {
    public class FileHelper : IFileHelper {
        public void CreateAppFolderPath() {
            throw new NotImplementedException();
        }

        public void DeleteAllPdfFile() {
            throw new NotImplementedException();
        }

        public void DeleteAllSignatureFile() {
            throw new NotImplementedException();
        }

        public void DeletePdfFile(string fileName) {
            throw new NotImplementedException();
        }

        public void DeleteSignatureFile(string fileName) {
            throw new NotImplementedException();
        }

        public string GetEnglishFontPath() {
            throw new NotImplementedException();
        }

        public string GetEnglishItalicFontPath() {
            throw new NotImplementedException();
        }

        public string GetLocalDbPath() {
            throw new NotImplementedException();
        }

        public string GetLocalDbPathToCopy() {
            throw new NotImplementedException();
        }

        public string GetLogoFilePath() {
            throw new NotImplementedException();
        }

        public byte[] GetLogoImageBytes() {
            throw new NotImplementedException();
        }

        public byte[] GetPdfFileBytes(string fileName) {
            throw new NotImplementedException();
        }

        public string GetPdfFileLocationPath(string fileName) {
            throw new NotImplementedException();
        }

        public string GetSignatureFileLocationPath(string fileName) {
            throw new NotImplementedException();
        }

        public byte[] GetSignatureImageBytes(string fileName) {
            throw new NotImplementedException();
        }

        public bool IsPdfFileExists(string fileName) {
            throw new NotImplementedException();
        }

        public bool IsSignatureFileExists(string fileName) {
            throw new NotImplementedException();
        }

        public Task SavePdfFileAsync(string filename, MemoryStream s) {
            throw new NotImplementedException();
        }

        public string SavePrintLogoImage() {
            throw new NotImplementedException();
        }

        public Task<bool> SaveSignature(string fileName, Stream bitmap) {
            throw new NotImplementedException();
        }

        public void SaveSignatureFile(string fileName, byte[] stream) {
            throw new NotImplementedException();
        }
    }
}