using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static int health;
    public bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            dead = true;
            if (dead == true)
            {
                Debug.Log("Enemy has died.");
            }
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        //SceneManager.LoadScene("prototype_1");
        yield return null;

    }
}
