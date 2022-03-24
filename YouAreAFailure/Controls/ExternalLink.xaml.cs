using Windows.UI;

#nullable enable

namespace YouAreAFailure.Controls;

public sealed partial class ExternalLink : UserControl {
    private static readonly Color ExtLinkColor =
        App.Current.IsLightTheme
            ? Color.FromArgb(255, 0, 62, 146)
            : Color.FromArgb(255, 153, 235, 255);

    public ExternalLink() {
        this.InitializeComponent();

        ExtIcon.Foreground = new SolidColorBrush(ExtLinkColor);
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
