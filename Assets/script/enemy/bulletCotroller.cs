using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCotroller : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").gameObject;
        transform.LookAt(player.transform);
        rigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
