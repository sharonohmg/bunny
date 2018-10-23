using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

   public Stats playerStats = new Stats();

    public int enemyDamage;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            DamagePlayer(enemyDamage);
            Destroy(other.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        playerStats.SetHealth();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DamagePlayer(int damage){
        playerStats.Health -= damage;
        if(playerStats.Health <= 0){
            Destroy(gameObject);
            GameManager.GM.StartCoroutine(GameManager.GM.Respawn());
        }
    }
}
