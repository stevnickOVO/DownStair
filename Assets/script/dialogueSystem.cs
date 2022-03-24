using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueSystem : MonoBehaviour
{
    public Text textLable;
    public TextAsset textAsset;
    public int index;

    List<string> textList = new List<string>();
    void Start()
    {
        getTextAssetText(textAsset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void getTextAssetText(TextAsset textAsset)
    {
        textList.Clear();
        index = 0;

        var textAssetData = textAsset.text.Split('\n');

        foreach (var lineText in textAssetData)
        {
            textList.Add(lineText);
        }
    }
}
