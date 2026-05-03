using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    public Text ScoreText;  //점수
    public Text BestScoreText; //최고점수
    int score=0;
    int bestscore=0;
    float timer = 0.0f;
    public int time = 60;

    AudioSource audio; //칼 효과음
  
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        bestscore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = "Best Score : " + bestscore; 
        BestScoreText.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;  
        if (timer >= 1f) 
        {
            time--;
            timer = 0f;

            if (time == 0)
            {
                if (score > bestscore)
                {
                    bestscore = score; 
                    PlayerPrefs.SetInt("BestScore", bestscore);
                }
                BestScoreText.text = "Best Score : " + bestscore;
                BestScoreText.gameObject.SetActive(true); 
                ScoreText.text = "Game Over";
            }
        
        }
    }

     void OnTriggerEnter(Collider other){ //칼이랑 슬라임이 부딫히면 슬라임 죽이기
        if(time > 0){
            if(other.tag=="Enemy"){
                audio.Play();
                SlimeController slimeController = other.GetComponent<SlimeController>();
                if(slimeController != null){
                    slimeController.Die();
                }
            score++;  //슬라임 죽으면 점수 올리기
            ScoreText.text = "Score : " + score;
            }
        }
    }
}
