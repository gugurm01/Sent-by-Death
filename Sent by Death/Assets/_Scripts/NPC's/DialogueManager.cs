using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject mainCam;
    public GameObject player;

    public Animator animator;

    public Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        PlayerMove.player.rb.velocity = Vector2.zero;
        mainCam.GetComponent<CameraTarget>().enabled = false;
        player.GetComponentInChildren<AtiraeMIra>().enabled = false;
        player.GetComponentInChildren<ShootAndAim>().enabled = false;
        player.GetComponentInChildren<PlayerMove>().enabled = false;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            
        }


        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeLetters(sentence));
    }

    IEnumerator TypeLetters(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        mainCam.GetComponent<CameraTarget>().enabled = true;
        player.GetComponentInChildren<AtiraeMIra>().enabled = true;
        player.GetComponentInChildren<ShootAndAim>().enabled = true;
        player.GetComponentInChildren<PlayerMove>().enabled = true;
    }

}
