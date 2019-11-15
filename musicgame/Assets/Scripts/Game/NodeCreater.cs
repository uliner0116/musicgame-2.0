using Common;
using Common.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Game
{
    public class NodeCreater : MonoBehaviour
    {
        public GameObject gameOverCanvasPrefab;
        //List<NoteObject3D> noteObjectPool = new List<NoteObject3D>();
        [SerializeField]
        AudioManager audioManager;
        public GameObject Node;
        float previousTime = 0f;
        public const float PRE_NOTE_SPAWN_TIME = 3f;
        [SerializeField]
        GameObject[] nodeLines;
        [SerializeField]
        TextAsset songDataAsset;
        SongData song;
        private GameObject nodeParent;
        private GameObject destination;
        private GameObject lostPosition;
        float time1 = 0;
        Boolean inOver = false;
        public int Line;
        public string songName;
        public string songname;
        float volume;
        AudioClip noteAudio;


        void Awake()
        {
            if (Line == 3)
            {
                this.songDataAsset = songData.Line3SongDataAsset;
            }
            else if (Line == 6)
            {
                this.songDataAsset = songData.Line6SongDataAsset;
            }
            audioManager.bgm.clip = songData.audio;
            songName = audioManager.bgm.clip.name;

            //note音量設定
            loadVolume("audioNote");
            audioManager.note.volume = volume;

            //note音設定
            loadNoteAudio("notePlay");
            audioManager.note.clip = noteAudio;

            Debug.Log("bgm" + audioManager.bgm.volume);
            Debug.Log("note" + audioManager.note.volume);

            //bgm音量設定

            songname = songName;
            string txtName;
            txtName = songname + " Audio";
            //Debug.Log("txtName " + txtName);
            Debug.Log("songData.Line6SongDataAsset " + songData.Line6SongDataAsset);
            Debug.Log("this.songDataAsset " + this.songDataAsset);
            loadVolume(txtName);
            audioManager.bgm.volume = volume;

            nodeParent = gameObject.transform.parent.gameObject;
           destination = GameObject.Find(nodeParent.name + "/TapPosition");
           lostPosition = GameObject.Find(nodeParent.name + "/lostPosition");
           song = SongData.LoadFromJson(songDataAsset.text);
            audioManager.bgm.PlayDelayed(1f);
            Debug.Log("awake OK");

        }

        public void loadVolume(string name)
        {
            string loadJson;
            //讀取json檔案並轉存成文字格式
            //#if UNITY_EDITOR
            // string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, name);
            // Debug.Log("filePath:" + filePath);
            //#elif UNITY_ANDROID
            //string filePath = Path.Combine("jar:file://" + Application.dataPath + "!assets/", name);
            //var filePath = Application.persistentDataPath + "/" +name;
            StreamReader file = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, name));

            //#endif

            /*#if UNITY_EDITOR
                        StreamReader file = new StreamReader(filePath);
                        loadJson = file.ReadToEnd();
                        file.Close();

            #elif UNITY_ANDROID*/
            loadJson = file.ReadToEnd();
            file.Close();
            /* WWW reader = new WWW (filePath);
             while (!reader.isDone) {
             }
             loadJson = reader.text;*/
            //#endif
            //新增一個物件類型為playerState的變數 loadData
            volumeState loadData = new volumeState();

            //使用JsonUtillty的FromJson方法將存文字轉成Json
            loadData = JsonUtility.FromJson<volumeState>(loadJson);

            //驗證用，將sammaru的位置變更為json內紀錄的位置
            volume = loadData.volume;
        }
        public void loadNoteAudio(string name)
        {
            string loadJson;
            //讀取json檔案並轉存成文字格式
            //#if UNITY_EDITOR
            //string filePath = System.IO.Path.Combine(Application.persistentDataPath, name);
            // Debug.Log("filePath:" + filePath);
            //#elif UNITY_ANDROID
            //string filePath = Path.Combine("jar:file://" + Application.dataPath + "!assets/", name);
            StreamReader file = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, name));

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
            noteState loadData = new noteState();

            //使用JsonUtillty的FromJson方法將存文字轉成Json
            loadData = JsonUtility.FromJson<noteState>(loadJson);

            //驗證用，將sammaru的位置變更為json內紀錄的位置
            noteAudio = loadData.noteAudio;
        }

        // Update is called once per frame
        void Update()
        {
            if (inOver == false)
            {
                time1 = Time.timeSinceLevelLoad;
                //Debug.Log(" bgm time:"+audioManager.bgm.time);
                var audioLength = audioManager.bgm.clip.length;
                var bgmTime = audioManager.bgm.time;
                if (time1 >= audioLength + 3 && inOver == false)
                {
                    inOver = true;
                    GameObject NodeLines = GameObject.Find("NodeLines");
                    Settings setData = (Settings)NodeLines.GetComponent(typeof(Settings));
                    setData.setData();
                    //Instantiate(gameOverCanvasPrefab, Vector2.zero, Quaternion.identity);
                }
                else
                {
                    foreach (var note in song.GetNotesBetweenTime(previousTime + PRE_NOTE_SPAWN_TIME, bgmTime + PRE_NOTE_SPAWN_TIME))
                    {
                        //Debug.Log(" note time:" + note.Time) ;
                        //Debug.Log(" note number:" + note.NoteNumber);
                        //Debug.Log(" nodeLines:" + nodeLines[note.NoteNumber]);
                        if (nodeParent.transform == nodeLines[note.NoteNumber].transform)
                        {
                            nodeCreate();
                        }
                    }
                    previousTime = bgmTime;
                }
            }
        }
        public class volumeState
        {
            public float volume;
        }
        public class noteState
        {
            public AudioClip noteAudio = null;
        }
        void nodeCreate()
        {
            //Debug.Log("creat Node");
            var node = (GameObject)Instantiate(Node, nodeParent.transform);
            node.GetComponent<NoteObject3D>().destination = destination;
            node.GetComponent<NoteObject3D>().lostPosition = lostPosition;
            node.transform.localPosition = this.transform.localPosition;
            node.transform.localRotation = this.transform.localRotation;
            node.transform.localScale = new Vector3(0.7719145f, 0.8685271f, -0.01258678f);
        }
    }
}