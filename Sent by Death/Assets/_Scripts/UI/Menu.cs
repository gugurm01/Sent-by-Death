using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public string sceneName;

    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +0);
        Destroy(Persistence.Instance.gameObject);
    }

    public void ChangeMenus(GameObject nextButton)
    {
        EventSystem.current.SetSelectedGameObject(nextButton);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }

    public void BackToMenu()
    {
        Destroy(Persistence.Instance.gameObject);
        SceneManager.LoadScene("Menu");
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
    }
}
