using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCGhostFace : MonoBehaviour
{
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private string [] BTNString;
    [SerializeField] private talkUIController talkUIController;

    public void onClickNPC()
    {
        talkUIController.setTextAsset(textAsset,BTNString);
        
    }
    public void trade()
    {

    }

    public void dungeonGOGO()
    {
        Button button=talkUIController.transform.GetChild(1).gameObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(downToDungeon);
    }
    public void downToDungeon()
    {
        GameObject player = GameObject.Find("Player").gameObject;
        player.transform.position = new Vector2(0,3f);
        player.GetComponent<PlayerController>().isShoot = true;
        SceneManager.LoadScene(1);
    }

}
