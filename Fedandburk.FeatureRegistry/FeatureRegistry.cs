using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Fedandburk.FeatureRegistry.Tests")]

namespace Fedandburk.FeatureRegistry;

public static class FeatureRegistry
{
    private static IFeatureRegistry? _default;

    public static IFeatureRegistry Default => _default ??= new FeatureRegistryImplementation();
}
