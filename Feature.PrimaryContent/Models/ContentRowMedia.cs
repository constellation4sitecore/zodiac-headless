using Foundation.Videos.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Feature.PrimaryContent.Models
{
	public class ContentRowMedia
	{
		public ImageField? SectionImage { get; set; }

		// ReSharper disable once InconsistentNaming
		public TextField? VideoID { get; set; }

		public VideoProviderSetting? VideoProvider { get; set; }
	}
}
