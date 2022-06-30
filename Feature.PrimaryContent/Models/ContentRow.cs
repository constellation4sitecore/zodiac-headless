using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Feature.PrimaryContent.Models
{
	public class ContentRow
	{
		public TextField? Heading { get; set; }

		public TextField? Subheading { get; set; }

		public TextField? Copy { get; set; }
	}
}
