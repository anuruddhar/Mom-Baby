
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Droid.Implementations
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
25/02/2022        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Android.Graphics;
using Mobile.Droid;
using Mobile.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Mobile.Helpers.AppConstant;
using J = Java.IO;
#endregion

[assembly: Dependency(typeof(FileHelper))]
namespace Mobile.Droid {
    public class FileHelper : IFileHelper {

        #region Private

        private string logoFileName = "img-applogo.png";

        private string DocumentFolderPath() {
            //return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
               return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
        }

        private string AppFolderPath() {
            return $"{DocumentFolderPath()}/App";
        }

        private string AppFilePath(string filename) {
            return System.IO.Path.Combine(AppFolderPath(), filename);
        }

        private string GetLocalFilePath(string filename) {
            return System.IO.Path.Combine(PersonalFolderPath(), filename);
        }

        private string PersonalFolderPath() {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        private void DeleteFile(string filePath) {
            try {
                if (System.IO.File.Exists(filePath)) {
                    System.IO.File.Delete(filePath);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion



        #region LocalDb
        public string GetLocalDbPath() {
            return GetLocalFilePath(GlobalSetting.Instance.DbName);
        }

        public string GetLocalDbPathToCopy() {
            return System.IO.Path.Combine(AppFolderPath(), GlobalSetting.Instance.DbName);
        }

        #endregion

        #region LogoImage
        public string GetLogoFilePath() {
            return GetLocalFilePath(logoFileName);
        }

        public byte[] GetLogoImageBytes() {
            var imgFile = new J.File(GetLogoFilePath());
            var stream = new J.FileInputStream(imgFile);
            var bytes = new byte[imgFile.Length()];
            stream.Read(bytes);
            return bytes;
        }

        // For PDF 
        public string SavePrintLogoImage() {
            using (Bitmap bm = BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, Resource.Drawable.img_applogo)) {
                string filePath = GetLogoFilePath();
                DeleteFile(filePath);
                using (var fs = new FileStream(filePath, FileMode.CreateNew)) {
                    bm.Compress(Bitmap.CompressFormat.Png, 90, fs);
                    bm.Recycle();
                    return filePath;
                }
            }
        }
        #endregion

        #region Signature
        public byte[] GetSignatureImageBytes(string fileName) {
            var imgFile = new J.File(GetSignatureFileLocationPath(fileName));
            var stream = new J.FileInputStream(imgFile);
            var bytes = new byte[imgFile.Length()];
            stream.Read(bytes);
            return bytes;
        }

        public async Task<bool> SaveSignature(string fileName, Stream bitmap) {
            string filePath = GetSignatureFileLocationPath(fileName);
            //DeleteFile(filePath);
            J.File directory = GetSignatureFileDirectory(); 
            if (!directory.Exists()) {
                directory.Mkdir();
            }
            J.File file = GetSignatureFile(fileName);
            if (file.Exists()) {
                file.Delete();
            }

            using (var dest = System.IO.File.OpenWrite(filePath)) {
                await bitmap.CopyToAsync(dest);
            }
            return true;
        }

        public void SaveSignatureFile(string fileName, byte[] stream) {
            string filePath = GetSignatureFileLocationPath(fileName);
            //DeleteFile(filePath);
            J.File directory = GetSignatureFileDirectory();
            if (!directory.Exists()) {
                directory.Mkdir();
            }
            J.File file = GetSignatureFile(fileName);
            if (file.Exists()) {
                file.Delete();
            }
            System.IO.File.WriteAllBytes(filePath, stream);
        }

        public void DeleteSignatureFile(string fileName) {
            try {
                J.File file = GetSignatureFile(fileName);
                if (file.Exists()) {
                    file.Delete();
                }
            } catch (Exception) {
                //throw;
            }
        }

        public void DeleteAllSignatureFile() {
            try {;
                J.File dir = GetSignatureFileDirectory();
                if (dir.Exists()) {
                    foreach (var file in System.IO.Directory.GetFiles(GetSignatureFolderLocationPath())) {
                        System.IO.File.Delete(file);
                    }
                }
            } catch (Exception) {
            }
        }


        public string GetSignatureFileLocationPath(string fileName) {
            return $"{GetSignatureFolderLocationPath()}/{fileName}.png"; 
        }

        private string GetSignatureFolderLocationPath() {
            return $"{AppFolderPath()}/Signature";
        }

        private J.File GetSignatureFileDirectory() {
            return new J.File(GetSignatureFolderLocationPath());
        }

        private J.File GetSignatureFile(string fileName) {
            return new J.File(GetSignatureFileDirectory(), $"{fileName}.png");
        }

        public bool IsSignatureFileExists(string fileName) {
            J.File file = new J.File(fileName);
            return file.Exists();
        }
        #endregion

        #region Font
        public void CreateAppFolderPath() {
            J.File myDir = new J.File(AppFolderPath());
            if (!myDir.Exists()) {
                myDir.Mkdir();
            }
        }

        public string GetEnglishFontPath() {
            return AppFilePath(PrintConstant.ENGLISH_FONT_NAME);
        }

        public string GetEnglishItalicFontPath() {
            return AppFilePath(PrintConstant.ENGLISH_ITALIC_FONT_NAME);
        }

        #endregion

        #region PDF
        public async Task SavePdfFileAsync(string fileName, MemoryStream s) {
            // Case: when need to store external storage
            /*if (Android.OS.Environment.IsExternalStorageEmulated) {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            } else {
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }*/

            J.File directory = GetPdfFileDirectory(); // Note: PDF file should always save outside the intend location, since OBC printer intent need to access that.
            if (!directory.Exists()) {
                directory.Mkdir();
            }
            J.File file = GetPdfFile(fileName);
            if (file.Exists()) {
                file.Delete();
            }

            try {
                J.FileOutputStream outs = new J.FileOutputStream(file);
                outs.Write(s.ToArray());
                outs.Flush();
                outs.Close();
            } catch (Exception e) {
                throw e;
            }
            // Case: If file needs to be open
            /*if (file.Exists()) {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(path, mimeType);
                Android.App.Application.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            }*/
        }

        public bool IsPdfFileExists(string fileName) {
            J.File pdfFile = GetPdfFile(fileName);
            return pdfFile.Exists();
        }

        public byte[] GetPdfFileBytes(string fileName) {
            J.File pdfFile = GetPdfFile(fileName);
            var stream = new J.FileInputStream(pdfFile);
            var bytes = new byte[pdfFile.Length()];
            stream.Read(bytes);
            return bytes;
        }

        public void DeletePdfFile(string fileName) {
            try {
                J.File pdfFile = GetPdfFile(fileName);
                if (pdfFile.Exists()) {
                    pdfFile.Delete();
                }
            } catch (Exception) {
                //throw;
            }
        }

        public void DeleteAllPdfFile() {
            try {
                //J.File directory = GetPdfFileDirectory();
                //directory.Delete();
                J.File pdfDir = GetPdfFileDirectory();
                if (pdfDir.Exists()) {
                    foreach (var file in System.IO.Directory.GetFiles(GetPdfFolderLocationPath())) {
                        System.IO.File.Delete(file);
                    }
                }
            } catch (Exception) {
            }
        }

        public string GetPdfFileLocationPath(string fileName) {
            return $"{GetPdfFolderLocationPath()}/{fileName}.pdf"; // Note: PDF file should always save outside the intend location, since OBC printer intent need to access that.
        }

        private string GetPdfFolderLocationPath() {
            return $"{AppFolderPath()}/PDF";
        }

        private J.File GetPdfFileDirectory() {
            return new J.File(GetPdfFolderLocationPath());
        }

        private J.File GetPdfFile(string fileName) {
            return new J.File(GetPdfFileDirectory(), $"{fileName}.pdf");
        }

        #endregion

    }
}