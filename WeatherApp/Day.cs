namespace WeatherApp
{
	public enum Clouds
	{
		Stratus = 1,
		Nimbus = 2,
		Cumulus = 3,
		Cirrus = 4
	}

	public class Day
	{
		public int _index;
		public int _temperature;
		public int _wind;
		public int _humidity;
		public int _precipitation;
		public bool _lightning;
		public Clouds _clouds;

		public Day()
		{
		}

		public Day (List<string> list)
		{
			int.TryParse(list[0], out _index);
			int.TryParse(list[1], out _temperature);
			int.TryParse(list[2], out _wind);
			int.TryParse(list[3], out _humidity);
			int.TryParse(list[4], out _precipitation);
			switch (list[5])
			{
				case "Yes": _lightning = true; break;
				case "No": _lightning = false; break;
				default: _lightning = false; break;
			}
			switch (list[6])
			{
				case "Stratus": _clouds = Clouds.Stratus; break;
				case "Nimbus": _clouds = Clouds.Nimbus; break;
				case "Cumulus": _clouds = Clouds.Cumulus; break;
				case "Cirrus": _clouds = Clouds.Cirrus; break;
				default: _clouds = 0; break;
			}
		}
	}
}

