using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool inReach = false;
    public string nextScene;
    public GameObject persistencePrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //interactionText.SetActive(true);
            inReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //interactionText.SetActive(false);
            inReach = false;
        }
    }

    private void Update()
    {
        if(inReach && Input.GetKeyDown(KeyCode.E))
        {
            if(nextScene == "Menu")
            {
                Persistence.Instance.destroy = true;
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                SceneManager.LoadScene(nextScene);
                PlayerLife.Instance.transform.position = new Vector3(-3f, 0, 0);
                Camera.main.transform.position = new Vector3(-3f, 0, 0);
            }
        }
    }
}
