﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class gameovercanvas : MonoBehaviour
{

    // Use this for initialization
    public Text finalscore;
    public Text finalcombo;
    public Text HighScore;
    public Text perfectP;
    public Text greatP;
    public Text goodP;
    public Text badP;
    public Text missP;
    public Slider ScoreStrip;
    public Slider HighScoreStrip;
    public GameObject effect;
    int score;
    int combo;
    float perfectpersent;
    float greattpersent;
    float goodpersent;
    float badpersent;
    float misspersent;
    int noteQuantity;
    int maxScore;
    int myBestScore=500;
    int songNumber;
    string songName;
    void Start()
    {
        // score = GameObject.FindObjectOfType<Game.SceneController>().score;
        //songName = GameObject.FindObjectOfType<Game.SceneController>().songName;
        score = songData.score;
        songName = songData.songName;
        load();
        Debug.Log("myBestScore:" + myBestScore);
        if (myBestScore == 1000)
        {
            updateMaxScore(score);
        }
        if (score > myBestScore)
        {
            updateMaxScore(score);
            effect.SetActive(true);
        }
        load();
        //級距%數
        noteQuantity = songData.noteQuantity;
        perfectpersent = (songData.perfectNum / (float)noteQuantity) * 100;
        greattpersent = (songData.greatNum / (float)noteQuantity) * 100;
        goodpersent = (songData.goodNum / (float)noteQuantity) * 100;
        badpersent = (songData.badNum / (float)noteQuantity) * 100;
        misspersent = (songData.missNum / (float)noteQuantity) * 100;
        /*noteQuantity = GameObject.FindObjectOfType<Game.SceneController>().noteQuantity;
        perfectpersent = ((float)GameObject.FindObjectOfType<Game.SceneController>().perfectNum / (float)noteQuantity) * 100;       
        greattpersent = ((float)GameObject.FindObjectOfType<Game.SceneController>().greatNum / (float)noteQuantity) * 100;
        goodpersent = ((float)GameObject.FindObjectOfType<Game.SceneController>().goodNum / (float)noteQuantity) * 100;
        badpersent = ((float)GameObject.FindObjectOfType<Game.SceneController>().badNum / (float)noteQuantity) * 100;
        misspersent = ((float)GameObject.FindObjectOfType<Game.SceneController>().missNum / (float)noteQuantity) * 100;*/

        //分數條
        //maxScore = GameObject.FindObjectOfType<Game.SceneController>().maxScore;//本曲上限分數 
        maxScore = songData.maxScore;
        //顯示分數條
        ScoreStrip.maxValue = maxScore;
        ScoreStrip.value = score;
        //顯示
        finalscore.text = string.Format("Score: {0}", score);
        Debug.Log("Score:"+ score);
        //combo = GameObject.FindObjectOfType<Game.SceneController>().maxCombo;
        combo = songData.maxCombo;


        finalcombo.text = string.Format("Combo: {0}", combo);
        Debug.Log("Combo:" + combo);
        string perfectText = ("Perfect:" + songData.perfectNum + "(" + perfectpersent.ToString("#0.0") + "%" + ")");
        Debug.Log("perfectText:" + perfectText);
      //  HighScore.text = string.Format("HighScore: {0}", myBestScore);
        perfectP.text = string.Format(perfectText);
        greatP.text = string.Format("Great:"+ songData.greatNum + "(" + greattpersent.ToString("#0.0") + "%" + ")");
        goodP.text = string.Format("Nice:"+ songData.goodNum + "(" + goodpersent.ToString("#0.0") + "%" + ")");
        badP.text = string.Format("Bad:"+ songData.badNum + "(" + badpersent.ToString("#0.0") + "%" + ")");
        missP.text = string.Format("Miss:"+ songData.missNum + "(" + misspersent.ToString("#0.0") + "%" + ")");

        //最高紀錄分數條
        HighScoreStrip.maxValue = maxScore;
        HighScoreStrip.value = myBestScore;


      //  Debug.Log("HighScore:" + myBestScore);
        Debug.Log("Perfect:" + perfectpersent.ToString("#0.0"));
        Debug.Log("Great:" + greattpersent.ToString("#0.0"));
        Debug.Log("Nice:" + goodpersent.ToString("#0.0"));
        Debug.Log("Bad:" + badpersent.ToString("#0.0"));
        Debug.Log("Miss:" + misspersent.ToString("#0.0"));
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateMaxScore(int score)
    {
        songState mySong = new songState();
        mySong.name = songName;
        mySong.score = score;
        //將myPlayer轉換成json格式的字串
        string saveString = JsonUtility.ToJson(mySong);
        //將字串saveString存到硬碟中
        System.IO.StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, songName));
        file.Write(saveString);
        file.Close();
    }
    public class songState
    {
        public string name;
        public int score;
    }
    public void load()
    {
        string loadJson;
        //讀取json檔案並轉存成文字格式
//#if UNITY_EDITOR
       // string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, songName);
        //Debug.Log("filePath:" + filePath);
//#elif UNITY_ANDROID
            //string filePath = Path.Combine("jar:file://" + Application.dataPath + "!assets/", songName);
         StreamReader file = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, songName));

//#endif

/*#if UNITY_EDITOR
        StreamReader file = new StreamReader(filePath);
        loadJson = file.ReadToEnd();
        file.Close();

#elif UNITY_ANDROID*/
                loadJson = file.ReadToEnd();
                file.Close();
            /*WWW reader = new WWW (filePath);
            while (!reader.isDone) {
            }
            loadJson = reader.text;*/
//#endif

        //新增一個物件類型為playerState的變數 loadData
        songState loadData = new songState();

        //使用JsonUtillty的FromJson方法將存文字轉成Json
        loadData = JsonUtility.FromJson<songState>(loadJson);

        //驗證用，將sammaru的位置變更為json內紀錄的位置
        myBestScore = loadData.score;
    }
}