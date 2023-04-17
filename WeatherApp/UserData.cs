namespace WeatherApp
{
	public class UserData
	{
		public string inputCSVFilepath = "";
        public string senderEmail = "";
		public string password = "";
		public string recipientEmail = "";

        public UserData()
        {
        }

        public UserData(string inputCSVFilepath, string senderEmail, string password, string recipientEmail)
        {
            this.inputCSVFilepath = inputCSVFilepath;
            this.senderEmail = senderEmail;
            this.password = password;
            this.recipientEmail = recipientEmail;
        }
    }
}

