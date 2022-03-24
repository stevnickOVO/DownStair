using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snallControllor : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject groundCheckPoint;
    [SerializeField] private float groundCheckDis;
    [SerializeField] private GameObject dead_effect;

    //[SerializeField] enemyPropertyTableObject enemyProperty;
    [SerializeField] PlayerProperty playerProperty;

    
    private AudioSource hit_Source;
    private enemyProperty enemyProperty;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float currScaele;
    // Start is called before the first frame update
    private void Awake()
    {
        hit_Source = GetComponent<AudioSource>();
        enemyProperty = GetComponent<enemyProperty>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerProperty = GameObject.Find("Player").GetComponent<PlayerProperty>();
        currScaele = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        forwordMove();
    }
    public bool groundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(groundCheckPoint.transform.position, Vector2.down, groundCheckDis, groundMask);
        Debug.DrawRay(groundCheckPoint.transform.position, Vector2.down* groundCheckDis);

        return ray;
    }
    public void forwordMove()
    {
        float directionX = groundCheckPoint.transform.position.x > gameObject.transform.position.x ? 1 : -1;
        if (groundCheck())
        {
            rigidbody.velocity = new Vector2(enemyProperty.speed * directionX, rigidbody.velocity.y);
        }
        else
        {
            if (transform.localScale.x>0)
            {
                transform.localScale = new Vector3(-currScaele, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(currScaele, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="bullet")
        {
            Destroy(collision.gameObject);
            animator.SetBool("getHurt", true);
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
