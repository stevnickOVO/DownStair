using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerContrller : MonoBehaviour
{
    [SerializeField]private GameObject[] skillCardList;
    [SerializeField] private skillScriptTableObject[] cardPowerList;
    [SerializeField] private GameObject cardFather;
    [SerializeField] private GameObject lose_UI;

    public void playerLevelUP()
    {
        Time.timeScale = 0;

        cardFather.SetActive(true);

        for (int x = 0; x < skillCardList.Length; x++)
        {
            int randomNumber = Random.Range(0, cardPowerList.Length);
            skillCardList[x].GetComponent<CardPowerUP>().getskillScript(cardPowerList[randomNumber]);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        lose_UI.SetActive(true);
        lose_UI.GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
            Destroy(other.gameObject);
        }
    }
    public void lose_BTN()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
