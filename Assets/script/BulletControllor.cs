using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllor : MonoBehaviour
{
    [SerializeField] private float destoryTime;

    private void Update()
    {
        Destroy(gameObject, destoryTime);
    }
}
