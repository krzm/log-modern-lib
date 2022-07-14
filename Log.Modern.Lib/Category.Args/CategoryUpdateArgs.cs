using DotNetExtension;
using Log.Data;

namespace Log.Modern.Lib;

[AtLeastOneProperty(
    nameof(Category.Name)
    , nameof(Category.Description)
    , ErrorMessage=UpdateError)]
public class CategoryUpdateArgs
    : ModelAUpdateArgs
{
}