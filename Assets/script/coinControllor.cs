using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinControllor : MonoBehaviour
{
    private GameObject PlayerPosition;
    [SerializeField] private float Speed;
    [SerializeField] private float StayTime;
    private int coinCount;
    private void Awake()
    {
        PlayerPosition = GameObject.Find("Player").gameObject;
    }
    private void Update()
    {
        StayTime -= Time.deltaTime;

        if (StayTime < 0&&PlayerPosition!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.transform.position, Speed*Time.deltaTime);
        }
    }
    public void coinSet(int coin)
    {
        coinCount = coin;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerProperty>().money += coinCount;
            Destroy(gameObject);
        }
    }
}
