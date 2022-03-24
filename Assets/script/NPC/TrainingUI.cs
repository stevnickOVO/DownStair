using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingUI : MonoBehaviour
{
    [SerializeField] float money;
    [SerializeField] Text moneyText;
    private void Awake()
    {
        money = GameObject.Find("Player").GetComponent<PlayerProperty>().money;
        moneyText.text = money.ToString();
    }
    private void Update()
    {
        moneyText.text = money.ToString();
    }
    public void hpplusBTN()
    {
        if (moneyCheck())
        {
            money -= 100;
            GameObject.Find("Player").GetComponent<PlayerProperty>().MaxHP += 5;
            GameObject.Find("Player").GetComponent<PlayerProperty>().CurrHP += 5;
        }
    }
    public void ATTplusBTN()
    {
        if (moneyCheck())
        {
            money -= 100;
            GameObject.Find("Player").GetComponent<PlayerProperty>().attackValue += 1;
        }
    }
    public bool moneyCheck()
    {
        return money >= 100;
    }
}
