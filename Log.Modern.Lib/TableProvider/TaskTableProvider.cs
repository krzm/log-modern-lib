using DataToTable;

namespace Log.Modern.Lib;

public class TaskTableProvider 
	: TaskToColumn
{
	public TaskTableProvider(
		IColumnCalculator<Data.Task> columnCalculator) 
			: base(columnCalculator)
	{
	}

	protected override void CreateTableHeader()
	{
		AddColumns();
	}

	private void AddColumns()
	{
		AddColumn(GetColumnData(nameof(Data.Task.Id)));
		AddColumn(GetColumnData(nameof(Data.Task.Name)));
		AddColumn(GetColumnData(nameof(Data.Task.Category)));
		AddColumn(GetColumnData(nameof(Data.Task.CategoryId)));
		AddColumn(GetColumnData(nameof(Data.Task.Description)));
	}

	protected override void CreateTableRow(Data.Task t)
	{
		AddValue(GetColumnData(nameof(Data.Task.Id)), GetId(t));
		AddValue(GetColumnData(nameof(Data.Task.Name)), t.Name);
		AddValue(GetColumnData(nameof(Data.Task.Category)), GetCategory(t));
		AddValue(GetColumnData(nameof(Data.Task.CategoryId)), GetCategoryId(t));
		AddValue(GetColumnData(nameof(Data.Task.Description)), t.Description);
	}

	protected override void SetColumnsSize(List<Data.Task> items)
	{
		SetColumn(nameof(Data.Task.Id), GetIdLengths(items));
		SetColumn(nameof(Data.Task.Name), GetNameLengths(items));
		SetColumn(nameof(Data.Task.Category), GetCategoryLengths(items));
		SetColumn(nameof(Data.Task.Category), GetCategoryLengths(items));
		SetColumn(nameof(Data.Task.CategoryId), GetCategoryIdLengths(items));
		SetColumn(nameof(Data.Task.Description), GetDescriptionLengths(items));
	}
}