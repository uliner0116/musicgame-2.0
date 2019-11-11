using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行

public class ChangeNote : MonoBehaviour
{
    public Text noteNumberText;
    int NoteNumber = 1;
    public string name;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(noteChangeClick);
    }

    void Update()
    {
     
    }
    public void noteChangeClick()
    {
        var get = noteNumberText.text;
        if (string.Compare(get, "X") == 0)
        {
            NoteNumber = 5;
        }
        else
        {
            NoteNumber = int.Parse(noteNumberText.text);
        }
        if (string.Compare(name, "right") == 0 )
        {       
            NoteNumber++;
            if (NoteNumber > 5)
            {
                NoteNumber = 1;
            }
            if(NoteNumber == 5)
            {
                noteNumberText.text = "X";
            }
            else
            {
                noteNumberText.text = "" + NoteNumber; ;
            }
            
           
        }else if (string.Compare(name, "left") == 0)
        {
  
            NoteNumber--;
            if (NoteNumber <1)
            {
                NoteNumber = 5;
            }
            if (NoteNumber == 5)
            {
                noteNumberText.text = "X";
            }
            else
            {
                noteNumberText.text = "" + NoteNumber; ;
            }
        }
    }
}
