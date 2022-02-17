using System.ComponentModel.DataAnnotations;
using CommandDotNet;

namespace Log.Modern.Lib;

public class  LogArg : IArgumentModel
{
    private const string DateFormat = "dd.MM.yyyy HH:mm";
    private const string IdError = "Id must be greater than zero";

    [Operand(nameof(TaskId)), Required, Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int TaskId { get; set; }

    [Operand(nameof(Description)), MaxLength(70)]
    public string? Description { get; set; }

    [Operand(nameof(PlaceId)), Required, Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int PlaceId { get; set; } = 1;    

    [Operand(nameof(Start), Description = DateFormat), Required]
    public DateTime Start { get; set; } = DateTime.Now;

    [Operand(nameof(End), Description = DateFormat)]
    public DateTime? End { get; set; } = default;    
}