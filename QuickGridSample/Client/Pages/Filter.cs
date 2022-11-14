using System.Text.RegularExpressions;

namespace QuickGridSample.Client.Pages
{
	public class Filter
	{

		public Action? OnChange { get; set; }

		private string _filter = "";
		private Regex? filterRegex = null;

		public bool IsMatch(string value)
		{
			return filterRegex?.IsMatch(value) ?? true;
		}

		public bool HasPattern { get => filterRegex != null; }
		public string Pattern
		{
			get => _filter;
			set
			{
				if (_filter != value)
				{
					_filter = value;
					if (string.IsNullOrEmpty(_filter))
					{
						filterRegex = null;
					}
					else
					{
						filterRegex = new Regex(_filter, RegexOptions.IgnoreCase);
					}
					OnChange?.Invoke();
				}
			}
		}
	}
}
