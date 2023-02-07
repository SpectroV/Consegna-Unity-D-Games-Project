using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Start() 
    {
        mixer.GetFloat("volume",out value);
        volumeSlider.value = value;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SetVolume()
    {
        Debug.Log("Loading Option Menu.......");
        mixer.SetFloat("volume", volumeSlider.value);
        
    }
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ExitGame ()
    {
        Debug.Log("Exiting game.....");
        Application.Quit();
    }
}
