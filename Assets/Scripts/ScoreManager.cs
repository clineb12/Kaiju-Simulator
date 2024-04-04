using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text DcText; //death counter text

    int score = 0;
    int deaths = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =score.ToString();
        DcText.text = deaths.ToString();
        
    }

    // Update is called once per frame
    public void addDeath()
    {
        deaths += 1;
        DcText.text =deaths.ToString();
    }

    public void addPoint(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }
};
