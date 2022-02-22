using DataToTable;

namespace Log.Modern.Lib;

public abstract class TaskToColumn
    : TaskToText
{
    protected TaskToColumn(
		IColumnCalculator<Data.Task> columnCalculator) 
			: base(columnCalculator)
    {
    }

	protected List<int> GetIdLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetId(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.Id).Length);
		return rows;
	}

	protected List<int> GetNameLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => m.Name.Length).ToList();
		rows.Insert(0, nameof(Data.Task.Name).Length);
		return rows;
	}

	protected List<int> GetCategoryLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetCategory(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.Category).Length);
		return rows;
	}

	protected List<int> GetCategoryIdLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetCategoryId(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.CategoryId).Length);
		return rows;
	}

	protected List<int> GetDescriptionLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => m.Description.Length).ToList();
		rows.Insert(0, nameof(Data.Task.Description).Length);
		return rows;
	}
}