using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMovement : MonoBehaviour
{
    private int[] rotations = { 0, 90, 180, 270 };
    private int[] targets = { 1, 2, 3, 4 };

    public bool reset;
    public float speed; 
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    private Vector2 direction; 

    // Start is called before the first frame update
    void Start()
    {
        GetRotation();
        GetMoveDirection(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GetRotation(); 
    }

    private void GetRotation()
    {
        int rotation = rotations[Random.Range(0, rotations.Length)];
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    private void GetMoveDirection()
    {
        int target = targets[Random.Range(0, targets.Length)]; 
        switch (target)
        {
            case 1:
                direction = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
                break;
            case 2:
                direction = Vector2.MoveTowards(transform.position, target2.transform.position, speed * Time.deltaTime);
                break;
            case 3:
                direction = Vector2.MoveTowards(transform.position, target3.transform.position, speed * Time.deltaTime);
                break;
            case 4:
                direction = Vector2.MoveTowards(transform.position, target4.transform.position, speed * Time.deltaTime);
                break;
            default:
                break; 
        }
    }

    private void Move()
    {
        transform.localPosition += speed * (Vector3)(-direction) * Time.deltaTime;
    }
}
