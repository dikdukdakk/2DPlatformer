using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager current;

    [Header("UI Heart")]
    public int countHeart;
    public List<GameObject> listHeart = new List<GameObject>();

    [Header("UI Face")]
    public List<Sprite> listFace = new List<Sprite>();
    private Image myFace;
    private bool playerhurt;

    [Header("UI STAR")]
    public int countSTAR;
    public List<GameObject> listSTAR = new List<GameObject>();


    [Header("UI Game Status")]
    public GameObject UIGameOver;
    public GameObject UIGamePause;
    public GameObject UIGameWin;

    [Header("UI GameObject")]
    public GameObject BTOpenObject;
    public GameObject BTOpenDoor;

    private void Start()
    {
        current = this; 
    }

    private void Update()
    {
        //call funtion UIGameStatus
        UIGameStatus();

        //call funtuin UIHeart
        UIHeart();

        //call funtion UIFace
        UIFace();

        //call funtion UIGameWins GET STAR
        UISTAR();
    }

    public void UIGameStatus() //Game Status UI
    {
        if (GameManager.current.isGameOver)
            UIGameOver.SetActive(true);
        else
            UIGameOver.SetActive(false);

        if (GameManager.current.isGamePause)
            UIGamePause.SetActive(true);
        else
            UIGamePause.SetActive(false);

        if (GameManager.current.isGameWin)
            UIGameWin.SetActive(true);
        else
            UIGameWin.SetActive(false);
    }

    public void UIHeart() // +- Heart
    {
        countHeart = PlayerHeart.current.heart;
        if (countHeart == 3)
            listHeart[2].SetActive(true);
        else if (countHeart == 2)
        {
            listHeart[2].SetActive(false);
            listHeart[1].SetActive(true);
        }
        else if (countHeart == 1)
            listHeart[1].SetActive(false);
        else
        {
            foreach (GameObject AllHeart in listHeart)
                AllHeart.SetActive(false);
        }
    } 

    public void UISTAR()
    {
        countSTAR = GameManager.countSTAR;
        switch (countSTAR)
        {
            case 1: listSTAR[0].SetActive(true); break;
            case 2: listSTAR[1].SetActive(true); break;
            case 3: listSTAR[2].SetActive(true); break;
        }

    }
   
    public void UIFace() // Change Face when player hurts
    {
        myFace = GameObject.Find("Face").GetComponent<Image>(); // Finding object Face
        playerhurt = PlayerHeart.current.hurt;
        if (playerhurt)
            myFace.sprite = listFace[1];
        else
            myFace.sprite = listFace[0];
    }

  
}
