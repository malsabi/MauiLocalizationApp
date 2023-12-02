namespace MauiLocalizationApp;

[ContentProperty(nameof(Name))]
public class TranslateExtension : IMarkupExtension<BindingBase>
{
    public string? Name { get; set; }

    /// <summary>
    /// This method does not work on release mode sometimes a known issue:
    /// https://github.com/dotnet/maui/issues/18697
    /// </summary>
    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Name}]",
            Source = LocalizationResourceManager.Instance
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}