using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Foundation.Videos.Models
{
	public class VideoProviderSetting
	{
		public TextField? DisplayName { get; set; }

		// ReSharper disable once InconsistentNaming
		public TextField? ProviderID { get; set; }
	}
}
