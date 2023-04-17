namespace WeatherApp
{
	public static class LaunchDayCalculator
	{
		private static bool DayIsCandidate(Day day)
		{
			if (day._temperature >= 2
				&& day._temperature <= 31
				&& day._wind <= 10
				&& day._humidity < 60
				&& day._precipitation == 0
				&& day._lightning == false
				&& day._clouds != Clouds.Cumulus
				&& day._clouds != Clouds.Nimbus)
			{
				return true;
			}

			return false;
		}

		private static void GetCandidateDays(List<Day> days, List<Day> launchDayCandidates)
		{
			foreach (Day day in days)
			{
				if (DayIsCandidate(day)) {
					launchDayCandidates.Add(day);
				}
			}
		}

		public static int CalculateLaunchDay(List<Day> days)
		{
			if (days.Count() == 0)
			{
				throw new Exception("List of Day objects is empty");
			}

			List<Day> launchDayCandidates = new List<Day>();
			GetCandidateDays(days, launchDayCandidates);

			return launchDayCandidates.Count == 0 ? -1 : launchDayCandidates.OrderBy(s => s._wind).ThenBy(s => s._humidity).First()._index;
		}
	}
}

