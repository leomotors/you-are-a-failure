#nullable enable

namespace YouAreAFailure.Controls;

public sealed partial class ExternalLink : UserControl {
    public ExternalLink() {
        this.InitializeComponent();
    }

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(ExternalLink),
            new PropertyMetadata(string.Empty)
        );

    public string Url {
        get => (string)GetValue(UrlProperty);
        set => SetValue(UrlProperty, value);
    }

    public static readonly DependencyProperty UrlProperty =
        DependencyProperty.Register(
            nameof(Url),
            typeof(string),
            typeof(ExternalLink),
            new PropertyMetadata(string.Empty)
        );
}
