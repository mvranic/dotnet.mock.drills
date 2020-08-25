using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace MyBillingProduct
{
	public class LoginManager1
	{
	    private Hashtable Users = new Hashtable();
        private ILogger Logger;
		private IWebService WebService;


		public LoginManager1(ILogger logger, IWebService webservice) {
            Logger = logger;
			WebService = webservice;
		}

        public bool IsLoginOK(string user, string password)
	    {
				if (Users[user] != null &&
					(string)Users[user] == password) {
					WriteToLog($"login ok: user: {user}");
					return true;
				}
				WriteToLog($"bad login: {user},{password}");
				return false;
	    }

        private void WriteToLog(string message) {
			try {
				Logger.Write(message);
			} catch(Exception e) {
				WebService.Write($"got exception - {e.Message}");
			}
        }

        public void AddUser(string user, string password)
	    {
	        Users[user] = password;
			Logger.Write($"user added: {user},{password}");
		}

	    public void ChangePass(string user, string oldPass, string newPassword)
		{
			Users[user]= newPassword;
			Logger.Write($"pass changed: {user}, {oldPass}, {newPassword}");
		}
	}
}
