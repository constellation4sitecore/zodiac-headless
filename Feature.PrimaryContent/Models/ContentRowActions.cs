using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Feature.PrimaryContent.Models
{
	public class ContentRowActions
	{
		public HyperLinkField? PrimaryLink { get; set; }

		public HyperLinkField? SecondaryLink { get; set; }
	}
}
