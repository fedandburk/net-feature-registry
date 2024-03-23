namespace Fedandburk.FeatureRegistry;

internal class FeatureRegistryImplementation : IFeatureRegistry
{
    private readonly IDictionary<string, bool> _features = new Dictionary<string, bool>();

    public bool this[Enum feature]
    {
        get => this[feature?.ToString()];
        set => this[feature?.ToString()] = value;
    }

    public bool this[Type feature]
    {
        get => this[feature?.ToString()];
        set => this[feature?.ToString()] = value;
    }

    public bool this[string feature]
    {
        get => Get(feature);
        set => Set(feature, value);
    }

    private bool Get(string feature)
    {
        ArgumentException.ThrowIfNullOrEmpty(feature);

        return _features.TryGetValue(feature, out var isEnabled) && isEnabled;
    }

    private void Set(string feature, bool isEnabled)
    {
        ArgumentException.ThrowIfNullOrEmpty(feature);

        _features[feature] = isEnabled;
    }
}
