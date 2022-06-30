using Foundation.Videos.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Feature.PrimaryContent.Models
{
	public class VideoRow
	{
		public TextField? Heading { get; set; }

		public TextField? SectionImage { get; set; }

		public TextField? Caption { get; set; }

		// ReSharper disable once InconsistentNaming
		public TextField? VideoID { get; set; }

		public VideoProviderSetting? VideoProvider { get; set; }
	}
}
