using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCFrogMan : MonoBehaviour
{
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private string[] BTNString;
    [SerializeField] private talkUIController talkUIController;

    [SerializeField] private GameObject trainUI;
    public void onClickNPC()
    {
        talkUIController.setTextAsset(textAsset, BTNString);
        
    }
    public void TrainingBTN()
    {
        Button button = talkUIController.transform.GetChild(0).gameObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Training);
    }
    public void Training()
    {
        trainUI.SetActive(true);
    }
}
