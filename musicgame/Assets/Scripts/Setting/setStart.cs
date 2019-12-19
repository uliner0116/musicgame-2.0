using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class setStart : MonoBehaviour
{
    private string txtName;
    public AudioSource[] notePlayer;
    // Start is called before the first frame update
    void Start()
    {
        txtName = "notePlay";

        FileInfo fi = new FileInfo(Application.persistentDataPath + "/" + txtName);
        if (fi.Exists)
        {
            //Debug.Log("File Exists! Began To Read." + fi);
        }
        else
        {
            setNote(txtName);
        }
        txtName = "audioNote";
        FileInfo fi1 = new FileInfo(Application.persistentDataPath + "/" + txtName);
        if (fi1.Exists)
        {
            //Debug.Log("File Exists! Began To Read." + fi1);
        }
        else
        {
            setVolume(txtName);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setVolume(string Name)
    {
        volumeState myVlume = new volumeState();
        myVlume.volume = 1;
        //將myPlayer轉換成json格式的字串
        string saveString = JsonUtility.ToJson(myVlume);
        //將字串saveString存到硬碟中
        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, Name));
        file.Write(saveString);
        file.Close();
    }
    void setNote(string Name)
    {
        noteState myNote = new noteState();
        int playNumber = 3;
        myNote.noteAudio = notePlayer[playNumber].clip;
        //將myPlayer轉換成json格式的字串
        string saveString = JsonUtility.ToJson(myNote);
        //將字串saveString存到硬碟中
        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, Name));
        file.Write(saveString);
        file.Close();
    }

    public class volumeState
    {
        public float volume;
    }
    public class noteState
    {
        public AudioClip noteAudio = null;
    }
}
