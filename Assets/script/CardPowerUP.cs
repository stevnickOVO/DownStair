using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPowerUP : MonoBehaviour
{
    [SerializeField] private skillScriptTableObject skillScript;

    [SerializeField] private Text titleText;
    [SerializeField] private Image powerImage;
    [SerializeField] private Text explanationText;
    [SerializeField] Button btn;

    PlayerProperty playerProperty;
    void Start()
    {
        playerProperty = GameObject.Find("Player").gameObject.GetComponent<PlayerProperty>();
        titleText.text = skillScript.titleName;
        powerImage.sprite = skillScript.sprite;
        explanationText.text = skillScript.explanation;
        useCardPower();
    }

    public void useCardPower()
    {
        switch (skillScript.cardType)
        {
            case skillScriptTableObject.CardType.powerUP:
                btn.onClick.AddListener(delegate { skillScript.powerUP(playerProperty); });
                break;
            case skillScriptTableObject.CardType.maxHPUp:
                btn.onClick.AddListener(delegate { skillScript.maxHPUp(playerProperty); });
                break;
        }
    }
    public void getskillScript(skillScriptTableObject skill)
    {
        skillScript = skill;
    }
}
