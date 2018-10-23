﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    public GameObject prefab;
    private GameObject respawnPoint;
   // public int lives;

    void Awake()
    {
        if (GM == null){
            GM = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

    }

    public IEnumerator Respawn (){
        //lives -= 1;
        //if (lives < 0){
        //    Debug.Log("Died");
        //}
        yield return new WaitForSeconds(2f);
        //if(lives >=0)
            Instantiate(prefab, respawnPoint.transform.position, respawnPoint.transform.rotation);


    }

}
