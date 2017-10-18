using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    BubbleSpawner bs;
    PowerUp pu;
    GameOver go;
    public int health;

    public static int score;
    public TextMeshPro scoreText;
    public TextMeshPro highScoreText;
    public TextMeshProUGUI health_text;
    public CanvasGroup panel;

    public SpriteRenderer q, w, o, p;

    private void Start()
    {
        bs = GetComponent<BubbleSpawner>();
        pu = GetComponent<PowerUp>();
        go = GetComponent<GameOver>();
        health_text.text = "x" + health;
        score = 0;

        highScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }


    // Update is called once per frame
    void Update () {

        CleanUpList();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PowerUp.canPowerUp == false)
            {
                if (pu.powerUpIndex == 1) pu.DestroyAll();
                else if (pu.powerUpIndex == 2) pu.ColorMadness();
                pu.powerUpIndex = 0;
                pu.timer = 0;
                pu.progressBar.Value = 0;
                pu.powerUpText.gameObject.SetActive(false);
                PowerUp.canPowerUp = true;
            }
        }


        Sort();

        ButtonControl(KeyCode.Q, bs.Red);
        ButtonControl(KeyCode.W, bs.Blue);
        ButtonControl(KeyCode.O, bs.Green);
        ButtonControl(KeyCode.P, bs.Yellow);

        scoreText.text = "SCORE: " + score;
    }

    void Sort()
    {
        bs.Red = bs.Red.OrderBy(point => point.transform.position.y).ToList();
        bs.Blue = bs.Blue.OrderBy(point => point.transform.position.y).ToList();
        bs.Green = bs.Green.OrderBy(point => point.transform.position.y).ToList();
        bs.Yellow = bs.Yellow.OrderBy(point => point.transform.position.y).ToList();
    }

    void ButtonControl(KeyCode k, List<GameObject> g)
    {
        if (Input.GetKeyDown(k))
        {
            if (g.Count > 0)
            {
                Destroy(g[0]);
                g.RemoveAt(0);
                score++;
            }
            else
            {
                if (health > 1)
                {
                    StartCoroutine("FlashScreen");
                    health--;
                    health_text.text = "x" + health;
                }
                else
                {
                    Gameover();
                }
            }
            StartCoroutine(ButtonPressedAnimCo(k));
        }
    }

    IEnumerator ButtonPressedAnimCo(KeyCode k)
    {
        if (k == KeyCode.Q)
        {
            q.color = new Color(.5f, .5f, .5f, 1);
            yield return new WaitForSeconds(.1f);
            q.color = new Color(1,1,1,1);
        }
        else if (k == KeyCode.W)
        {
            w.color = new Color(.5f, .5f, .5f, 1);
            yield return new WaitForSeconds(.1f);
            w.color = new Color(1, 1, 1, 1);
        }
        else if (k == KeyCode.O)
        {
            o.color = new Color(.5f, .5f, .5f, 1);
            yield return new WaitForSeconds(.1f);
            o.color = new Color(1, 1, 1, 1);
        }
        else if (k == KeyCode.P)
        {
            p.color = new Color(.5f, .5f, .5f, 1);
            yield return new WaitForSeconds(.1f);
            p.color = new Color(1, 1, 1, 1);
        }
    }


    void CleanUpList()
    {
        for (int i = 0; i < bs.Red.Count; i++)
        {
            if (bs.Red[i] == null) bs.Red.RemoveAt(i);
        }
        for (int i = 0; i < bs.Blue.Count; i++)
        {
            if (bs.Blue[i] == null) bs.Blue.RemoveAt(i);
        }
        for (int i = 0; i < bs.Green.Count; i++)
        {
            if (bs.Green[i] == null) bs.Green.RemoveAt(i);
        }
        for (int i = 0; i < bs.Yellow.Count; i++)
        {
            if (bs.Yellow[i] == null) bs.Yellow.RemoveAt(i);
        }
    }


    public void Gameover()
    {
        Debug.Log("gameover gc");
        StoreScore(score);
        bs.levelTimer = 0;
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator FlashScreen()
    {
        panel.alpha = 1;
        while (panel.alpha > 0)
        {
            panel.alpha -= Time.deltaTime * 2.5f;
            yield return null;
        }
        panel.alpha = 0;
    }

    void StoreScore(int newHighscore)
    {
        PlayerPrefs.SetInt("score", score);

        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
    }


}
