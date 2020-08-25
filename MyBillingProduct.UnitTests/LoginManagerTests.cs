using NUnit.Framework;

namespace MyBillingProduct.UnitTests {
    //rename this class as needed
    public class LoginManagerTests
    {
        [Test]
        public void IsLoginOK_ValidUser_LogUser()
        {
            var mockLogger = new FakeLogger();
            LoginManager1 lm = new LoginManager1(mockLogger, new FakeWebService());
            lm.AddUser("a", "pass");

            lm.IsLoginOK("a", "pass");

            StringAssert.Contains("login ok: user: a", mockLogger.GetLastWrite());
        }

        [Test]
        public void IsLoginOK_InvalidUser_LogUserAndPassword() {
            var mockLogger = new FakeLogger();
            LoginManager1 lm = new LoginManager1(mockLogger, new FakeWebService());
           
            lm.IsLoginOK("a", "pass");

            StringAssert.Contains("bad login: a,pass", mockLogger.GetLastWrite());
        }

        [Test]
        public void IsLoginOK_LogWriteFails_SendExceptionToWebService() {
            var stubLogger = new FakeLogger();
            var mockWebservice = new FakeWebService();
            stubLogger.WillWriteFail = true;
            LoginManager1 lm = new LoginManager1(stubLogger, mockWebservice);

            lm.IsLoginOK("a", "pass");

            StringAssert.Contains("got exception - Write faild", mockWebservice.GetLastPostMessage());
        }

        [Test]
        public void AddUser_WithLog_LogUserAndPassword() {
            var mockLogger = new FakeLogger();
            LoginManager1 lm = new LoginManager1(mockLogger, new FakeWebService());
           
            lm.AddUser("a", "pass");

            StringAssert.Contains("user added: a,pass", mockLogger.GetLastWrite());
        }

        [Test]
        public void ChangePass_WithLog_LogUserAndNewAndOldPasswords() {
            var mockLogger = new FakeLogger();
            LoginManager1 lm = new LoginManager1(mockLogger, new FakeWebService());

            lm.ChangePass("a", "oldpass", "newpass");

            StringAssert.Contains("pass changed: a, oldpass, newpass", mockLogger.GetLastWrite());
        }

    }
}