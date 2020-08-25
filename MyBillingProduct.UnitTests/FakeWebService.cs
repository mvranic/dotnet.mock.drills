namespace MyBillingProduct.UnitTests {
    internal class FakeWebService : IWebService {
        private string LastMessage;
        public void Write(string message) {
            LastMessage = message;
        }

        internal string GetLastPostMessage() {
            return LastMessage;
        }
    }
}