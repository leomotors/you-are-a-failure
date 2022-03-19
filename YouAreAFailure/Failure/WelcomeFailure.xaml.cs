﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace YouAreAFailure.Failure;

/// <summary>
/// The welcome page.
/// </summary>
public sealed partial class WelcomeFailure : Page
{
    public static Action<Classes.NavigationTarget> Navigator;

    public WelcomeFailure()
    {
        this.InitializeComponent();
    }

    private void GoWatch_Click(object sender, RoutedEventArgs e)
    {
        if (Navigator is not null)
            Navigator(Classes.NavigationTarget.MotivationalVideo);
    }

    private void SeeStats_Click(object sender, RoutedEventArgs e)
    {
        if (Navigator is not null)
            Navigator(Classes.NavigationTarget.Statistics);
    }
}