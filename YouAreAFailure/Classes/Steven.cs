using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouAreAFailure.Classes;

public class Video
{
    public readonly string YoutubeLink;
    public readonly string FileName;
    public readonly double Volume;

    public Video(string youtubeLink, string fileName, double volume = 1)
    {
        YoutubeLink = youtubeLink;
        FileName = fileName;
        Volume = volume;
    }
}

/// <summary>
/// Static <b>Constant</b> Class that holds the value of video list
/// </summary>
static public class Steven
{
    public const string VideoRoot = "Assets/Failure";
    public const string VideoExtension = "mp4";

    public static readonly Video[] VideoList = {
            new Video("https://www.youtube.com/watch?v=lO9K7VMFo2Y", "Failure"),
            new Video("https://www.youtube.com/watch?v=VvO_HpyVQWo", "Stupid")
        };
}
