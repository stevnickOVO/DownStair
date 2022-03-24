using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapContorllor : MonoBehaviour
{
    [SerializeField] private int trapDamge;
    private float coolDownTimeCurr;
    [SerializeField] private float coolDownTime;

    private void Update()
    {
        coolDownTimeCurr -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (coolDownTimeCurr <= 0)
            {
                collision.GetComponent<PlayerProperty>().CurrHP -= trapDamge;
                coolDownTimeCurr = coolDownTime;
            }
        }
    }
}
