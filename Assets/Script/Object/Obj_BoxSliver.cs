using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Obj_BoxSliver : MonoBehaviour
{
    [Header("Object Box")]
    public Sprite imgTreasure;
    public GameObject Obj_KeySliver;
    private bool openTreasure = false;
    public int numofBox;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player" && openTreasure == false)
        {
            UIManager.current.BTOpenObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            UIManager.current.BTOpenObject.SetActive(false);
        }
    }

  
    public void OpenBox(int numofTreasure)
    {
        openTreasure = true;
        UIManager.current.BTOpenObject.SetActive(false);

        GetComponent<SpriteRenderer>().sprite = imgTreasure;
        Obj_KeySliver.SetActive(true);
    }

}
