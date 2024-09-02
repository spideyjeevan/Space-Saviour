using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    [SerializeField] private int Currentscore;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    
    void Update()
    {
        scoreText.text = Currentscore.ToString();
    }



    public void addScore(int scoreRage)
    {
        Currentscore += scoreRage;
    }
}
