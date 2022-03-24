using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class talkUIController : MonoBehaviour
{
    private TextAsset textAsset;
    private String[] talkTextList;
    [SerializeField] private GameObject[] Buttongroup;

    [SerializeField] private Button buttonONE;
    [SerializeField] private Button buttonTWO;
    [SerializeField] private Text UItext;

    public void setTextAsset(TextAsset text,string[] btnCount)
    {
        textAsset = text;
        UISetUP(btnCount);
    }
    public void UISetUP(string[] btnCount)
    {
        transform.parent.gameObject.SetActive(true);

        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
        if (btnCount.Length < 4) { 
          for (int a = 0; a < btnCount.Length; a++)
            {
                Buttongroup[a].SetActive(true);
                Buttongroup[a].GetComponentInChildren<Text>().text= btnCount[a];
            }
        }

        talkTextControllor();
        talkingText();
    }
    public void exitTalk()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void talkTextControllor()
    {
        talkTextList=textAsset.text.Split('\n');
    }
    public void talkingText()
    {
        int range = UnityEngine.Random.Range(0, talkTextList.Length);

        UItext.text = talkTextList[range];
    }
}
