using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speedX;
    [SerializeField] private GameObject bullet;
    [SerializeField]private float buttetSpeed;
    public bool isShoot;
    private float InputX;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Collider2D enemyCollider2D;
    private PlayerProperty playerProperty;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        playerProperty =GetComponent<PlayerProperty>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        playerProperty.CurrHP = playerProperty.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(Input.GetMouseButtonDown(0)&&isShoot) shoot();
    }
    void move()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(speedX * InputX, rigidbody.velocity.y);

        if(InputX<0) gameObject.transform.localScale = new Vector2(-2, 2);
        else if (InputX > 0) gameObject.transform.localScale = new Vector2(2, 2);

        animator.SetFloat("runSpeed", Mathf.Abs(rigidbody.velocity.x));
    }
    public void getDanamge(Collision2D collision)
    {
        playerProperty.CurrHP -= collision.gameObject.GetComponent<enemyProperty>().attackVaule;
        animator.SetBool("hit", true);
        if (playerProperty.CurrHP <= 0) GameObject.Find("GameManager").gameObject.GetComponent<gameManagerContrller>().GameOver();
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), true);
        enemyCollider2D = collision.gameObject.GetComponent<Collider2D>();
    }
    public void colliderFalse()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemyCollider2D.gameObject.GetComponent<Collider2D>(), false);
        animator.SetBool("hit",false);
    }
    public void footStepControllor()
    {
        audioSource.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy"|| collision.gameObject.tag == "bunnyEnemy")
        {
            getDanamge(collision);
        }
    }
    public void shoot()
    {
        Vector3 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePOS.z = 0;

        float angle = Vector2.Angle(mousePOS-transform.position,Vector2.up);

        GameObject bullt = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        bullt.GetComponent<Rigidbody2D>().velocity = (mousePOS - transform.position).normalized * buttetSpeed;

        bullt.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
