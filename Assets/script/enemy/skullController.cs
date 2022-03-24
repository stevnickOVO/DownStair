using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] enemyProperty enemyProperty;
    [SerializeField] PlayerProperty playerProperty;

    private Rigidbody2D rigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyProperty = GetComponent<enemyProperty>();
        playerProperty=GameObject.Find("Player").GetComponent<PlayerProperty>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void skullAction()
    {

    }
    void skullShoot()
    {
        //Instantiate(bullet,transform.position);
    }
    public void getDanamger()
    {
        animator.SetBool("getHurt", true);
        enemyProperty.currHp -= playerProperty.attackValue;
        if (enemyProperty.currHp <= 0) Destroy(gameObject);
    }
}
