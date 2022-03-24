using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperty : MonoBehaviour
{
    public float MaxHP;
    public float CurrHP;
    public float attackValue;
    public float MaxEXP;
    public float CurrExp;
    public float money;

    // Start is called before the first frame update
    void Start()
    {
        CurrHP = MaxHP;
    }
    public void AddEXP(float EXP)
    {
        CurrExp += EXP;
        LevelUP();
    }
    private void LevelUP()
    {
        if (CurrExp >= MaxEXP)
        {
            float Exp = CurrExp - MaxEXP;
            CurrExp = 0;
            CurrExp += Exp;
            MaxEXP *= 2;

            gameManagerContrller gameManager = GameObject.Find("GameManager").gameObject.GetComponent<gameManagerContrller>();
            gameManager.playerLevelUP();
        }
    }
}
