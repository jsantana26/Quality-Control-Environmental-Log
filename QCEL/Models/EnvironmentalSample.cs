using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCEL.Models
{
	public class EnvironmentalSample
	{
		public int Id { get; set; }

		/// <summary>
		/// Date that sample was collected
		/// </summary>
		public DateTime? CollectionDate { get; set; }

		/// <summary>
		/// Sample number for environmental sample
		/// </summary>
		public string SampleNumber { get; set; }

		/// <summary>
		/// Location of the swab site
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Type of test that will be performed
		/// </summary>
		public string MicroTest { get; set; }

		/// <summary>
		/// Equipment that will be used and quantity of equipment
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Swab site location number
		/// </summary>
		public string Zone { get; set; }

		/// <summary>
		/// Type of test that will be performed (Sponge, Water, Air Plates)
		/// </summary>
		public string ProductCode { get; set; }

		/// <summary>
		/// Request type for test
		/// </summary>
		public string RequestType { get; set; }

		/// <summary>
		/// Initials of the user that submitted the sample
		/// </summary>
		public string Initials { get; set; }

		/// <summary>
		/// Is the sample pending submission
		/// Default will be false when sample is created
		/// </summary>
		public bool Submitted { get; set; }

		/// <summary>
		/// Has the user printed the label for this sample
		/// Default will be false when sample is created
		/// </summary>
		public bool LabelPrinted { get; set; }
	}
}