using System;
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
/// The page that lists all the motivational video.
/// </summary>
public sealed partial class VideoList : Page
{
    public static Action<string> OnListViewClickHandler { get; set; }

    public VideoList()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        for (int i = 0; i < Classes.Steven.VideoList.Length; i++)
        {
            VideoListView.Items.Add(new TextBlock
            {
                Text = Classes.Steven.VideoList[i].FileName
                        + (App.Current.State.Watched[i] ? " ✅" : "")
            }
            );
        }

        base.OnNavigatedTo(e);
    }

    private void VideoListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is not TextBlock clicked) return;

        if (OnListViewClickHandler is not null)
        {
            OnListViewClickHandler(clicked.Text.Split(" ")[0]);
        }
    }
}
