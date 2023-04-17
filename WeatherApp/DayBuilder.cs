namespace WeatherApp
{
	public static class DayBuilder
	{
		public static List<Day> BuildDays(List<List<string>> table)
		{
			var days = new List<Day>(table.Count);

			table.RemoveAt(0);

			foreach(var row in table)
			{
				days.Add(new Day(row));
            }

			return days;
        }
	}
}

