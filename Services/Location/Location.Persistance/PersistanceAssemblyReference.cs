using System.Reflection;

namespace Location.Persistance;

public static class PersistanceAssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
