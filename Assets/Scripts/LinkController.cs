using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    public bool pause; 

    private Transform target; //Reference to player

    // Start is called before the first frame update
    void Start()
    {
        pause = false; 
        target = GameObject.FindGameObjectWithTag("Chicken").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // stops enemy(Link) from moving directly over the player(chicken)
        if(pause == false && Vector2.Distance(transform.position, target.position) > stoppingDist)
        {
            Debug.Log(target.position.x);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);      
        }
        
    }
}
