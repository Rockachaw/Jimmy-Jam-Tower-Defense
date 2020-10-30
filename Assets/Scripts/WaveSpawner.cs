using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 1f;
    private float countdown;

    private int waveNumber = 0;

    void Update()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyArray.Length == 0 && countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        else if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        //Only increment countdown after enemies have died

    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        UnityEngine.Debug.Log("Starting Wave " + waveNumber);
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        if(waveNumber >= 10)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public int GetWave()
    {
        return waveNumber;
    }
}
