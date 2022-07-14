using DotNetExtension;

namespace Log.Modern.Lib;

[AtLeastOneProperty("Name", "Description", ErrorMessage="You must supply Name or Description")]
public class PlaceArgUpdate : ModelAUpdateArgs
{
}