using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject interactionText;
    public bool inReach = false;
    public string nextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(true);
            inReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionText.SetActive(false);
            inReach = false;
        }
    }

    private void Update()
    {
        if(inReach && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
