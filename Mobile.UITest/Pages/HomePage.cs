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
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
#endregion

namespace Mobile.UITest.Pages {
    public class HomePage : BasePage {

        readonly Query lblWelcome;

        public HomePage() {
            lblWelcome = x=> x.Marked(TestConstants.Label.WELCOME);
        }

        protected override PlatformQuery Trait => new PlatformQuery {
            Android = x => x.Marked(TestConstants.Traits.HOME_PAGE),
            iOS = x => x.Marked(TestConstants.Traits.HOME_PAGE)
        };

        public HomePage Should_Display_AtLeast_TwoFavorite() {
            app.WaitForElement(x => x.Marked(TestConstants.Traits.HOME_PAGE));
            Assert.AreEqual(2, app.Query(x => x.Marked(TestConstants.List.FAVOURITE).Child()).Length, "Expect 2 Favourite Menus but not as expected");  
            return this;
        }

        public HomePage Should_Display_WelcomeMessage() {
            app.WaitForElement(lblWelcome);
            AppResult[] results = app.Query(c => c.Marked(TestConstants.Label.WELCOME).Text("Welcome"));
            Assert.IsTrue(results.Any());
            return this;
        }

        public HomePage Should_Display_UserName() {
            app.WaitForElement(lblWelcome);
            AppResult[] results = app.Query(c => c.Marked(TestConstants.Label.USER_ID).Text("Udani.Rajapaksha"));
            Assert.IsTrue(results.Any());
            return this;
        }

        public HomePage TapOnItemDisplay() {
            app.WaitForElement(TestConstants.Label.ITEM_DISPLAY);
            app.Tap(TestConstants.Label.ITEM_DISPLAY);
            //AppResult[] results = app.WaitForElement(x => x.Marked(TestConstants.Traits.SINGLE_ITEM_SCAN_PAGE));
            //Assert.IsTrue(results.Any());
            return this;
        }
    }
}
