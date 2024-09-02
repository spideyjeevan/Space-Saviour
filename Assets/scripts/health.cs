using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField] private int healthLevel;
    [SerializeField] private int maxHealth = 100;
    public  bool alive = true;
    [SerializeField] private Slider slider;
    [SerializeField] private int healthRange;



    [SerializeField] private GameObject gameoverUI;

    void Awake()
    {
        healthLevel = maxHealth;
        slider.value = healthLevel;
    }

    public void damage(int amount)
    {
      healthLevel -= amount;
      slider.value = healthLevel;

        if (healthLevel <= 0 && alive)
        {
            alive = false;
            Debug.Log("game over");
            gameoverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
