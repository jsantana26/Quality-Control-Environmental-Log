using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace QCEL.Excel
{
	public class ExcelConnection
	{
		private _Application _excel = new _Excel.Application();
		private Workbook _workbook;
		private Workbooks _workbooks;
		public Worksheet Sheet { get; private set; }

		public ExcelConnection(string sheetName)
		{
			_excel.SheetsInNewWorkbook = 1;
			_workbooks = _excel.Workbooks;
			_workbook = _workbooks.Add(Missing.Value);
			Sheet = _workbook.Worksheets[1];
			Sheet.Name = sheetName;

		}

		public ExcelConnection(string templateFile, string sheetName)
		{
			_workbooks = _excel.Workbooks;
			_workbook = _workbooks.Open(templateFile, false, true);
			Sheet = _workbook.Worksheets[1];
			Sheet.Name = sheetName;
		}

		public void OpenExcel()
		{
			_excel.Visible = true;
		}

		public void CloseConnection()
		{
			if (_excel != null)
			{
				_excel.DisplayAlerts = false;
				Marshal.ReleaseComObject(Sheet);

				_workbook.Close(false);
				Marshal.ReleaseComObject(_workbook);
				Marshal.ReleaseComObject(_workbooks);

				_excel.Application.Quit();
				_excel.Quit();
				Marshal.ReleaseComObject(_excel);

				Sheet = null;
				_workbook = null;
				_workbooks = null;
				_excel = null;

				GC.WaitForPendingFinalizers();
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
			}
		}
	}
}