using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "cardName", menuName = "level/card")]
public class skillScriptTableObject : ScriptableObject
{
    public enum CardType { powerUP, maxHPUp, beeFriend };

    public string titleName;
    public Sprite sprite;
    [TextArea] public string explanation;

    [SerializeField] public CardType cardType;

    [SerializeField] GameObject BeeFriend;
    public void powerUP(PlayerProperty playerProperty)
    {
        float power = playerProperty.attackValue / 5;
        playerProperty.attackValue += power;
        Time.timeScale = 1;
    }
    public void maxHPUp(PlayerProperty playerProperty)
    {
        float HP = playerProperty.MaxHP / 5;
        playerProperty.MaxHP += HP;
        Time.timeScale = 1;
    }
    
}
