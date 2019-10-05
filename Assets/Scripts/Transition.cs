using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Transition : MonoBehaviour
{
    public GameObject buttons;
    public GameObject escape; 

    // Start is called before the first frame update
    void Start()
    {
        Blink();
        ShowButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Blink()
    {
        escape.SetActive(false);
        yield return new WaitForSeconds(1);
        escape.SetActive(true);
        yield return new WaitForSeconds(1);
        escape.SetActive(false);
        yield return new WaitForSeconds(1);
        escape.SetActive(true);
    }

    void ShowButtons()
    {
        buttons.SetActive(true);
    }
}
