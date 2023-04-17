namespace WeatherApp
{
	public class Aggregate
	{
		public string _name = "";
		public double _average;
		public int _maximum;
		public int _minimum;
		public double _median;
		public string _ldValue = "";

		public Aggregate()
		{
		}

		public List<string> ToList()
		{
			List<string> list = new List<string>(6);

			list.Add(_name);
			list.Add(_average < 0 ? "" : _average.ToString("F2"));
			list.Add(_maximum < 0 ? "" : _maximum.ToString());
			list.Add(_minimum < 0 ? "" : _minimum.ToString());
			list.Add(_median < 0 ? "" : _median.ToString("F2"));
			list.Add(_ldValue);

			return list;
		}
	}
}

