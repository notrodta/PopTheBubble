using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

    PowerUp pu;
    BubbleSpawner bs;
    public static bool isGameOver;
    public TextMeshProUGUI score;

    GameController gc;

    public bool isGameOverScene;

    private void Start()
    {
        pu = GetComponent<PowerUp>();
        gc = GetComponent<GameController>();
        bs = GetComponent<BubbleSpawner>();
        //score.text = "Score: " + GameController.score;
    }


    /*
    public void EndGame()
    {
        StartCoroutine(EndGameCo());
    }

    IEnumerator EndGameCo()
    {
        Debug.Log("endgameco");
        bs.levelTimer = 0;
        float timePassed = 0;
        while (timePassed < 1.5f)
        {
            BubbleSpawner.canSpawn = false;
            foreach (Transform t in pu.bubbleParent)
            {
                Destroy(t.gameObject);
            }
            pu.ClearAllList();
            timePassed += Time.deltaTime;
            isGameOver = true;
            gc.Gameover();
            yield return null;
        }
    }*/

    public void MouseOver()
    {
        transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }

    public void MouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Play");
    }

    private void Update()
    {
        if (isGameOverScene)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Play");
            }
        }
    }
}
