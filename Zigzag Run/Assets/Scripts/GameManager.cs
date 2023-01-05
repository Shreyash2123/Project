using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    public bool isGameStarted;
    public GameObject platformSpawner;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public GameObject newHighScoreImage;
    public Text lastScoreText;


    [Header("Score")]
    public Text scoreText; 
    public Text bestText; 
    public Text diamondText;
    public Text starText;

    int score = 0;
    int bestScore, totalDiamond, totalStar;
    bool countScore;

    private void Awake()
    {
         if(instance == null)
         {
             instance = this;
         }
    }

    // Start is called before the first frame update
    void Start()
    {
        // total Diamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();
        // total Star
        totalStar = PlayerPrefs.GetInt("totalStar");
        starText.text = totalStar.ToString();
        // Best SCore
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        countScore = true;
        StartCoroutine("UpdateScore");
        isGameStarted = true; 
        platformSpawner.SetActive(true);
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);

        if(score>bestScore)
        {
           PlayerPrefs.SetInt("bestScore",score);
           newHighScoreImage.SetActive(true);
        }
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if(score>bestScore)
            {
                scoreText.text = score.ToString("D5");
                bestText.text = score.ToString();
            }
            else
            {
                scoreText.text = score.ToString("D5");
            }
        }
    }

    public void ReplayGame(){
        SceneManager.LoadScene("BaseLevel");
    }

    public void GetStar(){
        int newStar= totalStar++;
        PlayerPrefs.SetInt("totalStar",newStar);
        starText.text = newStar.ToString();
    }

    public void GetDiamond(){
        int newDiamond= totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond",newDiamond);
        diamondText.text = newDiamond.ToString();
    }
    
}
