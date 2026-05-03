using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public int count = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        /*if(h !=0 || v !=0){
            Debug.Log("h : " + h + "v : " + v);
        }*/
        Vector3 dir =new Vector3(h,v,0);
        transform.position = transform.position+dir*speed*Time.deltaTime;
    }
}
