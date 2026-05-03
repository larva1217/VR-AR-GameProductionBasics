using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;
    public Text bestScoreUI;
    private int bestScore;
    public int Score{
        get{
            return currentScore;
        }
        set{
            currentScore = value;
            currentScoreUI.text = "Score : " + currentScore;
            if(currentScore > bestScore){
                bestScore = currentScore;
                bestScoreUI.text = "Best : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    public static ScoreManager Instance = null;

    void Awake(){
        if(Instance==null){
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "Best : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public int GetScore(){
        return currentScore;
    }

    public void SetScore(int value){
        currentScore = value;
        currentScoreUI.text = "Score : " + currentScore;

        if(currentScore>bestScore){
            bestScore = currentScore;
            bestScoreUI.text = "Best : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }*/
}
