using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner_CS : MonoBehaviour
{
    // Start is called before the first frame update

    public static int EnemiesAlive = 0;

    public Wave_CS[] waves;
    public Transform spawnPoint;

    public float waveTimer = 5f;
    private float countDown = 2f;

    private int waveNum = 0;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = waveTimer;
            return;
        }
        countDown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {

        Wave_CS wave = waves[waveNum];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnem(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
            
        }
        waveNum++;
        if (waveNum ==  waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }
    }

    void SpawnEnem(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
        EnemiesAlive++;
    }
}
