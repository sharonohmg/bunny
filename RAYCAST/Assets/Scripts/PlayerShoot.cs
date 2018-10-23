using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }


}
