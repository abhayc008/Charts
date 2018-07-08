using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Common
{
    public class ExportExcelOpenXML
    {
        //public void ExportDataSet(DataSet ds, string destination, string fileName)
        //{
        //    try
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {

        //            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
        //            {
        //                var workbookPart = workbook.AddWorkbookPart();

        //                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

        //                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

        //                WorkbookStylesPart stylesPart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();
        //                stylesPart.Stylesheet = GenerateStyleSheet();
        //                stylesPart.Stylesheet.Save();

        //                foreach (System.Data.DataTable table in ds.Tables)
        //                {
        //                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
        //                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
        //                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

        //                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
        //                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

        //                    uint sheetId = 1;
        //                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
        //                    {
        //                        sheetId =
        //                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
        //                    }

        //                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
        //                    sheets.Append(sheet);

        //                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

        //                    List<String> columns = new List<string>();
        //                    foreach (System.Data.DataColumn column in table.Columns)
        //                    {
        //                        columns.Add(column.ColumnName);

        //                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
        //                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
        //                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
        //                        cell.StyleIndex = 3;
        //                        headerRow.AppendChild(cell);
        //                    }


        //                    sheetData.AppendChild(headerRow);

        //                    foreach (System.Data.DataRow dsrow in table.Rows)
        //                    {
        //                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
        //                        foreach (String col in columns)
        //                        {
        //                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
        //                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
        //                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
        //                            newRow.AppendChild(cell);
        //                        }

        //                        sheetData.AppendChild(newRow);
        //                    }
        //                }
        //            }
        //            downloadfile(destination, fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsHeader">Custom Header DataSet</param>
        /// <param name="ds">Actual dataset with values</param>
        /// <param name="customHeader">True: Use custom header dataset, False: used table header</param>
        /// <param name="destination">File location with name</param>
        public void ExportDataSet(DataSet dsHeader, DataSet ds, bool customHeader, string filename, string exportFileName)
        {
            string dbFilePath = "/DownloadExcel/";
            string strFileName = GenerateFileName(filename) + "xlsx";
            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~" + dbFilePath)))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~" + dbFilePath));
            }

            string destination = System.Web.HttpContext.Current.Server.MapPath("~" + dbFilePath) + strFileName;

            try
            {
                if ((dsHeader.Tables.Count == ds.Tables.Count && customHeader) || !customHeader)
                {
                    List<KeyValuePair<string, string>> mergecellsdictionary = new List<KeyValuePair<string, string>>();

                    using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
                    {
                        var workbookPart = workbook.AddWorkbookPart();

                        workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                        workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                        WorkbookStylesPart stylesPart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                        stylesPart.Stylesheet = GenerateStyleSheet();
                        stylesPart.Stylesheet.Save();

                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                            var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                            sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                            DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                            string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                            uint sheetId = 1;
                            if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                            {
                                sheetId = sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                            }

                            DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = ds.Tables[i].TableName };
                            sheets.Append(sheet);

                            DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();


                            List<String> columns = new List<string>();
                            if (customHeader)
                            {
                                foreach (System.Data.DataColumn column in dsHeader.Tables[i].Columns)
                                {
                                    columns.Add(column.ColumnName);
                                }
                                int rIndex = 1;
                                foreach (System.Data.DataRow dsrow in dsHeader.Tables[i].Rows)
                                {
                                    headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                                    foreach (String col in columns)
                                    {
                                        string[] strval = Convert.ToString(dsrow[col]).Split(',');
                                        if (strval.Length == 4)
                                        {
                                            // Check for rowspan
                                            if (!string.IsNullOrEmpty(strval[2]) && strval[2].All(Char.IsDigit))
                                            {
                                                if (Convert.ToInt32(strval[2]) > 1)
                                                {
                                                    int rpos = (columns.IndexOf(col)) + 1;
                                                    mergecellsdictionary.Add(new KeyValuePair<string, string>(sheet.Name, getColumnNameFromIndex(rpos) + rIndex.ToString() + "," + getColumnNameFromIndex(rpos) + (rIndex + Convert.ToInt32(strval[2]) - 1).ToString()));
                                                }
                                            }

                                            // Check for colspan
                                            if (!string.IsNullOrEmpty(strval[3]) && strval[3].All(Char.IsDigit))
                                            {
                                                if (Convert.ToInt32(strval[3]) > 1)
                                                {
                                                    int cpos = (columns.IndexOf(col)) + 1;
                                                    mergecellsdictionary.Add(new KeyValuePair<string, string>(sheet.Name, getColumnNameFromIndex(cpos) + rIndex.ToString() + "," + getColumnNameFromIndex(cpos + Convert.ToInt32(strval[3]) - 1) + rIndex.ToString()));
                                                }
                                            }
                                        }
                                        else if (strval.Length == 1)
                                        {
                                            string str1 = strval[0];
                                            strval = new string[] { str1, "1" };
                                        }
                                        int indexNum = (strval[1].All(Char.IsDigit)) ? Convert.ToInt32(strval[1]) : 1;

                                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(strval[0]);
                                        cell.StyleIndex = (UInt32)indexNum;
                                        headerRow.AppendChild(cell);
                                    }
                                    sheetData.AppendChild(headerRow);
                                    rIndex = rIndex + 1;
                                }
                            }
                            else
                            {
                                foreach (System.Data.DataColumn column in ds.Tables[i].Columns)
                                {
                                    columns.Add(column.ColumnName);

                                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                                    cell.StyleIndex = 1; // The light gray Fill
                                    headerRow.AppendChild(cell);
                                }

                                sheetData.AppendChild(headerRow);
                            }

                            foreach (System.Data.DataRow dsrow in ds.Tables[i].Rows)
                            {
                                DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                                foreach (String col in columns)
                                {
                                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                    //cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                    if (IsDouble(dsrow[col].ToString()))
                                    {
                                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                                    }
                                    else
                                    {
                                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                    }
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                                    newRow.AppendChild(cell);
                                }

                                sheetData.AppendChild(newRow);
                            }
                        }
                    }
                    if (mergecellsdictionary.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> entry in mergecellsdictionary)
                        {
                            string[] strcells = entry.Value.Split(',');
                            mergeCell(destination, entry.Key, strcells[0], strcells[1]);
                        }
                    }

                    downloadfile(destination, exportFileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (System.IO.File.Exists(destination))
                {
                    System.IO.File.Delete(destination);
                }
            }
        }

        private bool downloadfile(string PathToExcelFile, string export_FileName)
        {
            bool isdownloaded = true;
            try
            {
                FileInfo file = new FileInfo(PathToExcelFile);
                if (file.Exists)
                {
                    HttpResponse response = System.Web.HttpContext.Current.Response;

                    response.Clear();
                    response.ClearHeaders();
                    response.ClearContent();
                    response.AddHeader("content-disposition", "attachment; filename=" + export_FileName + ".xlsx");
                    response.AddHeader("Content-Type", "application/Excel");
                    response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    response.AddHeader("Content-Length", file.Length.ToString());
                    response.WriteFile(file.FullName);
                    response.End();
                }
            }
            catch (Exception ex)
            {
                isdownloaded = false;
            }

            return isdownloaded;
        }

        private Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 - The default font.
                        new DocumentFormat.OpenXml.Spreadsheet.FontSize() { Val = 11 },
                //new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 - The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),

                    new Fill(                                                           // Index 1 - Index 1 - The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),

                    new Fill(                                                           // Index 2 - The light gray fill.
                        new PatternFill(
                             new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "CFD8DC" } }
                            ) { PatternType = PatternValues.Solid }),

                     new Fill(                                                           // Index 3 - The light yellow fill.
                        new PatternFill(
                             new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FCF299" } }
                            ) { PatternType = PatternValues.Solid }),

                    new Fill(                                                           // Index 4 - The light green fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "CAEB96" } }
                        ) { PatternType = PatternValues.Solid }),

                    new Fill(                                                           // Index 5 - The light pink fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "F4D1FD" } }
                        ) { PatternType = PatternValues.Solid })

                ),
                new Borders(
                    new Border(                                                         // Index 0 - The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
                        new LeftBorder( new Color() { Auto = true } ) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true } ) { Style = BorderStyleValues.Thin },
                        new TopBorder( new Color() { Auto = true }  ) { Style = BorderStyleValues.Thin },
                        new BottomBorder( new Color() { Auto = true } ) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FillId = 0, ApplyFill = true },      // Index 0 - The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FillId = 2, BorderId = 1, ApplyFill = true, ApplyBorder = true},      // Index 1 - light gray fill
                    new CellFormat() { FillId = 3, BorderId = 1, ApplyFill = true, ApplyBorder = true },      // Index 2 - light yellow fill
                    new CellFormat() { FillId = 4, BorderId = 1, ApplyFill = true, ApplyBorder = true },      // Index 3 - light green fill
                    new CellFormat() { FillId = 5, BorderId = 1, ApplyFill = true, ApplyBorder = true }       // Index 4 - light pink fill
                )
            ); // return
        }

        private static String getColumnNameFromIndex(int column)
        {
            column--;
            String col = Convert.ToString((char)('A' + (column % 26)));
            while (column >= 26)
            {
                column = (column / 26) - 1;
                col = Convert.ToString((char)('A' + (column % 26))) + col;
            }
            return col;
        }

        private string GenerateFileName(string strfile)
        {
            return strfile + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");
        }

        private static bool IsDouble(string s)
        {
            double dOutput = 0;
            if (Double.TryParse(s, out dOutput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Merge excel cells

        public void mergeCell(string doc, string sheet, string c1, string c2)
        {
            string docName = doc;
            string sheetName = sheet;
            string cell1Name = c1;
            string cell2Name = c2;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, true))
            {
                Worksheet worksheet = GetWorksheet(document, sheetName);
                // Create Spreadsheet cells.
                //CreateSpreadsheetCell(worksheet, cell1Name);
                //CreateSpreadsheetCell(worksheet, cell2Name);
                MergeCells mergeCells;

                if (worksheet.Elements<MergeCells>().Count() > 0)
                    mergeCells = worksheet.Elements<MergeCells>().First();
                else
                {
                    mergeCells = new MergeCells();

                    // Insert a MergeCells object into the specified position.
                    if (worksheet.Elements<CustomSheetView>().Count() > 0)
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<CustomSheetView>().First());
                    else
                        worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetData>().First());
                }

                // Create the merged cell and append it to the MergeCells collection.
                MergeCell mergeCell = new MergeCell()
                {
                    Reference =
                        new StringValue(cell1Name + ":" + cell2Name)
                };
                mergeCells.Append(mergeCell);
                worksheet.Save();
            }
        }

        // Get the specified worksheet.
        private static Worksheet GetWorksheet(SpreadsheetDocument document, string worksheetName)
        {
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook
                .Descendants<Sheet>().Where(s => s.Name == worksheetName);
            WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart
                .GetPartById(sheets.First().Id);
            return worksheetPart.Worksheet;
        }

        // Create a spreadsheet cell. 
        private static void CreateSpreadsheetCell(Worksheet worksheet, string cellName)
        {
            string columnName = GetColumnName(cellName);
            uint rowIndex = GetRowIndex(cellName);
            IEnumerable<Row> rows = worksheet.Descendants<Row>().Where(r => r
                .RowIndex.Value == rowIndex);
            Row row = rows.First();
            IEnumerable<Cell> cells = row.Elements<Cell>().Where(c => c.CellReference
                .Value == cellName);
        }

        // Parse the cell name to get the column name.
        private static string GetColumnName(string cellName)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellName);
            return match.Value;
        }

        // Given a cell name, parses the specified cell to get the row index.
        private static uint GetRowIndex(string cellName)
        {
            // Create a regular expression to match the row index portion the cell name.
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(cellName);

            return uint.Parse(match.Value);
        }

        #endregion

    }
}
