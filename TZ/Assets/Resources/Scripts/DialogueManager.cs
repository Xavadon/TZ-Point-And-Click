using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image _dialogueImage;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    public Animator boxAnim;
    public Animator startAnim;

    public delegate void DialogueAction();
    private Queue<DialogueAction> dialogue_actions;

    private void Start()
    {
        dialogue_actions = new Queue<DialogueAction>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        //startAnim.SetBool("startOpen", false);
        //GameObject.Find("Character").GetComponent<Animator>().SetBool("is_talking", true);

        dialogue.OnDialogueStart.Invoke(); //invoking dialogue start events 

        foreach (Dialogue.Sentence sentence in dialogue.sentences)
        {
            dialogue_actions.Enqueue(() => StartCoroutine(TypeSentence(sentence))); //enquing dialogue sentences
        }
        dialogue_actions.Enqueue(() => EndDialogue()); //enquing dialogue end
        dialogue_actions.Enqueue(() => dialogue.OnDialogueEnd.Invoke()); //enquing dialogue end events

        NextMessage();
    }

    IEnumerator TypeSentence(Dialogue.Sentence sentence)
    {
        _dialogueImage.sprite = sentence.Sprite;
        dialogueText.text = "";
        nameText.text = sentence.name;
        foreach (char letter in sentence.text)
        {
            dialogueText.text += letter;
        }
        yield return null;
    }

    public void NextMessage()
    {
        StopAllCoroutines();
        dialogue_actions.Dequeue().Invoke(); //invoking next event
    }

    public void EndDialogue()
    {
        while (dialogue_actions.Count != 0)
        {
            NextMessage();
        }
        boxAnim.SetBool("boxOpen", false);
        //GameObject.Find("Character").GetComponent<Animator>().SetBool("is_talking", false);
    }

    public void AbruptEnding()
    {
        dialogue_actions.Clear();
        boxAnim.SetBool("boxOpen", false);
        //GameObject.Find("Character").GetComponent<Animator>().SetBool("is_talking", false);
    }
}