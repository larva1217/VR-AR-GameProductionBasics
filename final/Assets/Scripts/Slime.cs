using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float speed = 3f; //이동속도
    Rigidbody slimeRigidbody;
    Transform target; //플레이어 위치

    // Start is called before the first frame update
    void Start()
    {
        slimeRigidbody = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.position-transform.position).normalized;
        slimeRigidbody.transform.LookAt(target);
        slimeRigidbody.velocity = dir*speed;

    }
}
