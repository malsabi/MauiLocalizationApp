using System.ComponentModel;

namespace MauiLocalizationApp;

public class FlowDirectionExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        Binding binding = new()
        {
            Mode = BindingMode.OneWay,
            Source = ChangeDirection.Instance,
            Path = "[KeyName]"
        };
        return binding;
    }
}

public class ChangeDirection : INotifyPropertyChanged
{
    public FlowDirection this[string key] => FlowDirection;

    public FlowDirection FlowDirection { get; set; } = FlowDirection.LeftToRight;

    public event PropertyChangedEventHandler? PropertyChanged;

    public static ChangeDirection Instance { get; } = new();

    /// <summary>
    /// We added INotifyPropertyChanged so that it can work in runtime by notifying the UI
    /// No need to subscribe to the event PropertyChanged, MAUI will automatically subscribe to it 
    /// because our class is implementing the Interface INotifyPropertyChanged
    /// </summary>
    /// <param name="flowDirection"></param>
    public void SetFlowDirection(FlowDirection flowDirection)
    {
        FlowDirection = flowDirection;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}