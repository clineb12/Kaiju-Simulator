using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    private bool isEaten = false; // if enemy is eaten
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isEaten){
        // distance we want the player to shoot
            float distance = Vector2.Distance(transform.position, player.transform.position); // this reprents the distance from the player

            if(distance < 10)
            {
                timer += Time.deltaTime;
                if(timer > 1)
                {
                    timer = 0;
                    shoot();
                }
            }
        }

    }
        void shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX("Shoot");
        }

        public void SetEaten(bool eaten)
        {
            isEaten = eaten;
        }
}