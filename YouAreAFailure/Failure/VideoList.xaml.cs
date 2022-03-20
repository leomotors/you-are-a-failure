#nullable enable

namespace YouAreAFailure.Failure;

/// <summary>
/// The page that lists all the motivational video.
/// </summary>
public sealed partial class VideoList : Page
{
    public static Action<string>? OnListViewClickHandler;

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
            OnListViewClickHandler(clicked.Text.Split(" ")[0]);
    }
}
