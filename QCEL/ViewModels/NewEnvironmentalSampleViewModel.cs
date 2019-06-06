using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QCEL.Models;

namespace QCEL.ViewModels
{
	public class NewEnvironmentalSampleViewModel
	{
		public IEnumerable<SampleLocation> SampleLocations { get; set; }
		public EnvironmentalSample EnvironmentalSample { get; set; }
	}
}