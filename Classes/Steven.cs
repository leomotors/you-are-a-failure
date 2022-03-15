using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace you_are_a_failure.Classes;

public class Video
{
    public string YoutubeLink { get; private set; }
    public string FileName { get; private set; }
    public double Volume { get; private set; }

    public Video(string youtubeLink, string fileName, double volume = 1)
    {
        YoutubeLink = youtubeLink;
        FileName = fileName;
        Volume = volume;
    }
}

static public class Steven
{
    public const string VideoRoot = "Assets/Failure";
    public const string VideoExtension = "mp4";

    public static Video[] VideoList = {
            new Video("https://www.youtube.com/watch?v=lO9K7VMFo2Y", "Failure", 0.7),
            new Video("https://www.youtube.com/watch?v=VvO_HpyVQWo", "Stupid")
        };
}
