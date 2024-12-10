using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator mainAnim, settingsAnim, confirmAnim, controlsAnim, pauseAnim;

    public GameObject settings, confirm, controls, pauseMenu;

    public bool paused;

    private float clickDown;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            mainAnim.SetTrigger("Down");
        }
    }

    private void Update()
    {
        clickDown -= Time.deltaTime;
    }

    public void StartGame()
    {
        StartCoroutine(LoadTime());
    }

    IEnumerator LoadTime()
    {
        controls.SetActive(true);
        mainAnim.SetTrigger("Up");
        controlsAnim.SetTrigger("Down");

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Level");
    }

    public void Settings()
    {
        settings.SetActive(true);
        mainAnim.SetTrigger("Up");
        settingsAnim.SetTrigger("Down");
    }

    public void Back()
    {
        mainAnim.SetTrigger("Down");
        settingsAnim.SetTrigger("Up");
    }

    public void Quit()
    {
        confirm.SetActive(true);
        mainAnim.SetTrigger("Up");
        confirmAnim.SetTrigger("Down");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Confirm()
    {
        Application.Quit();
    }

    public void Deny()
    {
        mainAnim.SetTrigger("Down");
        confirmAnim.SetTrigger("Up");
    }

    public void PauseGame()
    {
        if (clickDown <= 0)
        {
            if (paused)
            {
                Cursor.lockState = CursorLockMode.Confined;

                pauseMenu.SetActive(true);
                pauseAnim.SetTrigger("Down");
            }

            else if (!paused)
            {
                Cursor.lockState = CursorLockMode.Locked;

                pauseAnim.SetTrigger("Up");
            }

            clickDown = 0.75f;
        }
    }

    public void Unpause()
    {
        if (clickDown <= 0)
        {
            Cursor.lockState = CursorLockMode.Locked;

            pauseAnim.SetTrigger("Up");

            clickDown = 0.75f;
        }
    }
}
