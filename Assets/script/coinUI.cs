using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinUI : MonoBehaviour
{
    private Text coinText;
    private void Awake()
    {
        coinText = GetComponent<Text>();
    }
    void Update()
    {
        coinText.text = GameObject.Find("Player").gameObject.GetComponent<PlayerProperty>().money.ToString();
    }
}
