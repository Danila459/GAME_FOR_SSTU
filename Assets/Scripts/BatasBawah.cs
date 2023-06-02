using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatasBawah : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.tag=="Player"){
            PlayerHealth theplayerHealth = coll.gameObject.GetComponent<PlayerHealth>();
            theplayerHealth.makeDead();
        }
    }
}
