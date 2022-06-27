using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Log.Modern.Lib;

public class DeleteArgs 
    : IArgumentModel
        , IId
{
    [Operand(
        "id")
        , Required
        , Range(1, int.MaxValue, ErrorMessage = "Id must be greater than zero")]
    public int Id { get; set; }
}