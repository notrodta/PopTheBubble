using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


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
        Debug.Log("menu");
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Play");
        }
    }
}
