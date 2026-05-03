using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    float currentTime = 0.0f; 
    public float createTime = 1;
    public GameObject SilmeFactory;

    public int time = 60;
    float timer = 0.0f;

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
            timer = 0f; 
        }

        if(time > 0){
            currentTime += Time.deltaTime; 
            if(currentTime>createTime){ 
                float x = Random.Range(-12.55f,12.55f); 
                float z = Random.Range(-6.5f,6.5f);
                GameObject slime = Instantiate(SilmeFactory);
                slime.transform.position = new Vector3(x,0.0f,z);  //땅 무작위 위치에 생성하기 
                currentTime = 0;
            }
        }
    }
}
