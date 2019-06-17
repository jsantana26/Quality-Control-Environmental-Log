using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QCEL.Models;

namespace QCEL.ViewModels
{
	public class DateRangeViewModel
	{
		public List<EnvironmentalSample> EnvironmentalSamples { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
	}
}