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
using Xamarin.UITest;
#endregion

namespace Mobile.UITest {
    [TestFixture(Platform.Android)]
    // [TestFixture(Platform.iOS)]
    public abstract class BaseTestFixture {
        protected IApp app => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected BaseTestFixture(Platform platform) {
            AppManager.Platform = platform;
        }

        [SetUp]
        public virtual void BeforeEachTest() {
            AppManager.StartApp();
        }

        // You can edit this file to define functionality that is common across many or all tests.
        // For example, you could add a method here to log in or dismiss a welcome dialogue.
    }
}
