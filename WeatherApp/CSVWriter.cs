namespace WeatherApp
{
	public static class CSVWriter
	{
		public static bool WriteCSV(List<List<string>> rows, string filepath)
		{
			if (rows.Count() == 0)
			{
				return false;
			}

			var sb = new System.Text.StringBuilder();

			sb.Append("Aggregate,Average,Maximum,Minimum,Median,LaunchDayValue\n");

			foreach (List<string> row in rows)
			{
				foreach(string field in row)
				{
					sb.Append(field);
					sb.Append(",");
				}
				sb.Replace(",", "\n", sb.Length - 1, 1);
			}
			sb.Remove(sb.Length - 1, 1);

			File.WriteAllText(filepath, sb.ToString());
			return true;
		}
	}
}

