using Microsoft.VisualBasic.FileIO;

namespace WeatherApp
{
	public static class CSVReader
	{
		public static List<List<string>> ReadCSV(string filepath)
		{
			TextFieldParser parser = new TextFieldParser(filepath);

			parser.TextFieldType = FieldType.Delimited;
			parser.SetDelimiters(",");
			parser.TrimWhiteSpace = true;

			List<List<string>> table = new List<List<string>>();

			while (!parser.EndOfData)
			{
				string[] row = parser.ReadFields();
				table.Add(row.ToList());
			}

			return table;
		}
	}
}

