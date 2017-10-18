using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    public string name;
    public int index;

    public GameObject ps;
    public BubbleSpawner bs;

    Vector2 direction;
    float randomHorizontalSpeed;
    float verticalSpeed;

    void Awake()
    {

        transform.localScale = new Vector3(1, 1, 1);

        randomHorizontalSpeed = Random.Range(0f, 3f) / transform.localScale.x;
        verticalSpeed = 1 / transform.localScale.x;

        int randomDirection = Random.Range(0, 2);

        if (randomDirection == 1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }
    }

    void OnDisable()
    {
        Instantiate(ps, transform.position, transform.rotation);
    }

    private void Start()
    {
        bs = GameObject.Find("Scripts").GetComponent<BubbleSpawner>();

        if (name == "red")
            index = bs.r;
        if (name == "blue")
            index = bs.b;
        if (name == "green")
            index = bs.g;
        if (name == "yellow")
            index = bs.y;

        //Debug.Log(name +" " + index);
    }

    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime * randomHorizontalSpeed);
        transform.Translate(Vector2.down * Time.deltaTime * verticalSpeed * 1.5f);
    }

    public void OnRegularSpawn()
    {
        int randomSize = Random.Range(0, 11);

        if (randomSize >= 0 && randomSize <= 4)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (randomSize > 4 && randomSize <= 7)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (randomSize > 7 && randomSize <= 9)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(4, 4, 1);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            direction = -direction;
        }

        if (col.gameObject.tag == "field")
        {
            Transform parent = GameObject.Find("bubbles").transform;
            this.transform.parent = parent;

            if (name == "red") bs.Red.Add(this.gameObject);
            else if (name == "blue") bs.Blue.Add(this.gameObject);
            else if (name == "green") bs.Green.Add(this.gameObject);
            else if (name == "yellow") bs.Yellow.Add(this.gameObject);
        }
    }

}
