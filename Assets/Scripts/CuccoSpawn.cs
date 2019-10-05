using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuccoSpawn : MonoBehaviour
{

    public GameObject cucco;      // Apple Object in Scene (Sprite)
    public float spawnTime = 2f;            // How long between each spawn.
    public float fallSpeed = 40.0f;    //The speed of falling Apples
    private float timer = 0; //counting timer, reset after calling SpawnRandom() function
    private int randomNumber;       //variable for storage of an random Number
    private Rigidbody2D rb2D;
    private float thrust = 10.0f;
    public float speed;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        StartCoroutine(waiter());
        //rb2D = gameObject.AddComponent<Rigidbody2D>();
        //transform.position = new Vector3(0.0f, -2.0f, 0.0f);
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);
        SpawnRandom();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        /*
        timer += Time.deltaTime;   // Timer Counter
        if (timer > spawnTime)
        {
            SpawnRandom();       //Calling method SpawnRandom()
            timer = 0;        //Reseting timer to 0
        }*/
        //transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        //rb2D.AddForce(transform.up * thrust);
    }
    public void SpawnRandom()
    {

        //Creating random Vector3 position
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        //Instantiation of the Object
        Instantiate(cucco, screenPosition, Quaternion.identity);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

