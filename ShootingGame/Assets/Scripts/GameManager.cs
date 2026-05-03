using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text restartText;  
    public Button restartButton; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowUI()
    {
        restartText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("GameScene");
    }
}
