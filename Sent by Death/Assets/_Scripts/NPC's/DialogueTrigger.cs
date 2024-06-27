using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent startnextSentence;
    public GameObject eButton;

    private void OnMouseOver()
    {
        TriggerDialogue();
        eButton.SetActive(true);
    }

    private void OnMouseExit()
    {
        eButton.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }

  
}
