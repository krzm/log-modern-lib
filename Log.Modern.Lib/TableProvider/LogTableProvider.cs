using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class LogTableProvider 
	: LogColumnSize
{
	public LogTableProvider(
		IColumnCalculator<LogModel> columnCalculator) 
			: base(columnCalculator)
	{
	}

	protected override void CreateTableHeader()
	{
		AddColumns();
	}

	private void AddColumns()
	{
		AddColumn(GetColumnData(nameof(LogModel.Id)));
		AddColumn(GetColumnData(nameof(LogModel.Task)));
		AddColumn(GetColumnData(nameof(LogModel.TaskId)));
		AddColumn(GetColumnData(nameof(LogModel.Task.Category)));
		AddColumn(GetColumnData(nameof(LogModel.Task.CategoryId)));
		AddColumn(GetColumnData(nameof(LogModel.Start)));
		AddColumn(GetColumnData(nameof(LogModel.End)));
		AddColumn(GetColumnData(nameof(LogModel.Time)));
		AddColumn(GetColumnData(nameof(LogModel.Description)));
		AddColumn(GetColumnData(nameof(LogModel.Place)));
	}

	protected override void CreateTableRow(LogModel l)
    {
        AddValue(GetColumnData(nameof(LogModel.Id)), GetId(l));
        AddValue(GetColumnData(nameof(LogModel.Task)), GetTask(l));
        AddValue(GetColumnData(nameof(LogModel.TaskId)), GetTaskId(l));
        AddValue(GetColumnData(nameof(LogModel.Task.Category)), GetCategory(l));
        AddValue(GetColumnData(nameof(LogModel.Task.CategoryId)), GetCategoryId(l));
        AddValue(GetColumnData(nameof(LogModel.Start)), GetStart(l));
        AddValue(GetColumnData(nameof(LogModel.End)), GetEnd(l));
        AddValue(GetColumnData(nameof(LogModel.Time)), GetTime(l));
        AddValue(GetColumnData(nameof(LogModel.Description)), GetDescription(l));
        AddValue(GetColumnData(nameof(LogModel.Place)), GetPlaceName(l));
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