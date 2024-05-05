
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pressable : MonoBehaviour
{
    private SpriteRenderer outline_image;
    public Color inactive_color;

    public UnityEvent OnPress;
    public UnityEvent OnExit;

    void Start()
    {
        outline_image = GetComponent<SpriteRenderer>();
        outline_image.color = Color.white;  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetKeyDown();
        }
    }


    private void OnDisable() {
        //FindObjectOfType<DialogueManager>().EndDialogue();
        OnExit.Invoke();
        
    }

    public void OnMouseEnter() {
        outline_image.color = Color.white;

    }

    public void OnMouseExit() {
        outline_image.color = inactive_color;
    }

    private void GetKeyDown() {
        OnPress.Invoke();
        Debug.Log("putton pressed");
        
    }

}
