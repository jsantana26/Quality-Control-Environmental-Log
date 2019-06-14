using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QCEL.Models;

namespace QCEL.ViewModels
{
	public class SubmitSampleViewModel
	{
		public List<EnvironmentalSample> Samples { get; set; }
		public List<EnvironmentalSample> SelectedSamples { get; set; }
	}
}