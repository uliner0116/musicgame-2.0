using Common;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListButton : MonoBehaviour
{
    int line;
    string songName;
    string level;
    string lineName;
    public bool is3D;
    public bool changecolor2 = false;
    public Button thisbutton;
    public Image t;
    public Image t1;
    public Image t2;
    public Image t3;
    public Image piano;
    //static public bool  D=true;
    TextAsset songTxt;
    GameObject father_gameObject;   //宣告一個GameObject(用來放取得的父物件)。
    //歌名對照表
    int listNumber = 0;

    string[] songList = new string[]{
        "butterfly" ,"Don't say lazy" ,"Im sorry" ,"LATATA" ,"LOVE" ,"Mirotic" ,"Oh!" ,"One Night In 北京" ,"PON PON PON" ,"Roly Poly" ,"SORRY SORRY" ,"Trouble Maker" ,"Tunak Tunak Tun" ,
        "YES or YES" ,"三國戀" ,"千年之戀" ,"不得不愛" ,"月牙灣" ,"回レ! 雪月花" ,"我不配" ,"我還年輕 我還年輕" ,"牡丹江" ,"東區東區" ,"直感" ,"星空" ,"夏祭り" ,"恋は渾沌の隷也" ,
        "恋愛サーキュレーション" ,"夠愛" ,"將軍令" ,"華陽炎" ,"極楽浄土" ,"憂愁" ,"憨人" ,"樹枝孤鳥" ,"恋" ,"Burn It Down","Counting Stars","Good Time","I Really Like You","Maps","One More Night",
        "Poker Face","Thunder","What Ive Done","What Makes You Beautiful"
    };

    //點擊時呼叫
    public void OnPathClick()
    {
        Debug.Log("in touch" + changecolor2);
        if (changecolor2 == false)
        {
            Debug.Log(changecolor2);
            changecolor2 = true;
        }
        else if (changecolor2 == true)
        {
            Debug.Log(changecolor2);
            //取得這首歌的名稱
            father_gameObject = gameObject.transform.parent.gameObject;
            //  father_gameObject = father_gameObject.transform.parent.gameObject;
            //line在兩層後 設定line相關資訊
            lineName = father_gameObject.name;
            if (string.Compare(lineName, "Line3") == 0)
            {
                line = 3;
            }
            else if (string.Compare(lineName, "Line6") == 0)
            {
                line = 6;
            }
            Debug.Log("line: " + line);
            father_gameObject = father_gameObject.transform.parent.gameObject;
            //song在三層後 設定音樂名稱
            songName = father_gameObject.name;
            for (int i = 1; i <= songList.Length; i++)
            {
                if (string.Compare(songList[i - 1], songName) == 0)
                {
                    listNumber = i;
                    songName = "song" + listNumber.ToString("D3");
                    Debug.Log("songName: " + songName);
                    break;
                }
            }

            level = transform.name;
            Debug.Log("level!" + level);

            // Debug.Log(Path.GetExtension("E:\\user\\Desktop\\musicgame\\musicgame\\musicgame\\Assets\\Audios\\cAudio\\Don't say lazy-cut.mp3"));      
            // Game.SceneController.songDataAsset = Resources.Load<TextAsset>(noteTxt);

            /*if (Path.GetExtension(transform.name) == ".mp3" ||
                Path.GetExtension(transform.name) == ".aif" ||
                Path.GetExtension(transform.name) == ".wav" ||
                Path.GetExtension(transform.name) == ".ogg")
            {*/
            Debug.Log("in");
            //string audio = "file://" + transform.name;
            //string audio = "Audios/cAudio/回レ! 雪月花cut.mp3";
            //WWW www = new WWW(audio);
            //Debug.Log("www:" + www.url);
            //string noteTxt = "file://" + transform.name;
            //string noteTxt = "notetxt/回レ! 雪月花.txt";

            //if()
            //while (!www.isDone) { }
            //Game.SceneController.songDataAsset= Resources.Load<TextAsset>(noteTxt);
            //songData.audio = www.GetAudioClip();

            if (line == 3)
            {
                songTxt = Resources.Load<TextAsset>("3linetxt/" + songName + "/" + songName + "-" + level);
                if (songTxt == null)
                {
                    Debug.Log("not found this level!");
                    this.gameObject.SetActive(false);
                    //按化處理
                }
                else
                {
                    songData.audio = Resources.Load<AudioClip>("Audios/cAudio/" + songName);
                    Debug.Log("audio: " + songData.audio.name);
                    songData.Line3SongDataAsset = Resources.Load<TextAsset>("3linetxt/" + songName + "/" + songName + "-" + level);
                    Debug.Log("Line3SongDataAsset:" + songData.Line3SongDataAsset.name);
                    // Debug.Log("notetxt:" + songData.);
                }

            }
            else if (line == 6)
            {
                songTxt = Resources.Load<TextAsset>("6linetxt/" + songName + "/" + songName + "-" + level);
                if (songTxt == null)
                {
                    Debug.Log("not found this level!");
                    this.gameObject.SetActive(false);
                    //按化處理
                }
                else
                {
                    songData.audio = Resources.Load<AudioClip>("Audios/cAudio/" + songName);
                    Debug.Log("audio: " + songData.audio.name);
                    songData.Line6SongDataAsset = Resources.Load<TextAsset>("6linetxt/" + songName + "/" + songName + "-" + level);
                    Debug.Log("Line6SongDataAsset:" + songData.Line6SongDataAsset.name);
                }
            }


            //轉跳sence
            if (songTxt != null)
            {
                if (line == 3)
                {
                    if (is3D == false)
                    {
                        SceneManager.LoadScene("Game 3ver");
                    }
                    else
                    {
                        SceneManager.LoadScene("3DGame 3ver");
                    }

                }
                else if (line == 6)
                {
                    if (is3D == false)
                    {
                        SceneManager.LoadScene("Game 6ver");
                    }
                    else
                    {
                        SceneManager.LoadScene("3DGame 6ver");
                    }
                }
            }
        }
    }
    public void isPresence()
    {
        //取得這首歌的名稱
        father_gameObject = gameObject.transform.parent.gameObject;
       // father_gameObject = father_gameObject.transform.parent.gameObject;
        //line在兩層後 設定line相關資訊
        lineName = father_gameObject.name;
        if (string.Compare(lineName, "Line3") == 0)
        {
            line = 3;
        }
        else if (string.Compare(lineName, "Line6") == 0)
        {
            line = 6;
        }
        Debug.Log("line: " + line);
        father_gameObject = father_gameObject.transform.parent.gameObject;
        //song在三層後 設定音樂名稱
        songName = father_gameObject.name;
        for (int i = 1; i <= songList.Length; i++)
        {
            if (string.Compare(songList[i - 1], songName) == 0)
            {
                listNumber = i;
                songName = "song" + listNumber.ToString("D3");
                Debug.Log("songName: " + songName);
                break;
            }

        }

        level = transform.name;
        Debug.Log("level!" + level);

        if (line == 3)
        {
            songTxt = Resources.Load<TextAsset>("3linetxt/" + songName + "/" + songName + "-" + level);
            //Debug.Log("3Line:" + songTxt.name);
            if (songTxt == null)
            {
                //Debug.Log("not found this level!"+ songTxt.name);
                this.gameObject.GetComponent<Button>().enabled = false;
                t.color = new Color32(100, 100, 100, 128);
                //按化處理
            }
        } else if (line == 6)
        {
            songTxt = Resources.Load<TextAsset>("6linetxt/" + songName + "/" + songName + "-" + level);
            //Debug.Log("6Line:" + songTxt.name);
            if (songTxt == null)
            {
                //Debug.Log("not found this level!"+ songTxt.name);
                this.gameObject.GetComponent<Button>().enabled = false;
                t.color = new Color32(100,100,100,128);
                //按化處理
            }
        }
    }
    public void Recover()
    {
       // changecolor2 = false;
            t.color = new Color32(0, 0, 0, 255);
            t1.sprite = Resources.Load("star5", typeof(Sprite)) as Sprite;
            t2.sprite = Resources.Load("star5", typeof(Sprite)) as Sprite;
            t3.sprite = Resources.Load("star5", typeof(Sprite)) as Sprite;
            father_gameObject = gameObject.transform.parent.gameObject;
            lineName = father_gameObject.name;
            if (string.Compare(lineName, "Line3") == 0)
            {
                line = 3;
                piano.sprite = Resources.Load("鋼琴鍵 3", typeof(Sprite)) as Sprite;
            }
            else if (string.Compare(lineName, "Line6") == 0)
            {
                line = 6;
                piano.sprite = Resources.Load("鋼琴6", typeof(Sprite)) as Sprite;
            }
    }
    public void ChangeC()
    {
        Debug.Log(changecolor2);
        t.color = new Color32(255, 255, 255, 255);
        Debug.Log(t.color);
        t1.sprite = Resources.Load("star4", typeof(Sprite)) as Sprite;
        t2.sprite = Resources.Load("star4", typeof(Sprite)) as Sprite;
        t3.sprite = Resources.Load("star4", typeof(Sprite)) as Sprite;
        father_gameObject = gameObject.transform.parent.gameObject;
        lineName = father_gameObject.name;
        if (string.Compare(lineName, "Line3") == 0)
        {
            Debug.Log("lineName Line3");
            line = 3;
            piano.sprite = Resources.Load("鋼琴鍵 3 交換", typeof(Sprite)) as Sprite;
        }
        else if (string.Compare(lineName, "Line6") == 0)
        {
            Debug.Log("lineName Line6");
            line = 6;
            piano.sprite = Resources.Load("鋼琴6交換", typeof(Sprite)) as Sprite;
        }
    }
    // Use this for initialization
    void Start()
    {
        isPresence();
        this.GetComponent<Button>().onClick.AddListener(OnPathClick);
    }

            // Update is called once per frame
    void Update()
    {
        if(t.color == Color.black)
        {
            changecolor2 = false;
        }
    }

}