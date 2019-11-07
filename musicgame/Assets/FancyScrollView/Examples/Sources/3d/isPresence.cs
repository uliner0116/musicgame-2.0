using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPresence : MonoBehaviour
{

    // Start is called before the first frame update
    public void  OnEnable()
    {
        Debug.Log("當物件為可用或是被調用狀態時此函數被調用");
        GameObject Easy = GameObject.Find("Easy");
        ListButton setEasy = (ListButton)Easy.GetComponent(typeof(ListButton));
        setEasy.isPresence();
        GameObject Normal = GameObject.Find("Normal");
        ListButton setNormal = (ListButton)Easy.GetComponent(typeof(ListButton));
        setNormal.isPresence();
        GameObject Hard = GameObject.Find("Hard");
        ListButton setHard = (ListButton)Easy.GetComponent(typeof(ListButton));
        setHard.isPresence();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
