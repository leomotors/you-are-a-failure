using Windows.UI;
using Windows.UI.Xaml.Input;

#nullable enable

namespace YouAreAFailure.Controls;

public sealed partial class ExternalLink : UserControl {
    private static readonly Color lightNormalExtLink =
         Color.FromArgb(255, 0, 62, 146);

    private static readonly Color ExtLinkColor =
        App.Current.IsLightTheme
            ? lightNormalExtLink
            : Color.FromArgb(255, 153, 235, 255);

    private static readonly bool isLightTheme = App.Current.IsLightTheme;

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

    private void OnPointerEntered(object sender, PointerRoutedEventArgs e) {
        if (isLightTheme) {
            ExtIcon.Foreground =
                new SolidColorBrush(Color.FromArgb(255, 0, 26, 104));
        }
    }

    private void OnPointerExited(object sender, PointerRoutedEventArgs e) {
        if (isLightTheme) {
            ExtIcon.Foreground =
                new SolidColorBrush(lightNormalExtLink);
        }
    }
}
