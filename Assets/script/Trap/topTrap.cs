using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topTrap : MonoBehaviour
{
    [SerializeField] private gameManagerContrller gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.GameOver();
        }
    }
}
