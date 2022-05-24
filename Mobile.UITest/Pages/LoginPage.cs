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
using NUnit.Framework;
using System.Linq;
using Xamarin.UITest.Queries;
#endregion

namespace Mobile.UITest.Pages {
    public  class LoginPage : BasePage {

        protected override PlatformQuery Trait => new PlatformQuery {
            Android = x => x.Marked(TestConstants.Traits.LOGIN_PAGE),
            iOS = x => x.Marked(TestConstants.Traits.LOGIN_PAGE)
        };

        public LoginPage() {
        }

        public LoginPage Login() {
            LoadApplication();
            AppResult[] results = app.WaitForElement(x => x.Marked(TestConstants.Traits.HOME_PAGE));
            Assert.IsTrue(results.Any());
            return this;
        }

        public LoginPage Should_DisplayErrorMessage_If_No_UserID_and_Password_Provided() {
            app.WaitForElement(txtUserId);
            app.ClearText(txtUserId);
            app.ClearText(txtPassword);
            app.Tap(btnLogin);
            app.WaitForElement(lblMessage);
            AppResult[] results = app.Query(c => c.Marked(TestConstants.Label.MESSAGE).Text("UserId and Password not specified!"));         
            Assert.IsTrue(results.Any());
            app.Tap(x => x.Marked(TestConstants.Button.OK));

            return this;
        }

        public LoginPage Should_DisplayErrorMessage_If_UserID_Not_Provided_but_Password_Provided() {
            app.WaitForElement(txtUserId);
            app.ClearText(txtUserId);
            app.ClearText(txtPassword);
            app.EnterText(txtPassword, "UAT@1234");
            app.DismissKeyboard();
            app.Tap(btnLogin);
            app.WaitForElement(lblMessage);
            AppResult[] results = app.Query(c => c.Marked(TestConstants.Label.MESSAGE).Text("UserId not specified!"));
            Assert.IsTrue(results.Any());
            app.Tap(x => x.Marked(TestConstants.Button.OK));
            app.ClearText(txtPassword);
            return this;
        }

        public LoginPage Should_DisplayErrorMessage_If_UserID_Provided_but_Password_Not_Provided() {
            app.WaitForElement(txtUserId);
            app.ClearText(txtUserId);
            app.ClearText(txtPassword);
            app.EnterText(txtUserId, "Udani.Rajapaksha");
            app.DismissKeyboard();
            app.Tap(btnLogin);
            app.WaitForElement(lblMessage);
            AppResult[] results = app.Query(c => c.Marked(TestConstants.Label.MESSAGE).Text("Password not specified!"));
            Assert.IsTrue(results.Any());
            app.Tap(x => x.Marked(TestConstants.Button.OK));
            app.ClearText(txtUserId);
            return this;
        }

        public LoginPage Should_Display_HomePage_If_Login_Valid() {
            LoadApplication();
            AppResult[] results = app.WaitForElement(x => x.Marked(TestConstants.Traits.HOME_PAGE));
            Assert.IsTrue(results.Any());
            return this;
        }

    }
}
