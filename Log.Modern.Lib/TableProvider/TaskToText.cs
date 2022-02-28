using DataToTable;

namespace Log.Modern.Lib;

public abstract class TaskToText
    : ModelATable<Data.Task>
{
    protected TaskToText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Data.Task> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected string GetId(Data.Task t) => 
		t.Id.ToString();
	
	protected string GetCategory(Data.Task t) => 
		t.Category.Name.ToString();

	protected string GetCategoryId(Data.Task t) => 
		t.CategoryId.ToString();
}