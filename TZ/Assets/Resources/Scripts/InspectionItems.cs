using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionItems : MonoBehaviour
{
    public GameObject itemButton;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            itemButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            itemButton.SetActive(false);
        }
    }
}
