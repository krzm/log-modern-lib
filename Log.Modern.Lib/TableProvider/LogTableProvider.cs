using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class LogTableProvider 
	: LogToColumn
{
	public LogTableProvider(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<LogModel> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected override void CreateTableHeader()
	{
		AddColumns();
	}

	private void AddColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(LogModel.Id)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Task)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.TaskId)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Task.Category)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Task.CategoryId)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Start)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.End)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Time)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Description)));
		Editor.AddColumn(GetColumnData(nameof(LogModel.Place)));
	}

	protected override void CreateTableRow(LogModel l)
    {
        Editor.AddValue(GetColumnData(nameof(LogModel.Id)), GetId(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Task)), GetTask(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.TaskId)), GetTaskId(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Task.Category)), GetCategory(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Task.CategoryId)), GetCategoryId(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Start)), GetStart(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.End)), GetEnd(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Time)), GetTime(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Description)), GetDescription(l));
        Editor.AddValue(GetColumnData(nameof(LogModel.Place)), GetPlace(l));
    }

    protected override void SetColumnsSize(List<LogModel> l)
	{
		SetColumn(nameof(LogModel.Id), GetIdLengths(l));
		SetColumn(nameof(LogModel.Task), GetTaskLengths(l));
		SetColumn(nameof(LogModel.TaskId), GetTaskIdLengths(l));
        SetColumn(nameof(LogModel.Task.Category), GetCategoryLengths(l));
        SetColumn(nameof(LogModel.Task.CategoryId), GetCategoryIdLengths(l));
		SetColumn(nameof(LogModel.Start), GetStartLengths(l));
		SetColumn(nameof(LogModel.End), GetEndLengths(l));
		SetColumn(nameof(LogModel.Time), GetTimeLengths(l));
		SetColumn(nameof(LogModel.Description), GetDescriptionLengths(l));
		SetColumn(nameof(LogModel.Place), GetPlaceLengths(l));
	}   
}