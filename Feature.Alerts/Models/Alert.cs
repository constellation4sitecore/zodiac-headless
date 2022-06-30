using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Feature.Alerts.Models
{
	public class Alert
	{
		public Guid? ID { get; set; }

		public TextField? Heading { get; set; }

		public TextField? Message { get; set; }

		public CheckboxField? LoadExpanded { get; set; }

		public CheckboxField? CanBeDismissed { get; set; }

		public AlertType? AlertType { get; set; }

		/// <summary>
		/// Do not display the alert if this value is in the future. Default value from Sitecore is DateTime.MinValue
		/// </summary>
		public DateTime ValidFrom { get; set; }


		private DateTime _validTo = DateTime.MaxValue;
		/// <summary>
		/// Do not display the alert if this value is in the past. Default value is DateTime.MaxValue.
		/// </summary>
		public DateTime ValidTo
		{
			get
			{
				return _validTo;
			}
			set
			{
				if (value > DateTime.MinValue)
				{
					_validTo = value;
				}
			}
		}
	}
}
