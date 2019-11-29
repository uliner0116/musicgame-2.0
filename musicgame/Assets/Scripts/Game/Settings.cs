using Common;
using Common.Data;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool _preview { get { return preview; } protected set { preview = value; } }
    public bool _randomTiming { get { return randomTiming; } }

    public TextMesh comment;

    [HideInInspector]
    private int Count = 0;
    [SerializeField]
    private bool preview;

    public GameObject page;
    private bool pauseEnabled = false;
    //print 
    [SerializeField]
    TextMesh scoreText;
    [SerializeField]
    TextMesh lifeText;
    [SerializeField]
    TextMesh comboText;
    [SerializeField]
    TextAsset songDataAsset;
    [SerializeField]
    AudioManager audioManager;
    [SerializeField]
    Button stopButton;
    SongData song;
    MatchCollection mc = null;
    //gameovercanvs get this
    
    int maxLife;
    int life;
    public int Line;
    public int score;
    public int combo;
    public int maxCombo = 0;
    public int noteQuantity;
    public int perfectNum;
    public int greatNum;
    public int goodNum;
    public int badNum;
    public int missNum;
    public string songName;
    public int maxScore;

    [SerializeField]
    GameObject gameOverPanel;
  //  public GameObject gameOverCanvasPrefab;

    [SerializeField]
    private bool randomTiming;

    void Awake()
    {
        comment.text = "";
        _preview = preview;
        
    }

    int Life
    {
        set
        {
            life = value;
            if (life <= 0)
            {
                life = 0;
                life = 0;
                Time.timeScale = 0;
                audioManager.bgm.Pause();
                gameOverPanel.SetActive(true);
            }
            lifeText.text = string.Format("Life:" + life);
        }
        get { return life; }
    }

    public int Score
    {
        set
        {
            score = value;
            scoreText.text = string.Format("Score: {0}", score);
        }
        get { return score; }
    }

    public int Combo
    {
        set
        {
            combo = value;
            if (combo >= 20 && combo % 5 == 0)//生命回復
            {
                if (life < maxLife)
                {
                    Life++;
                }
            }
            if (maxCombo < combo)
            {
                maxCombo = combo;
            }
            comboText.text = string.Format("Combo: {0}", combo);
        }
        get { return combo; }
    }

    private void Start()
    {
        stopButton.onClick.AddListener(Stop);
        if (Line == 3)
        {
            this.songDataAsset = songData.Line3SongDataAsset;
        }
        else if (Line == 6)
        {
            this.songDataAsset = songData.Line6SongDataAsset;
        }
        songName = audioManager.bgm.clip.name;
        songData.is3D = true;
        Score = 0;
        Life = 50;
        maxLife = 50;
        Combo = 0;
        Time.timeScale = 1;
        song = SongData.LoadFromJson(songDataAsset.text);
        Regex re = new Regex("time");
        mc = re.Matches(songDataAsset.text);
        noteQuantity = mc.Count;
        setMaxScore();
    }

    public void setData()
    {      
        songData.noteQuantity = noteQuantity;
        songData.missNum = missNum;
        songData.perfectNum = perfectNum;
        songData.greatNum = greatNum;
        songData.goodNum = goodNum;
        songData.badNum = badNum;
        songData.songName = songName;
        songData.maxScore = maxScore;
        songData.score = score;
        songData.maxCombo = maxCombo;
        Debug.Log("noteQuantity:" + songData.noteQuantity);
        Debug.Log("missNum:" + songData.missNum);
        Debug.Log("perfectNum:" + songData.perfectNum);
        Debug.Log("greatNum:" + songData.greatNum);
        Debug.Log("goodNum:" + songData.goodNum);
        Debug.Log("songName:" + songData.songName);
        Debug.Log("maxScore:" + songData.maxScore);
        Debug.Log("score:" + songData.score);
        Debug.Log("combo:" + songData.maxCombo);
        SceneManager.LoadScene("Score");
        //Instantiate(gameOverCanvasPrefab, Vector2.zero, Quaternion.identity);
    }

    void setMaxScore()
    {

        for (int i = 0; i < noteQuantity; i++)
        {
            float v = 1 + ((float)i / (float)noteQuantity);
            maxScore = Convert.ToInt32(maxScore + (1000 * v));
        }
        Debug.Log("maxScore:" + maxScore);
    }


    public int toTimingID(string key)
    {
        var ret = new System.Collections.Generic.Dictionary<string, int>()
        {
            {"perfect", 1 },
            {"great", 2 },
            {"nice", 3 },
            {"bad", 4 },
            { "DestoryPoint", 0 }
        };
        return ret[key];
    }

    public void Comment(int com)
    {
        switch (com)
        {
            case 1:
                Count++;
                comment.text = "<color=\"#FEFB58\">Perfect!!</color>";
                comment.gameObject.SetActive(true);
                ScoreDouble(1000);
                Combo++;
                perfectNum++;
                break;
            case 2:
                Count++;
                comment.text = "<color=\"#5BFE6F\">Great!!</color>";
                comment.gameObject.SetActive(true);
                ScoreDouble(500);
                Combo++;
                greatNum++;
                break;
            case 3:
                Count++;
                comment.text = "Nice!!" ;
                comment.gameObject.SetActive(true);
                ScoreDouble(300);
                Combo++;
                goodNum++;
                break;
            case 4 :
                Count++;
                comment.text = "Bad!!" ;
                comment.gameObject.SetActive(true);
                Life--;
                Combo = 0;
                badNum++;
                break;
            default:
                Count = 0;
                comment.text = "<color=\"red\">Miss</color>" ;
                comment.gameObject.SetActive(true);
                Life--;
                Combo = 0;
                missNum++;
                break;
        }
    }
    void ScoreDouble(int up)//依combo高低調整分數上升幅度
    {
        Score = (score + up) * (1 + combo / noteQuantity);
    }

    void Stop()
    {
        page.SetActive(true);
        Time.timeScale = 0;
        audioManager.bgm.Pause();
        Debug.Log("Stop");
        pauseEnabled = true;
    }
    public void Retry()
    {
        if (Line == 3)
        {
            SceneManager.LoadScene("3DGame 3ver");
        }
        else if (Line == 6)
        {
            SceneManager.LoadScene("3DGame 6ver");
        }
    }
    public void BackGame()
    {
        page.SetActive(false);
        pauseEnabled = false;
        Time.timeScale = 1;
        //Thread.Sleep(3000);
        audioManager.bgm.UnPause();
        Debug.Log("UnStop");

    }
    public void BackMenu()//Make Main Menu button
    {
        SceneManager.LoadScene("2D");
    }
}
