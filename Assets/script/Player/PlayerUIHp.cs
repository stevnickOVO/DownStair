using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHp : MonoBehaviour
{
    private Image HP_Bar;
    private PlayerProperty playerProperty;

    private void Awake()
    {
        HP_Bar = GetComponent<Image>();
        playerProperty = GameObject.Find("Player").gameObject.GetComponent<PlayerProperty>();
    }
    private void Update()
    {
        HP_Bar.fillAmount = playerProperty.CurrHP / playerProperty.MaxHP;
    }
}
