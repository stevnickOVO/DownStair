using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugKingControllor : MonoBehaviour
{
    [SerializeField] private GameObject warn_Object;

    private int random_y;
    private enemyProperty enemy;
    private Rigidbody2D rigidbody2D;
    private float direction;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        enemy = GetComponent<enemyProperty>();
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector3(-enemy.speed, 0, 0);
    }
    public void bugKingAction()
    {
        random_y = Random.Range(-4,4);
    }
    public void warning()
    {
        Instantiate(warn_Object);
    }
}
