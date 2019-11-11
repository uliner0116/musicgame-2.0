using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ListBtnControll : MonoBehaviour
{
    public Image EasyT;
    public Image NormalT;
    public Image HardT;
    public Image Easy6T;
    public Image Normal6T;
    public Image Hard6T;
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if(EasyT.color == Color.white)
        {
            NormalT.color = Color.black;
            HardT.color = Color.black;
            Easy6T.color = Color.black;
            Normal6T.color = Color.black;
            Hard6T.color = Color.black;
        }
        else if(NormalT.color == Color.white)
        {
            EasyT.color = Color.black;
            HardT.color = Color.black;
            Easy6T.color = Color.black;
            Normal6T.color = Color.black;
            Hard6T.color = Color.black;
        }
        else if(HardT.color == Color.white)
        {
            EasyT.color = Color.black;
            NormalT.color = Color.black;
            Easy6T.color = Color.black;
            Normal6T.color = Color.black;
            Hard6T.color = Color.black;
        }
        else if(Easy6T.color == Color.white)
        {
            EasyT.color = Color.black;
            NormalT.color = Color.black;
            HardT.color = Color.black;
            Normal6T.color = Color.black;
            Hard6T.color = Color.black;
        }
        else if (Normal6T.color == Color.white)
        {
            EasyT.color = Color.black;
            NormalT.color = Color.black;
            HardT.color = Color.black;
            Easy6T.color = Color.black;
            Hard6T.color = Color.black;
        }
        else if (Hard6T.color == Color.white)
        {
            EasyT.color = Color.black;
            NormalT.color = Color.black;
            HardT.color = Color.black;
            Easy6T.color = Color.black;
            Normal6T.color = Color.black;    
        }
    }
}
