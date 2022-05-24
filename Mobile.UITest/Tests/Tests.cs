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
using Mobile.UITest.Pages;
using NUnit.Framework;
using Xamarin.UITest;
#endregion

namespace Mobile.UITest {
    public class Test : BaseTestFixture {

        #region Constructor
        public Test(Platform platform) : base(platform) {
        }
        #endregion

        #region Login
        [Test]
        public void LGN_Should_DisplayErrorMessage_If_Validation_Fails() {
            new LoginPage()
                .Should_DisplayErrorMessage_If_No_UserID_and_Password_Provided()
                .Should_DisplayErrorMessage_If_UserID_Not_Provided_but_Password_Provided()
                .Should_DisplayErrorMessage_If_UserID_Provided_but_Password_Not_Provided();

        }

        [Test]
        public void LGN_Should_Display_HomePage_If_Login_Valid() {
            new LoginPage()
                .Should_Display_HomePage_If_Login_Valid();
        }
        #endregion

        #region HomePage
        [Test]
        public void HOM_Should_Display_Greetings() {
            new LoginPage()
                .Login();

            new HomePage()
                .Should_Display_WelcomeMessage()
                .Should_Display_UserName();
        }

        [Test]
        public void HOM_Should_Display_AtLeast_TwoFavorite() {
            new LoginPage()
                .Login();

            new HomePage()
                .Should_Display_AtLeast_TwoFavorite();
        }
        #endregion

       
    }
}
