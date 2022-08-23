using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataScript
{
    public static int[,] gamePassData;
    public static Material[] matArray;
    public static string[] colorNameArray;
    public static int startBugs;

    public static void PassSceneData(int[,] data, Material[] mats, string[] names)
    {
        gamePassData = new int[data.GetLongLength(0), data.GetLongLength(1)];
        gamePassData = data;

        matArray = new Material[mats.Length];
        matArray = mats;

        colorNameArray = new string[names.Length];
        colorNameArray = names;
    }


}
