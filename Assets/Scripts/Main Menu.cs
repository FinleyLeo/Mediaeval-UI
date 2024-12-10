using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator mainAnim, settingsAnim, confirmAnim, controlsAnim, pauseAnim;

    public GameObject settings, confirm, controls, pauseMenu;

    public Slider SFX, music;
    public TMP_Dropdown difficulty;

    public bool paused;

    private float clickDown;
    

    void Start()
    {
        if (gameObject.name == "Canvas")
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                mainAnim.SetTrigger("Down");
            }

            if (PlayerPrefs.HasKey("sfxVol"))
            {
                SFX.value = PlayerPrefs.GetFloat("sfxVol");
            }

            else
            {
                SFX.value = 1;
            }

            if (PlayerPrefs.HasKey("musicVol"))
            {
                music.value = PlayerPrefs.GetFloat("musicVol");
            }

            else
            {
                music.value = 1;
            }

            if (PlayerPrefs.HasKey("difficulty"))
            {
                difficulty.value = PlayerPrefs.GetInt("difficulty");
            }
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
        AudioManager.instance.PlaySFX("PageFlip");

        yield return new WaitForSeconds(4);

        StartCoroutine(LevelManager.instance.SceneTransition(1));
    }

    public void Settings()
    {
        settings.SetActive(true);
        mainAnim.SetTrigger("Up");
        settingsAnim.SetTrigger("Down");
        AudioManager.instance.PlaySFX("PageFlip");
    }

    public void Back()
    {
        mainAnim.SetTrigger("Down");
        settingsAnim.SetTrigger("Up");
        AudioManager.instance.PlaySFX("PageFlip");
    }

    public void Quit()
    {
        confirm.SetActive(true);
        mainAnim.SetTrigger("Up");
        confirmAnim.SetTrigger("Down");
        AudioManager.instance.PlaySFX("PageFlip");
    }

    public void QuitToMenu()
    {
        StartCoroutine(LevelManager.instance.SceneTransition(0));
    }

    public void Confirm()
    {
        StartCoroutine(LevelManager.instance.QuitTransition());
    }

    public void Deny()
    {
        mainAnim.SetTrigger("Down");
        confirmAnim.SetTrigger("Up");
        AudioManager.instance.PlaySFX("PageFlip");
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

    public void RandomSound()
    {
        int randSound = Random.Range(0, 3);

        if (randSound == 0)
        {
            AudioManager.instance.PlaySFX("Scribble1");
        }

        else if (randSound == 1)
        {
            AudioManager.instance.PlaySFX("Scribble2");
        }

        else if (randSound == 2)
        {
            AudioManager.instance.PlaySFX("Scribble3");
        }
    }

    public void SetDifficulty(int diff)
    {
        PlayerPrefs.SetInt("difficulty", diff);
    }

    public void AnimationSound(string sound)
    {
        AudioManager.instance.PlaySFX(sound);
    }
}
