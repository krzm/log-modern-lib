using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using Core;

namespace Log.Modern.Lib;

public abstract class  ModelAArgUpdate 
    : IArgumentModel, IId
{
    [Operand(
        "id")
        , Required
        , Range(1, int.MaxValue, ErrorMessage = "Id must be greater than zero")]
    public int Id { get; set; }

    [Option(
        'n'
        ,"name")
        , MaxLength(25)]
    public string? Name { get; set; }

    [Option(
        'd'
        ,"description")
        , MaxLength(70)]
    public string? Description { get; set; }
}