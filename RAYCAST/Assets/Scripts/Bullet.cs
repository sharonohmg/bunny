using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = .4f;



	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyBullet());
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position.x += speed;
        transform.position = position;
	}
    IEnumerator DestroyBullet (){
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
