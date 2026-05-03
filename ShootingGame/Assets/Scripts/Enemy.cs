using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject explosionFactory;
    public float speed = 5.0f;
    Vector3 dir;

    GameManager gamemanager;
   

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.down;
        transform.position += dir*speed*Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision){
        /*GameObject smObject = GameObject.Find("ScoreManager");
        if(smObject!=null){
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.SetScore(sm.GetScore() + 1);
        }*/
        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);

        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if(collision.gameObject.name.Contains("Bullet")){
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(collision.gameObject);
        }

        else if (collision.gameObject.name.Contains("Player"))
        {
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.Count++; 

            if (player.Count >= player.max)
            {
                Destroy(collision.gameObject);
                gamemanager.ShowUI();
                GameObject.Find("Joystick Canvas").SetActive(false); 
            }
        }

        else{
            Destroy(collision.gameObject);
        }

        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        manager.enemyObjectPool.Add(gameObject);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void OnEnable(){
         int randValue = Random.Range(0,10);
        if(randValue<3){
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position-transform.position;
            dir.Normalize();
        }
        else{
            dir = Vector3.down;
        }
    }
}
