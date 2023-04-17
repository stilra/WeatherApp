using System.Text;

namespace WeatherApp
{
	public static class WeatherApp
	{
		public static void Main()
		{
			int launchDay = -1;
			try
			{
				UserData userData = new UserData("/Users/stiliyanraev/Projects/WeatherApp/WeatherApp/test.csv", "test@abv.bg", "test", "recipient@abv.bg");
				// UI.GetUserData(userData);
				var testUserData = new UserData();

				var table = CSVReader.ReadCSV(userData.inputCSVFilepath);
				var days = DayBuilder.BuildDays(table);

				launchDay = LaunchDayCalculator.CalculateLaunchDay(days);
				
				var aggregates = AggregatesCalculator.calculateAggregates(days, launchDay);
				var aggregatesTable = new List<List<string>>();
				foreach (var aggregate in aggregates)
				{
					aggregatesTable.Add(aggregate.ToList());
				}

				string outputCSVFilepath = "/Users/stiliyanraev/Projects/WeatherApp/WeatherApp/output.csv";
				CSVWriter.WriteCSV(aggregatesTable, outputCSVFilepath);

				var sb = new StringBuilder();
				var emailBody = sb.AppendFormat($"The most appropriate launch day is {launchDay}.\nFind attached a CSV file with the aggregated values.\n").ToString();
				EmailSender.SendEmail("sender@testing.com", "", "receiver@testing.com", "Weather App Result", emailBody, outputCSVFilepath);
			}
			catch(Exception exception)
			{
				UI.OutputFail(exception);
				return;
			}

			UI.OutputSuccess(launchDay);
			return;
		}
	}
}

