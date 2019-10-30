using Common;
using Common.Data;
using System;
using System.Collections;
using System.Collections.Generic;
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


        void Awake()
        {
            /*if (Line == 3)
            {
                this.songDataAsset = songData.Line3SongDataAsset;
            }
            else if (Line == 6)
            {
                this.songDataAsset = songData.Line6SongDataAsset;
            }*/
            //audioManager.bgm.clip = songData.audio;
            nodeParent = gameObject.transform.parent.gameObject;
           destination = GameObject.Find(nodeParent.name + "/TapPosition");
           lostPosition = GameObject.Find(nodeParent.name + "/lostPosition");
           song = SongData.LoadFromJson(songDataAsset.text);
            audioManager.bgm.PlayDelayed(1f);
            Debug.Log("awake OK");

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
                    Instantiate(gameOverCanvasPrefab, Vector2.zero, Quaternion.identity);
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