using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapFan : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float changchangeTime;
    private float changchangeTimeCurr;
    private bool right;
    private void Awake()
    {
        changchangeTimeCurr = changchangeTime/2;
    }
    private void Update()
    {
        changchangeTimeCurr -= Time.deltaTime;
        if (changchangeTimeCurr <= 0)
        {
            changchangeTimeCurr = changchangeTime;
            right = !right;
        }
            if (right) gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

            if(!right) gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);

    }
}
