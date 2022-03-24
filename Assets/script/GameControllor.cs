using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllor : MonoBehaviour
{
    [SerializeField]private GameObject wall_Ins_gameObject;
    [SerializeField]private GameObject wallPrefab;
    [SerializeField] private GameObject wallparent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "enemy" || collision.tag == "bullet" || collision.tag == "floor")
        {
            Destroy(collision.gameObject);
        }
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
