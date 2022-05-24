
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
14/03/2022        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Android.Content;
using Mobile.Helpers;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

[assembly: Dependency(typeof(GTS.Mobile.Droid.LocalDB))]
namespace GTS.Mobile.Droid {
    public class LocalDB : ILocalDB{
        public void SendEmail() {
            copyLocalDB();

            var file = new Java.IO.File(DependencyService.Get<IFileHelper>().GetLocalDbPathToCopy());
            var path = Android.Net.Uri.FromFile(file);
            file.SetReadable(true, false);

            var email = new Intent(Intent.ActionSend);
            email.SetFlags(ActivityFlags.NewTask);
            email.AddFlags(ActivityFlags.GrantReadUriPermission);
            email.PutExtra(Intent.ExtraEmail, new string[] { "anuruddha.rajapaksha@gmail.com"});
            email.PutExtra(Intent.ExtraSubject, "Mom & Baby Local Database");
            email.PutExtra(Intent.ExtraText, "Attached Local DB");
            email.PutExtra(Intent.ExtraStream, path);
            email.SetType("message/rfc822");
            Android.App.Application.Context.StartActivity(email);

            // deleteDbFile();
         }

        public bool CopyDBToApplication() {
            if (copyApplicationLocalDB()) {
                deleteDbFile();
                return true;
            }
            return false;
        }


        public void DeleteDbFile() {
            Java.IO.File deleteFile = new Java.IO.File(DependencyService.Get<IFileHelper>().GetLocalDbPath());
            try {
                if (deleteFile.Exists()) {
                    deleteFile.Delete();
                }
            } catch (System.Exception ex) {
                throw ex;
            }

        }

        private void copyLocalDB() {
            deleteDbFile();
            string toFile = DependencyService.Get<IFileHelper>().GetLocalDbPathToCopy();
            string fromFile = DependencyService.Get<IFileHelper>().GetLocalDbPath();
            File.Copy(fromFile, toFile);
        }

        private void deleteDbFile() {
            Java.IO.File deleteFile = new Java.IO.File(DependencyService.Get<IFileHelper>().GetLocalDbPathToCopy());
            if (deleteFile.Exists()) {
                deleteFile.Delete();
            }
        }


        private bool copyApplicationLocalDB() {
            if (deleteApplicaitonDbFile()) {
                string toFile = DependencyService.Get<IFileHelper>().GetLocalDbPath();
                string fromFile = DependencyService.Get<IFileHelper>().GetLocalDbPathToCopy();
                File.Copy(fromFile, toFile);
                return true;
            }
            return false;
        }

        private bool deleteApplicaitonDbFile() {
            Java.IO.File replaceFile = new Java.IO.File(DependencyService.Get<IFileHelper>().GetLocalDbPathToCopy());
            if (replaceFile.Exists()) {
                Java.IO.File deleteFile = new Java.IO.File(DependencyService.Get<IFileHelper>().GetLocalDbPath());
                if (deleteFile.Exists()) {
                    deleteFile.Delete();
                    return true;
                }
            } 
            return false;
        }


    }
}