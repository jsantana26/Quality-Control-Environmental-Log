using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QCEL.Models;

namespace QCEL.Excel
{
	public static class CreateSheet
	{
		public static void EnvironmentalLabel(EnvironmentalSample sample)
		{
			ExcelConnection excel = new ExcelConnection("Sample Labels");


			var sheet = excel.Sheet;

			//Make sure sheet exists
			if (sheet != null)
			{
				//Format Cell Width
				sheet.Columns[1].ColumnWidth = 8.91;
				sheet.Columns[2].ColumnWidth = 19.18;
				sheet.Columns[3].ColumnWidth = 13.64;

				//Format Row Height
				sheet.Rows[2].RowHeight = 20.25;
				sheet.Rows[3].RowHeight = 20.25;
				sheet.Rows[4].RowHeight = 20.25;
				sheet.Rows[5].RowHeight = 20.25;
				sheet.Rows[6].RowHeight = 20.25;

				//Set Word Wrap for Sample Information Column
				sheet.Columns[2].WrapText = true;

				//Set font family for each column
				sheet.Columns[1].Font.Name = "Calibri";
				sheet.Columns[2].Font.Name = "Calibri";
				sheet.Columns[3].Font.Name = "Calibri";

				//Set font size for each column
				sheet.Columns[1].Font.Size = 8;
				sheet.Columns[2].Font.Size = 8;
				sheet.Columns[3].Font.Size = 7;

				//Title for labels
				sheet.Cells[2, 1].Value = "Product Code";
				sheet.Cells[3, 1].Value = "Location:";
				sheet.Cells[4, 1].Value = "Date/Time";
				sheet.Cells[5, 1].Value = "Lot #";
				sheet.Cells[6, 1].Value = "QC Initials";

				//Sample information
				sheet.Cells[2, 2].Value = sample.SampleNumber;
				sheet.Cells[3, 2].Value = sample.Location;
				sheet.Cells[3, 3].Value = sample.Location;
				sheet.Cells[4, 2].NumberFormat = "mm/dd/yyyy";
				sheet.Cells[4, 2].Value = sample.CollectionDate;
				sheet.Cells[6, 2].Value = sample.Initials;

				excel.OpenExcel();
			}
		}

		
	}
}