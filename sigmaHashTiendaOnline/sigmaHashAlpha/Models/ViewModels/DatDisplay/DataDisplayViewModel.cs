namespace sigmaHashAlpha.Models.ViewModels.DatDisplay
{
	public class DataDisplayViewModel
	{
		public string ImagePath { get; set; }
		public Dictionary<string, string> Data { get; set; }
		public Dictionary<string, string> Details { get; set; }


		public DataDisplayViewModel(string imagePath,Dictionary<string, string> data, Dictionary<string, string> details)
		{
			ImagePath = imagePath;
			Data = data;
			Details = details;


		}

	}
}
