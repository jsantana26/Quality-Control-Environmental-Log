using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCEL.Models
{
	public class SampleLocation
	{
		public int Id { get; set; }
		/// <summary>
		/// Sample number for test
		/// </summary>
		public string SampleNumber { get; set; }

		/// <summary>
		/// Location of which area was tested
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Type of test performed for the sample
		/// </summary>
		public string MicroTest { get; set; }

		/// <summary>
		/// Type of sample that was taken
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Zone of location tested
		/// </summary>
		public string Zone { get; set; }

		/// <summary>
		/// Product code for the instrument used for the testing
		/// </summary>
		public string ProductCode { get; set; }

		/// <summary>
		/// Type of test that was taken
		/// </summary>
		public string RequestType { get; set; }
	}
}