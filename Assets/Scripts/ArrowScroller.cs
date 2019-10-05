using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScroller : MonoBehaviour
{
    public float speed;
    public bool hasStarted;
    public GameObject buttons;
    private Vector3 originalPosition; 
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (buttons.activeSelf)
            {
                hasStarted = true; 
            }
        }
        else
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f); 
        }
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        hasStarted = false;
        gameObject.SetActive(true); 
    }
}
