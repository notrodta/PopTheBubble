using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {

    public GameController gc;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bubble")
        {
            Destroy(col.gameObject);

            if (gc.health > 1)
            {
                StartCoroutine("FlashScreen");
                gc.health--;
                gc.health_text.text = "x" + gc.health;
            }
            else
            {
                gc.Gameover();
            }
        }
    }



}
