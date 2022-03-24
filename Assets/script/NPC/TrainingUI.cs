using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingUI : MonoBehaviour
{
    [SerializeField] PlayerProperty money;
    [SerializeField] Text moneyText;
    private void Awake()
    {
        money = GameObject.Find("Player").GetComponent<PlayerProperty>();
        moneyText.text = money.money.ToString();
    }
    private void Update()
    {
        moneyText.text = money.money.ToString();
    }
    public void hpplusBTN()
    {
        if (moneyCheck())
        {
            money.money -= 100;
            GameObject.Find("Player").GetComponent<PlayerProperty>().MaxHP += 5;
            GameObject.Find("Player").GetComponent<PlayerProperty>().CurrHP += 5;
        }
    }
    public void ATTplusBTN()
    {
        if (moneyCheck())
        {
            money.money -= 100;
            GameObject.Find("Player").GetComponent<PlayerProperty>().attackValue += 1;
        }
    }
    public bool moneyCheck()
    {
        return money.money >= 100;
    }
}
