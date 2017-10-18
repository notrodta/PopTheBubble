using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: take out name and index, r,b,g,y. may not need them

public class BubbleSpawner : MonoBehaviour {

    public List<GameObject> bubble;
    public List<Transform> spawnPos;

    public List<GameObject> Red, Blue, Green, Yellow; //0,1,2,3
    public static bool canSpawn;

    public int r, b, g, y;

    public float level1, level2, level3, level4, level5;
    public float levelTimer;

    private void Awake()
    {
        levelTimer = 0;
        StartCoroutine(StartGameCo());
    }

    public void SpawnBubble()
    {
        int bi = Random.Range(0,4);
        int pi = Random.Range(0,spawnPos.Count);
        GameObject bubbleClone = (GameObject)Instantiate(bubble[bi],spawnPos[pi].position,Quaternion.identity);
    }

    private void Update()
    {
        levelTimer += Time.deltaTime;
    }

    IEnumerator StartGameCo()
    {
        GameController.score = 0;
        canSpawn = true;
        GameOver.isGameOver = false;

        float bubbleSpawnRate = 1.5f;
        while (GameOver.isGameOver == false)
        {
            if (canSpawn)
            {
                float rand = Random.Range(0f, bubbleSpawnRate);
                yield return new WaitForSeconds(rand);
                SpawnBubble();
                
                if (levelTimer >= level1 && levelTimer < level2)
                {
                    bubbleSpawnRate = 1.25f;
                    Debug.Log("level1: " + bubbleSpawnRate + " "+ levelTimer);
                }
                else if (levelTimer >= level2 && levelTimer < level3)
                {
                    bubbleSpawnRate = 1.0f;
                    Debug.Log("level2: " + bubbleSpawnRate + " " + levelTimer);
                }
                else if (levelTimer >= level3 && levelTimer < level4)
                {
                    bubbleSpawnRate = 0.75f;
                    Debug.Log("level3: " + bubbleSpawnRate + " " + levelTimer);
                }
                else if (levelTimer >= level4 && levelTimer < level5)
                {
                    bubbleSpawnRate = 0.5f;
                    Debug.Log("level4: " + bubbleSpawnRate + " " + levelTimer);
                }
            }
            yield return null;
        }
    }





}
