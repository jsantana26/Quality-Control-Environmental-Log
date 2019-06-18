using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QCEL.Models;

namespace QCEL.Excel
{
	public static class CreateSheet
	{
		public static void EnvironmentalLabel(List<EnvironmentalSample> samples)
		{
			ExcelConnection excel = new ExcelConnection("Sample Labels");


			var sheet = excel.Sheet;

			// Go through every sample in the list
			for (var i = 0; i < samples.Count; i++)
			{
				//Samples will be formatted into two columns, then it will go to the next line

				// Column number will be either 1 or 2
				// If sample is odd, it will go to first column of labels (Column 1 in excel)
				// If sample is even, it will go to the second column of labels (Column 5 in excel)
				int column = (i % 2 == 0) ? 1 : 5;

				// Since there are 5 rows of information and 1 empty row, it will place the label information every six rows
				// Divide by 2 and round down because there will be 2 labels per row of labels,
				//		0/2 = 0, 1/2 = 0, 2/2 = 1, 3/2 = 1, 4/2 = 2, 5/2 = 2
				//		The result will be the row where label will be placed
				// Multiply by six because there will be six rows of information on the label, so we want to move down by 6 every time
				// Add 2 because the sheet starts 2 rows from the top, leaving 2 empty rows
				var row = (Math.Floor((double) i / 2) * 6) + 2;

				//Format Cell Width
				sheet.Columns[column].ColumnWidth = 8.91;
				sheet.Columns[column + 1].ColumnWidth = 19.18;
				sheet.Columns[column + 2].ColumnWidth = 13.64;

				//Format Row Height
				sheet.Rows[row].RowHeight = 20.25;
				sheet.Rows[row + 1].RowHeight = 20.25;
				sheet.Rows[row + 2].RowHeight = 20.25;
				sheet.Rows[row + 3].RowHeight = 20.25;
				sheet.Rows[row + 4].RowHeight = 20.25;

				//Set Word Wrap for Sample Information Column
				sheet.Columns[column + 1].WrapText = true;

				//Set font family for each column
				sheet.Columns[column].Font.Name = "Calibri";
				sheet.Columns[column + 1].Font.Name = "Calibri";
				sheet.Columns[column + 2].Font.Name = "Calibri";

				//Set font size for each column
				sheet.Columns[column].Font.Size = 8;
				sheet.Columns[column + 1].Font.Size = 8;
				sheet.Columns[column + 2].Font.Size = 7;

				//Title for labels
				sheet.Cells[row, column].Value = "Product Code";
				sheet.Cells[row + 1, column].Value = "Location:";
				sheet.Cells[row + 2, column].Value = "Date/Time";
				sheet.Cells[row + 3, column].Value = "Lot #";
				sheet.Cells[row + 4, column].Value = "QC Initials";

				//Sample information
				sheet.Cells[row, column + 1].Value = samples[i].SampleNumber;
				sheet.Cells[row + 1, column + 1].Value = samples[i].Location;
				sheet.Cells[row + 1, column + 2].Value = samples[i].Description;
				sheet.Cells[row + 2, column + 1].NumberFormat = "mm/dd/yyyy h:mmAM/PM";
				sheet.Cells[row + 2, column + 1].Value = samples[i].CollectionDate;
				sheet.Cells[row + 4, column + 1].Value = samples[i].Initials;
			}
			excel.OpenExcel();
		}

		public static void SarfForm(List<EnvironmentalSample> samples)
		{
			ExcelConnection excel = new ExcelConnection(System.Web.HttpContext.Current.Server.MapPath("~/Content/Template Files/JelSert_MP Analysis Request Form Environmental_021119 - Protected.xlsx"), "SARF Form");

			var sheet = excel.Sheet;

			//Var j will keep track of the sample in the observable collection
			var j = 0;
			//Var i will keep track of the row number in the excel sheet
			for (var i = 10; i < samples.Count() + 10; i++, j++)
			{
				//Default request number to empty string
				var RequestNumber = "";


				//Write the sample information to the excel sheet
				sheet.Cells[i, 2].Value = samples[j].SampleNumber;		//Sample Number
				sheet.Cells[i, 3].Value = samples[j].Location;		//Room Area
				sheet.Cells[i, 4].Value = samples[j].Zone;				//Zone
				sheet.Cells[i, 5].Value = samples[j].Description;			//Location
				sheet.Cells[i, 6].NumberFormat = "mm/dd/yy";			//Format date
				sheet.Cells[i, 6].Value = samples[j].CollectionDate;	//Date
				//TODO:Add textbox for request number
				sheet.Cells[i, 8].Value = RequestNumber;				//Request Number 
			}

			//Open the request form in excel
			excel.OpenExcel();
		}
	}
}