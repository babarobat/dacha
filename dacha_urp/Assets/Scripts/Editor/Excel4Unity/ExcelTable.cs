using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml;

public class ExcelTable
{
    private Dictionary <int, Dictionary<int, ExcelTableCell>> cells = new Dictionary<int, Dictionary<int, ExcelTableCell>>();

    public string TableName;
    public int Rows;
    public int Columns;

    public Vector2 Position;

    public ExcelTable()
    {

    }

    public ExcelTable(ExcelWorksheet sheet)
    {
        TableName = sheet.Name;
	if (sheet.Dimension != null)
	{
		Rows = sheet.Dimension.Rows;
		Columns = sheet.Dimension.Columns;
	}
	else
	{
		//empty Sheet
		Rows = 0;
		Columns = 0;
	}
        for (int row = 1; row <= Rows; row++)
        {
            for (int column = 1; column <= Columns; column++)
            {
                string value = ""; //default value for empty cell
		if (sheet.Cells [row, column].Value != null)
		{
			value = sheet.Cells [row, column].Value.ToString ();
		}
                SetValue(row, column, value);
            }
        }
    }

    public ExcelTableCell SetValue(int row, int column, string value)
    {
		CorrectSize(row, column);
        if (!cells.ContainsKey(row))
        {
            cells[row] = new Dictionary<int, ExcelTableCell>();
        }
        if (cells[row].ContainsKey(column))
        {
            cells[row][column].Value = value;

            return cells[row][column];
        }
        else
        {
            ExcelTableCell cell = new ExcelTableCell(row, column, value);
            cells[row][column] = cell;
            return cell;
        }
    }

    public object GetValue(int row, int column)
    {
        ExcelTableCell cell = GetCell(row, column);
        if (cell != null)
        {
            return cell.Value;
        }
        else
        {
            return SetValue(row, column, "").Value;
        }
    }

    public ExcelTableCell GetCell(int row, int column)
    {
        if (cells.ContainsKey(row))
        {
            if (cells[row].ContainsKey(column))
            {
                return cells[row][column];
            }
        }
        return null;
    }

    public void CorrectSize(int row, int column)
    {
        Rows = Mathf.Max(row, Rows);
        Columns = Mathf.Max(column, Columns);
    }

    public void SetCellTypeRow(int rowIndex, ExcelTableCellType type)
    {
        for (int column = 1; column <= Columns; column++)
        {
            ExcelTableCell cell = GetCell(rowIndex, column);
            if (cell != null)
            {
                cell.Type = type;
            }
        }
    }

    public void SetCellTypeColumn(int columnIndex, ExcelTableCellType type, List<string> values = null)
    {
        for (int row = 1; row <= Rows; row++)
        {
            ExcelTableCell cell = GetCell(row, columnIndex);
            if (cell != null)
            {
                cell.Type = type;
                if (values != null)
                {
                    cell.ValueSelected = values;
                }
            }
        }
    }

    public void ShowLog() {
        string msg = "";
        for (int row = 1; row <= Rows; row++)
        {
            for (int column = 1; column <= Columns; column++)
            {
                msg += string.Format("{0} ", GetValue(row, column));
            }
            msg += "\n";
        }
        Debug.Log(msg);
    }


}
