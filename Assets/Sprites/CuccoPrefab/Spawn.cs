using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    int whatToSpawn;
    private Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);
            Debug.Log(whatToSpawn);
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(prefab1, pos, Quaternion.identity);
                    //target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
                    //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    break;
                case 2:
                    Instantiate(prefab2, pos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(prefab3, pos, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(prefab4, pos, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(prefab5, pos, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
