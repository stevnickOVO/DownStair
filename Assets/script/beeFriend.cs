using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeFriend : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] private GameObject bullet;

    private Quaternion quaternion;
    [SerializeField] LayerMask enemyMask;
    // Update is called once per frame
    void Update()
    {
        findTarget();
    }
    void beeShoot()
    {
        Vector2 direction = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(bullet, gameObject.transform.position, quaternion, gameObject.transform);
    }

    void findTarget()
    {
        if (Target == null)
        {
            Target = Physics2D.OverlapCircle(gameObject.transform.position, 5f, enemyMask).gameObject;
        }
        else beeShoot();


    }
}
