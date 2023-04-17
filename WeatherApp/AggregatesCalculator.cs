namespace WeatherApp
{
	public static class AggregatesCalculator
	{
		private static Aggregate GetAggregateForNumericFields(string aggregateName, int launchDay, List<Day> days, Func<Day, int> selector)
		{
			var aggregate = new Aggregate();
			aggregate._name = aggregateName;

			var sortedBy = days.OrderBy(selector);

			aggregate._average = days.Average(selector);
			aggregate._maximum = days.Max(selector);
			aggregate._minimum = days.Min(selector);

			var count = sortedBy.Count();
			if (count % 2 == 0)
			{
				aggregate._median = selector(days.ElementAt((count + 1) / 2));
			}
			else
			{
				aggregate._median = selector(days.ElementAt(count / 2));
			}

			aggregate._ldValue = selector(days.ElementAt(launchDay)).ToString();

			return aggregate;
		}

		private static Aggregate GetAggregateForNonNumericFields(string aggregateName, int launchDay, List<Day> days, Func<Day, string> selector)
		{
			var aggregate = new Aggregate();
			aggregate._name = aggregateName;

			aggregate._average = -1;
			aggregate._maximum = -1;
			aggregate._minimum = -1;
			aggregate._median = -1;

			aggregate._ldValue = selector(days.ElementAt(launchDay));

			return aggregate;
		}

		public static List<Aggregate> calculateAggregates(List<Day> days, int launchDay)
		{
			var aggregates = new List<Aggregate>(6);

			aggregates.Add(GetAggregateForNumericFields("Temperature", launchDay, days, (Day x) => { return x._temperature; }));
			aggregates.Add(GetAggregateForNumericFields("Wind", launchDay, days, (Day x) => { return x._wind; }));
			aggregates.Add(GetAggregateForNumericFields("Humidity", launchDay, days, (Day x) => { return x._humidity; }));
			aggregates.Add(GetAggregateForNumericFields("Precipitation", launchDay, days, (Day x) => { return x._precipitation; }));
			aggregates.Add(GetAggregateForNonNumericFields("Lightning", launchDay, days, (Day x) => { return x._lightning ? "Yes" : "No"; }));
			aggregates.Add(GetAggregateForNonNumericFields("Clouds", launchDay, days, (Day x) => { return x._clouds.ToString(); }));

			return aggregates;
		}
	}
}

