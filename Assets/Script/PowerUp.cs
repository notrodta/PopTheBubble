using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ProgressBars.Scripts;
using TMPro;


public class PowerUp : MonoBehaviour
{

    BubbleSpawner bs;

    public Transform bubbleParent;

    public float timer;
    public float maxTime;
    public static bool canPowerUp;
    public int powerUpIndex;

    public List<Sprite> sprites; // 0-red 1-blue 2-green 3-yellow
    public GuiProgressBar progressBar;

    public TextMeshPro powerUpText;

    private void Start()
    {
        timer = 0;
        bs = GetComponent<BubbleSpawner>();

        StartCoroutine(PowerUpTimerCo());

    }

    IEnumerator PowerUpTimerCo()
    {
        canPowerUp = true;
        while (GameOver.isGameOver == false)
        {
            while (timer <= maxTime  && canPowerUp)
            {
                progressBar.Value += Time.deltaTime/maxTime;
                timer += Time.deltaTime;
                yield return null;
            }

            if (canPowerUp)
            {
                powerUpIndex = Random.Range(1, 3);
                if (powerUpIndex == 1)
                {
                    powerUpText.gameObject.SetActive(true);
                    powerUpText.text = "DESTROY ALL";
                }
                else if (powerUpIndex == 2)
                {
                    powerUpText.gameObject.SetActive(true);
                    powerUpText.text = "COLOR MADNESS";
                }
                canPowerUp = false;
                Debug.Log(powerUpIndex);
            }
            yield return null;
        }
    }

    public void DestroyAll()
    {
        foreach (Transform child in bubbleParent)
        {
            GameObject.Destroy(child.gameObject);
            GameController.score++;
        }

        ClearAllList();
    }

    public void ColorMadness()
    {       
        BubbleSpawner.canSpawn = false;
        ClearAllList();

        
        int rand = Random.Range(0, 4);
        foreach (Transform child in bubbleParent)
        {
            child.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[rand];

            if (rand == 0) bs.Red.Add(child.gameObject);
            else if (rand == 1) bs.Blue.Add(child.gameObject);
            else if (rand == 2) bs.Green.Add(child.gameObject);
            else if (rand == 3) bs.Yellow.Add(child.gameObject);
        }
        BubbleSpawner.canSpawn = true;
    }

    public void ClearAllList()
    {
        bs.Red.Clear();
        bs.Blue.Clear();
        bs.Green.Clear();
        bs.Yellow.Clear();
    }



}

