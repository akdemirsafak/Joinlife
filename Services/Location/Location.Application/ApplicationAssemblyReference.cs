using System.Reflection;

namespace Location.Application;

public static class ApplicationAssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
