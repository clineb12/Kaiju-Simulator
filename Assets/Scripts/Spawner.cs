using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private float spawnRateMin = 2f;
    [SerializeField] private float spawnRateMax = 10f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private bool canSpawn;
    [SerializeField] private int objectOffset; //Offset for random distance from spawner; recommended amount: 0-10
    static System.Random rand = new System.Random();
    public Vector2 spawnerOffset; //Offset from camera

    private void Update()
    {
        transform.position = new Vector2(Camera.transform.position.x + spawnerOffset.x, transform.position.y); //Keeps spawners a set distance from the camera, set by "Offset X" in the editor
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float spawnRate = rand.Next((int)spawnRateMin, (int)spawnRateMax); //gives a random spawn time to each enemy instance, set in the editor
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            Instantiate(enemy, new Vector2(transform.position.x + rand.Next(-objectOffset, 0), transform.position.y), Quaternion.identity); //spawns enemies a random distance away from the spawner, set in the editor
            spawnRate = rand.Next((int)spawnRateMin, (int)spawnRateMax);
        }
    }
}
