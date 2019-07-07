using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    [Header("Game Status")]
    public bool isGameOver;
    public bool isGamePause;
    public bool isGameWin;

    [Header("Object")]
    //public List<Obj_Star> objStar;
    public static int countSTAR = 0;
    public GameObject door;
    public bool isGetKey;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        Debug.Log("Game Start");
    }

    // GameOver Group
    public void GameOver()
    {
        StartCoroutine(w8ActiveUIGameOver());
    }
    IEnumerator w8ActiveUIGameOver()
    {
        yield return new WaitForSeconds(1);
        isGameOver = true;
    }

    // Game Remake
    public void GameRemake()
    {
        isGameOver = false;
        isGamePause = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Pause Group
    public void GamePause()
    {
        isGamePause = true;
        Time.timeScale = 0f;
    }
    public void GameUnPause()
    {
        isGamePause = false;
        Time.timeScale = 1f;
    }

    // Winner Group
    public void GameWin()
    {
        isGameWin = true;
    }

    public static void PlayerGrabStar(Obj_Star objStar)
    {
        countSTAR++;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
            GameWin();
    }
}
