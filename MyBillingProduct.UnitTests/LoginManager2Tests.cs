using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBillingProduct.UnitTests {
    public class LoginManager2Tests {
        [Test]
        public void IsLoginOK_LoginOk_WriteLoggerIsCalled() {
            ILogger stubLogger = A.Fake<ILogger>();
            IWebService mockWebService  = A.Fake<IWebService>();
            var loginManager = new LoginManager2(stubLogger, mockWebService);
            loginManager.AddUser("a_user", "a_password");
            loginManager.IsLoginOK("a_user", "a_password");
            A.CallTo(() => stubLogger.Write(A<string>.Ignored)).MustHaveHappened(); 
        }

    }
}
