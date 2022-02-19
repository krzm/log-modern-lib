using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public abstract class LogText
    : TextTable<LogModel>
{
	private const string DateTimeFormat1 = "dd.MM.yyyy HH:mm";
	private const string DateTimeFormat2 = "HH:mm";
	
    protected LogText(
		IColumnCalculator<LogModel> columnCalculator) 
			: base(columnCalculator)
    {
    }

	protected string GetId(LogModel l) => 
		l.Id.ToString();
	
	protected string GetTask(LogModel l) =>
		l.Task.Name;

    protected string GetTaskId(LogModel l) => 
		l.TaskId.ToString();

	protected string GetCategory(LogModel l) => 
		l.Task.Category.Name.ToString();

	protected string GetCategoryId(LogModel l) => 
		l.Task.CategoryId.ToString();

	protected string GetStart(LogModel l) =>
		l.Start.HasValue ?
			l.Start.Value.ToString(DateTimeFormat1) : "";

    protected string GetEnd(LogModel l) => 
		l.End.HasValue ?
			l.End.Value.ToString(DateTimeFormat2) : "";

    protected string GetTime(LogModel l) => 
		$"{l.Time.Hours}:{l.Time.Minutes}";
	
	protected string GetDescription(LogModel l) => 
		string.IsNullOrWhiteSpace(l.Description) == false ? 
			l.Description : "";
	
	protected string GetPlaceName(LogModel l) =>
		l.Place.Name;
}