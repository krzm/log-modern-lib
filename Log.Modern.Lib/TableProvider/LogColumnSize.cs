using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public abstract class LogColumnSize : LogText
{
    protected LogColumnSize(
		IColumnCalculator<LogModel> columnCalculator) 
			: base(columnCalculator)
    {
    }

    protected List<int> GetIdLengths(List<LogModel> models)
	{
		var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(LogModel.Id).Length);
		return rows;
	}

	protected List<int> GetTaskLengths(List<LogModel> models)
	{
		var rows = models.Select(e => e.Task.Name.Length).ToList();
		rows.Insert(0, nameof(LogModel.Task).Length);
		return rows;
	}

	protected List<int> GetTaskIdLengths(List<LogModel> models)
	{
		var rows = models.Select(e => e.TaskId.ToString().Length).ToList();
		rows.Insert(0, nameof(LogModel.TaskId).Length);
		return rows;
	}

	protected List<int> GetCategoryLengths(List<LogModel> models)
	{
		var rows = models.Select(e => e.Task.Category.Name.Length).ToList();
		rows.Insert(0, nameof(LogModel.Task.Category).Length);
		return rows;
	}

	protected List<int> GetCategoryIdLengths(List<LogModel> models)
	{
		var rows = models.Select(e => e.Task.CategoryId.ToString().Length).ToList();
		rows.Insert(0, nameof(LogModel.Task.CategoryId).Length);
		return rows;
	}

	protected List<int> GetStartLengths(List<LogModel> models)
	{
		var rows = models.Select(e => GetStart(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.Start).Length);
		return rows;
	}

	protected List<int> GetEndLengths(List<LogModel> models)
	{
		var rows = models.Select(e => GetEnd(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.End).Length);
		return rows;
	}

	protected List<int> GetTimeLengths(List<LogModel> models)
    {
		var rows = models.Select(e => e.Time.ToString().Length).ToList();
		rows.Insert(0, nameof(LogModel.Time).Length);
		return rows;
    }

	protected List<int> GetDescriptionLengths(List<LogModel> models)
	{
		var rows = models.Select(e => GetDescription(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.Description).Length);
		return rows;
	}

	protected List<int> GetPlaceLengths(List<LogModel> models)
	{
		var rows = models.Select(e => e.Place.Name.Length).ToList();
		rows.Insert(0, nameof(LogModel.Place).Length);
		return rows;
	}
}