using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int scale = 15; 
    public float speed = 10.0f;
    public bool pause; 
    private Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        pause = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (pause == false)
        {
            CheckInput();
            Move(direction);
            UpdateOrientation();
        }
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left; 
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
    }

    void Move(Vector2 d)
    {
        transform.localPosition += speed * (Vector3)d * Time.deltaTime;
    }

    void UpdateOrientation()
    {
        if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(-scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.up)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 90); 
        }
        else if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.down)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }


}
