using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Foundation.Videos.Models
{
	public class VideoLabels
	{
		public TextField? PlayVideo { get; set; }

		public TextField? Play { get; set; }

		public TextField? Stop { get; set; }

		public TextField? Pause { get; set; }

		public TextField? Reverse { get; set; }

		public TextField? Forward { get; set; }

		public TextField? Transcript { get; set; }
	}
}
