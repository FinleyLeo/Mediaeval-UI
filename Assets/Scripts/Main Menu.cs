using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator mainAnim, settingsAnim, confirmAnim;

    public GameObject settings;
    void Start()
    {
        
    }

    public void StartGame()
    {

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
        Application.Quit();
    }
}
