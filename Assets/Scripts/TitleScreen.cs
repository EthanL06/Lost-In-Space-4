using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public Animator animator;
    public GameObject controlsMenu;
    public GameObject[] mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToControls() {
        foreach (GameObject menu in mainMenu) {
            menu.SetActive(false);
        }
        controlsMenu.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator LoadScene()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
