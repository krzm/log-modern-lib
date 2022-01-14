using DataToTable;

namespace Log.Modern.Lib;

public class TaskTableProvider : ModelATable<Data.Task>
{
	public TaskTableProvider(
		IColumnCalculator<Data.Task> columnCalculator) : base(columnCalculator)
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
		AddColumn(GetColumnData(nameof(Data.Task.Description)));
	}

	protected override void CreateTableRow(Data.Task e)
	{
		AddValue(GetColumnData(nameof(Data.Task.Id)), e.Id.ToString());
		AddValue(GetColumnData(nameof(Data.Task.Name)), e.Name);
		AddValue(GetColumnData(nameof(Data.Task.Category)), e.Category.Name);
		AddValue(GetColumnData(nameof(Data.Task.Description)), e.Description);
	}

	protected override void SetColumnsSize(List<Data.Task> items)
	{
		SetColumn(nameof(Data.Task.Id), GetIdsLength(items));
		SetColumn(nameof(Data.Task.Name), GetNamesLength(items));
		SetColumn(nameof(Data.Task.Category), GetCategoriesLength(items));
		SetColumn(nameof(Data.Task.Description), GetDescriptionsLength(items));
	}

	private List<int> GetIdsLength(List<Data.Task> models)
	{
		var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(Data.Task.Id).Length);
		//Max here, move this to other class
		return rows;
	}

	private List<int> GetNamesLength(List<Data.Task> models)
	{
		var rows = models.Select(e => e.Name.Length).ToList();
		rows.Insert(0, nameof(Data.Task.Name).Length);
		return rows;
	}

	private List<int> GetCategoriesLength(List<Data.Task> models)
	{
		var rows = models.Select(e => e.Category.Name.Length).ToList();
		rows.Insert(0, nameof(Data.Task.Category).Length);
		return rows;
	}

	private List<int> GetDescriptionsLength(List<Data.Task> models)
	{
		var rows = models.Select(e => e.Description.Length).ToList();
		rows.Insert(0, nameof(Data.Task.Description).Length);
		return rows;
	}
}