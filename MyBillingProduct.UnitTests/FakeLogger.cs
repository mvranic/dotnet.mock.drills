using System;

namespace MyBillingProduct.UnitTests {
    internal class FakeLogger : ILogger{
        private string LastWrite;

        public bool WillWriteFail { get; internal set; }

        public void Write(string text) {
            if (WillWriteFail) { 
                throw new Exception("Write faild");
            }
            LastWrite = text;
        }

        internal string GetLastWrite() {
            return LastWrite;
        }
    }
}