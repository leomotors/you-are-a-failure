using Windows.Foundation;
using Windows.System;

#nullable enable

namespace YouAreAFailure.Classes;

public static class Bruh {
    public static IAsyncOperation<bool> RickRoll() {
        return Launcher.LaunchUriAsync(
            new Uri(Constants.RickRoll)
        );
    }
}
