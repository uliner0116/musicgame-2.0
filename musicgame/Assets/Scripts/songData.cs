﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public static class songData
{
    public static AudioClip audio = null;
    public static TextAsset Line3SongDataAsset = null;
    public static TextAsset Line6SongDataAsset = null;
    public static float BgmVolume = 0;
    public static float NoteVolume = 0;
    public static bool is3D = false;
    public static string songName;
    public static int maxScore;
    public static int score;
    public static int maxCombo;
    public static float perfectNum;
    public static  float greatNum;
    public static float goodNum;
    public static float badNum;
    public static  float missNum;
    public static int noteQuantity;
}
