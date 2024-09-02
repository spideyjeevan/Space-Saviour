using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEditor;
using System;

public class UImanager : MonoBehaviour
{
    [Header("loading and mainmenu")]
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private GameObject mainmenuUI;
    [SerializeField] private Slider progressbar;
    [SerializeField] private bool mainmenu;




    [Header("pauseUI")]
    [SerializeField] private GameObject pauseUI;



    [Header("gameoverUI")]
    [SerializeField] private GameObject gameoverUI;


    //volume button
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float Volume;
    [SerializeField] private Slider volumeSlider;



    public void Awake()
    {
        if (PlayerPrefs.HasKey("savedVolume"))
        {
            loadVolume();
        }
        else
        {
            volume();
        }

        

        if (mainmenu)
        {
            mainmenuUI.SetActive(true);
            loadingUI.SetActive(false);
        }
    }

    public void Update()
    {
        volume();
    }

    public void play(string sceneID)
    {
        if (mainmenu)
        {
            StartCoroutine(loadscene(sceneID));
        }
    }


    IEnumerator loadscene(string sceneID)
    {
        mainmenuUI.SetActive(false);
        loadingUI.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressbar.value = progress;
            yield return null;
        }

    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("application have been quit");
    }

    public void pause(bool pause)
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("stop");
    }

    public void resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void mainMenu(string sceneID)
    {
        SceneManager.LoadSceneAsync("main menu");
        Time.timeScale = 1;
    }

    public void gameover()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void volume()
    {
            Volume = volumeSlider.value;
            audioMixer.SetFloat("masterVolume", Volume);

            PlayerPrefs.SetFloat("savedVolume", Volume);
            PlayerPrefs.Save();
    }

    public void loadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("savedVolume");
        volume();
    }
}
