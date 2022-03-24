using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIEXP : MonoBehaviour
{
    private Image EXP_Bar;
    private PlayerProperty playerProperty;

    private void Awake()
    {
        EXP_Bar = GetComponent<Image>();
        playerProperty = GameObject.Find("Player").gameObject.GetComponent<PlayerProperty>();
    }
    private void Update()
    {
        EXP_Bar.fillAmount= playerProperty.CurrExp / playerProperty.MaxEXP;
    }
}
