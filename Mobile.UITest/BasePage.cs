#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.UITest
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
 22/07/2019         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using NUnit.Framework;
using System;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
#endregion

namespace Mobile.UITest {
    public abstract class BasePage {
        protected IApp app => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected readonly Query txtUserId;
        protected readonly Query txtPassword;
        protected readonly Query btnLogin;
        protected readonly Query lblTitle;
        protected readonly Query lblMessage;

        protected abstract PlatformQuery Trait { get; }

        protected BasePage() {
            AssertOnPage(TimeSpan.FromSeconds(30));
            app.Screenshot("On " + this.GetType().Name);
            txtUserId = x => x.Marked(TestConstants.Text.USER_ID);
            txtPassword = x => x.Marked(TestConstants.Text.PASSWORD);
            btnLogin = x => x.Marked(TestConstants.Button.LOGIN);
            lblMessage = x => x.Marked(TestConstants.Label.MESSAGE);
        }

        /// <summary>
        /// Verifies that the trait is still present. Defaults to no wait.
        /// </summary>
        /// <param name="timeout">Time to wait before the assertion fails</param>
        protected void AssertOnPage(TimeSpan? timeout = default(TimeSpan?)) {
            var message = "Unable to verify on page: " + this.GetType().Name;

            if (timeout == null)
                Assert.IsNotEmpty(app.Query(Trait.Current), message);
            else
                Assert.DoesNotThrow(() => app.WaitForElement(Trait.Current, timeout: timeout), message);
        }

        /// <summary>
        /// Verifies that the trait is no longer present. Defaults to a 5 second wait.
        /// </summary>
        /// <param name="timeout">Time to wait before the assertion fails</param>
        protected void WaitForPageToLeave(TimeSpan? timeout = default(TimeSpan?)) {
            timeout = timeout ?? TimeSpan.FromSeconds(5);
            var message = "Unable to verify *not* on page: " + this.GetType().Name;

            Assert.DoesNotThrow(() => app.WaitForNoElement(Trait.Current, timeout: timeout), message);
        }

        protected void LoadApplication() {
            app.WaitForElement(txtUserId);
            app.EnterText(txtUserId, "Kilaru.Srikanta");
            app.EnterText(txtPassword, "UAT");
            app.DismissKeyboard();
            app.Tap(btnLogin);
        }
        // You can edit this file to define functionality that is common across many or all pages in your app.
        // For example, you could add a method here to open a side menu that is accesible from all pages.
        // To keep things more organized, consider subclassing BasePage and including common page actions there.
        // For some examples check out https://github.com/xamarin-automation-service/uitest-pop-example/wiki
    }
}
