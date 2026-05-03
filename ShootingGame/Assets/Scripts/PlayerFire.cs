using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public int Count = 0; 
    public int max = 3; 
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10; 
    public List<GameObject> bulletObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new List<GameObject>();

        for(int i=0; i<poolSize; i++){
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }

#if UNITY_ANDROID
        GameObject.Find("Joystick Canvas").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick Canvas").SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetButtonDown("Fire1")){
        
        Fire();
    }
    }

    public void Fire(){
        if(Input.GetButtonDown("Fire1")){
            //GameObject bullet = Instantiate(bulletFactory);
            /*for(int i=0; i<poolSize; i++){
                GameObject bullet = bulletObjectPool[i];
                if(bullet.activeSelf == false){
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }
            }*/

            if(bulletObjectPool.Count > 0){
                GameObject bullet = bulletObjectPool[0];
                bulletObjectPool.Remove(bullet);
                bullet.transform.position = firePosition.transform.position;
                bullet.SetActive(true);
            }
        }
    }
}
