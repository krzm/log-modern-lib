using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class LogTableProvider : TextTable<LogModel>
{
	private const string DateTimeFormat1 = "dd.MM.yyyy HH:mm";
	private const string DateTimeFormat2 = "HH:mm";

	public LogTableProvider(
		IColumnCalculator<LogModel> columnCalculator) : base(columnCalculator)
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
		AddColumn(GetColumnData(nameof(LogModel.Start)));
		AddColumn(GetColumnData(nameof(LogModel.End)));
		//AddColumn(GetColumnData(nameof(LogModel.Time)));
		AddColumn(GetColumnData(nameof(LogModel.Description)));
		AddColumn(GetColumnData(nameof(LogModel.Place)));
	}

	protected override void CreateTableRow(LogModel log)
    {
        AddValue(GetColumnData(nameof(LogModel.Id)), log.Id.ToString());
        AddValue(GetColumnData(nameof(LogModel.Task)), log.Task.Name);
        AddValue(GetColumnData(nameof(LogModel.TaskId)), log.TaskId.ToString());
        AddValue(GetColumnData(nameof(LogModel.Start)), GetStart(log));
        AddValue(GetColumnData(nameof(LogModel.End)), GetEnd(log));
        //AddValue(GetColumnData(nameof(LogModel.Time)), $"{e.Time.Hours}:{e.Time.Minutes}");
        AddValue(GetColumnData(nameof(LogModel.Description)), GetDescription(log));
        AddValue(GetColumnData(nameof(LogModel.Place)), log.Place.Name);
    }

    private static string GetStart(LogModel log)
    {
        return log.Start.HasValue ? log.Start.Value.ToString(DateTimeFormat1) : "";
    }

    private static string GetEnd(LogModel log)
    {
        return log.End.HasValue ? log.End.Value.ToString(DateTimeFormat2) : "";
    }

	private static string GetDescription(LogModel log)
    {
        return string.IsNullOrWhiteSpace(log.Description) == false ? log.Description : "";
    }

    protected override void SetColumnsSize(List<LogModel> logs)
	{
		SetColumn(nameof(LogModel.Id), GetIdsLength(logs));
		SetColumn(nameof(LogModel.Task), GetTasksLength(logs));
		SetColumn(nameof(LogModel.TaskId), GetTaskIdsLength(logs));
		SetColumn(nameof(LogModel.Start), GetStartsLength(logs));
		SetColumn(nameof(LogModel.End), GetEndsLength(logs));
		//SetColumn(items, nameof(LogModel.Time), GetTimesLength(logs));
		SetColumn(nameof(LogModel.Description), GetDescriptionsLength(logs));
		SetColumn(nameof(LogModel.Place), GetPlacesLength(logs));
	}

	private List<int> GetIdsLength(List<LogModel> models)
	{
		var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(LogModel.Id).Length);
		//todo: Max here needed, move to other class
		return rows;
	}

	private List<int> GetTasksLength(List<LogModel> models)
	{
		var rows = models.Select(e => e.Task.Name.Length).ToList();
		rows.Insert(0, nameof(LogModel.Task).Length);
		return rows;
	}

	private List<int> GetTaskIdsLength(List<LogModel> models)
	{
		var rows = models.Select(e => e.TaskId.ToString().Length).ToList();
		rows.Insert(0, nameof(LogModel.TaskId).Length);
		return rows;
	}

	private List<int> GetStartsLength(List<LogModel> models)
	{
		var rows = models.Select(e => GetStart(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.Start).Length);
		return rows;
	}

	private List<int> GetEndsLength(List<LogModel> models)
	{
		var rows = models.Select(e => GetEnd(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.End).Length);
		return rows;
	}

	private List<int> GetDescriptionsLength(List<LogModel> models)
	{
		var rows = models.Select(e => GetDescription(e).Length).ToList();
		rows.Insert(0, nameof(LogModel.Description).Length);
		return rows;
	}

	private List<int> GetPlacesLength(List<LogModel> models)
	{
		var rows = models.Select(e => e.Place.Name.Length).ToList();
		rows.Insert(0, nameof(LogModel.Place).Length);
		return rows;
	}
}