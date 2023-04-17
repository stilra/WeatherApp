namespace WeatherApp
{
	public static class UI
	{
		public static void GetUserData(UserData userData)
		{
			Console.WriteLine("Hello!\nWelcome to the Weather App!\n");
			Console.WriteLine("Please, choose your language.");
			Console.WriteLine("For English enter E.");
			Console.WriteLine("For German enter G.");
			Console.Write("Your choice: ");
			var language = Console.ReadLine();
			Console.Clear();

			Console.Write("Enter the path of the CSV input file: ");
			var inputCSVFilepath = Console.ReadLine();

			Console.Write("Enter sender email address: ");
			var senderEmail = Console.ReadLine();

			Console.Write("Enter sender email password: ");
			var password = Console.ReadLine();

			Console.Write("Enter recipient email address: ");
			var recipientEmail = Console.ReadLine();

			userData.inputCSVFilepath = inputCSVFilepath;
			userData.senderEmail = senderEmail;
			userData.password = password;
			userData.recipientEmail = recipientEmail;
		}

		public static void OutputFail(Exception exception)
		{
			if(exception != null)
			{
				Console.WriteLine(exception.ToString());
			}
		}

		public static void OutputSuccess(int launchDay)
		{
			Console.WriteLine($"The launch day is number {launchDay}");
		}
	}
}

