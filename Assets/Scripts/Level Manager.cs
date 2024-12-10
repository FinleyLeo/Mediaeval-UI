using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    int difficulty;

    public Animator transition;

    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("difficulty"))
        {
            difficulty = PlayerPrefs.GetInt("difficulty");
        }

        else
        {
            difficulty = 1;
        }
    }

    public IEnumerator SceneTransition(int scene)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    public void SceneStart(string startMusic)
    {
        transition.SetTrigger("Start");
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayMusic(startMusic);
    }

    public IEnumerator QuitTransition()
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
