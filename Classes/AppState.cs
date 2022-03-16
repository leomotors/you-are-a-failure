using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace you_are_a_failure.Classes;

static public class AppState
{
    static public bool[] Watched = new bool[Steven.VideoList.Length];

    static public Action OnStateChanged;

    static public int? GetIndex(string key)
    {
        for (int i = 0; i < Steven.VideoList.Length; i++)
        {
            if (Steven.VideoList[i].FileName == key)
            {
                return i;
            }
        }
        return null;
    }

    static public void AddWatched(string key)
    {
        Watched[(int)GetIndex(key)] = true;

        if (OnStateChanged is not null) OnStateChanged();
    }

    static public bool IsAllWatched()
    {
        bool result = true;

        Array.ForEach(Watched, w => result &= w);

        return result;
    }
}
