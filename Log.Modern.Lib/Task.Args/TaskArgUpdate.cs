using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using ModelHelper;

namespace Log.Modern.Lib;

[AtLeastOneProperty("CategoryId", "Name", "Description", ErrorMessage="You must supply Name or Description or CategoryId")]
public class  TaskArgUpdate : ModelAUpdateArgs
    , IArgumentModel, IId
{
    [Option(
        'c'
        ,"categoryId")
        , Range(1, int.MaxValue, ErrorMessage = "Id must be greater than zero")]
    public int? CategoryId { get; set; }
}