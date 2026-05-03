using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5.0f; //이동속도
    public FixedJoystick joystick; //조이스틱으로 이동하기
    public Button RestartButton;  //재시작 버튼
    
    public int time = 60;  //게임 시간 60초
    float timer = 0.0f;
    public Text TimeText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;  //시간 줄이기
        if (timer >= 1f) 
        {
            time--; 
            if(time > 0){
                TimeText.text = "Time : " + time; 
            }
            timer = 0f; 
        }

        if(time > 0){ //시간이 남아있을 때만 움직이기
            float moveHorizontal = joystick.Horizontal;  //조이스틱이동
            float moveVertical = joystick.Vertical;
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
            transform.position += movement * speed * Time.deltaTime;
        
        }
       
        if(time == 0){ //시간이 끝나면
            TimeText.text = "Game Over" ; 
            RestartButton.gameObject.SetActive(true);
        }
        
    }

   

}
