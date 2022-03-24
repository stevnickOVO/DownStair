using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeWallManger : MonoBehaviour
{
    [SerializeField] private GameObject wall_Ins_gameObject;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject wallparent;


    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject enemyPoint;
    [SerializeField] private GameObject bunnyEnemyPoint;
    [SerializeField] private GameObject BG_Pefebs;
    [SerializeField] private GameObject BG_PefebsPoint;
    [SerializeField]private float minX;
    [SerializeField]private float maxX;
    [SerializeField] private int enemyProbabillty;
    [SerializeField] private GameObject[] enemyList;
    [SerializeField] private GameObject flyShip;
    [SerializeField] private Text deepText;
    private int bossCount;
    private int deep;
    float time;
    float randomTime;
    float currTime;
    bool needTime=true;

    void Update()
    {
        randomMakeTime(minX+2, maxX);
        randomMakeTime(minX+2, maxX-2);
        randomMakeTime(minX, maxX);
        randomMakeTime(minX, maxX-2);

        deepCount();
    }
    public void floorMaker(float minX,float maxX)
    {
        GameObject floor = Instantiate(floorPrefab);
        floor.transform.localScale=new Vector3(Random.Range(2, 4), 3, 1);
        floor.transform.position = new Vector3(Random.Range(minX, maxX), -6, 0);
        enemyPoint = floor.transform.GetChild(0).gameObject;
    }
    public void enemyMaker()
    {
        int random = Random.Range(0, 100);

        if (random <= enemyProbabillty)
        {
            int randomEnemy = Random.Range(0, enemyList.Length);

            if (randomEnemy == 2)
            {
                Instantiate(enemyList[randomEnemy], bunnyEnemyPoint.transform.position, bunnyEnemyPoint.transform.rotation);
            }
            else Instantiate(enemyList[randomEnemy], enemyPoint.transform.position, enemyPoint.transform.rotation);
        }

        bossOneMaker();
    }
    public void randomMakeTime(float minX,float manX)
    {
        currTime += Time.deltaTime;

        if (needTime)
        {
            randomTime = Random.Range(2.5f, 3.5f);
            needTime = false;
        }
        
        if (randomTime <= currTime)
        {
            floorMaker(minX, manX);
            currTime = 0;
            needTime = true;
            enemyMaker();
        }
    }
    private void bossOneMaker()
    {
        if (deep / 20 > bossCount)
        {
            Instantiate(flyShip, enemyPoint.transform.position, enemyPoint.transform.rotation);
            bossCount++;
        }
    }
    private void deepCount()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            deep++;
            deepText.text = deep.ToString();
            time = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "enemy" || collision.tag == "bullet" || collision.tag == "floor"|| collision.tag == "trap")
            Destroy(collision.gameObject);
        
        if (collision.tag == "backgroundEnd")
            Destroy(collision.transform.parent.gameObject);

        if (collision.tag == "backgroundStart")
            Instantiate(BG_Pefebs, BG_PefebsPoint.transform.position, Quaternion.identity);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            Destroy(collision.gameObject);
            Instantiate(wallPrefab, wall_Ins_gameObject.transform.position, wall_Ins_gameObject.transform.rotation, wallparent.transform);
        }
    }
}
