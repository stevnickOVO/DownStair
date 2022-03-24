using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum flyShiptype
{
    start,
    fly
}

public class flyShip : MonoBehaviour
{
    
    [SerializeField] private GameObject dead_effect;
    private AudioSource hit_Source;
    private enemyProperty enemyProperty;
    private PlayerProperty playerProperty;
    flyShiptype flyShiptype;
    private void Awake()
    {
        hit_Source=GetComponent<AudioSource>();
        playerProperty = GameObject.Find("Player").gameObject.GetComponent<PlayerProperty>();
        flyShiptype = flyShiptype.start;
        enemyProperty = GetComponent<enemyProperty>();
    }
    void Update()
    {
        if (transform.position.x == 0 && transform.position.y == -4) flyShiptype = flyShiptype.fly;

        switch (flyShiptype)
        {
            case flyShiptype.start:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, -4), Time.deltaTime * 2);
                break;
            case flyShiptype.fly:
                transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 50);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
            //animator.SetBool("getHurt", true);
            hit_Source.Play();
            enemyProperty.currHp -= playerProperty.attackValue;

            if (enemyProperty.currHp <= 0)
            {
                playerProperty.AddEXP(enemyProperty.enemyEXP);
                GameObject coin = Instantiate(enemyProperty.coinPefabs, transform.position, Quaternion.identity);
                coin.GetComponent<coinControllor>().coinSet(Random.Range(enemyProperty.coinRangeMax, enemyProperty.coinRangeMin));
                Destroy(gameObject);
                Instantiate(dead_effect, transform.position, Quaternion.identity);
            }
        }
    }
}
