using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public bool canBePressed;
    public bool reset; 
    public KeyCode keyToPress;
    public SpriteRenderer sr; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        canBePressed = false;
        reset = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                // gameObject.SetVisible(false);
                sr.enabled = false;
                reset = true;
                GameManager.instance.OnHit();
                GameManager.instance.reset = false; 
            }
        }

        if (GameManager.instance.reset == true && reset == true)
        {
            // gameObject.SetActive(true);
            sr.enabled = true;

            canBePressed = false;

            reset = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.arrowsLeft--;
            reset = true;
        }
    }
}
