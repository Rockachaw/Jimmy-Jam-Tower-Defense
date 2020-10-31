using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
//    public Transform enemyPrefab;
    public Transform spawnPoint;

    private float countdown;
    public float timeBetweenWaves;

    private int waveNumber = 0;

    public Transform[] waveOneEnemyPrefabs;
    public float waveOneTimeBetweenSpawns;
    public Transform[] waveTwoEnemyPrefabs;
    public float waveTwoTimeBetweenSpawns;
    public Transform[] waveThreeEnemyPrefabs;
    public float waveThreeTimeBetweenSpawns;
    public Transform[] waveFourEnemyPrefabs;
    public float waveFourTimeBetweenSpawns;
    public Transform[] waveFiveEnemyPrefabs;
    public float waveFiveTimeBetweenSpawns;
    public Transform[] waveSixEnemyPrefabs;
    public float waveSixTimeBetweenSpawns;
    public Transform[] waveSevenEnemyPrefabs;
    public float waveSevenTimeBetweenSpawns;
    public Transform[] waveEightEnemyPrefabs;
    public float waveEightTimeBetweenSpawns;
    public Transform[] waveNineEnemyPrefabs;
    public float waveNineTimeBetweenSpawns;
    public Transform[] waveTenEnemyPrefabs;
    public float waveTenTimeBetweenSpawns;

    void Update()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyArray.Length == 0 && countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        else if(enemyArray.Length == 0 && countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        //Only increment countdown after enemies have died

    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        SoundManagerScript.PlaySound("nextWave");
        UnityEngine.Debug.Log("Starting Wave " + waveNumber);

        switch (waveNumber)
        {
            case 1:
                foreach (Transform enemy in waveOneEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveOneTimeBetweenSpawns);
                }
                break;
            case 2:
                foreach (Transform enemy in waveTwoEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveTwoTimeBetweenSpawns);
                }
                break;
            case 3:
                foreach (Transform enemy in waveThreeEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveThreeTimeBetweenSpawns);
                }
                break;
            case 4:
                foreach (Transform enemy in waveFourEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveFourTimeBetweenSpawns);
                }
                break;
            case 5:
                foreach (Transform enemy in waveFiveEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveFiveTimeBetweenSpawns);
                }
                break;
            case 6:
                foreach (Transform enemy in waveSixEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveSixTimeBetweenSpawns);
                }
                break;
            case 7:
                foreach (Transform enemy in waveSevenEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveSevenTimeBetweenSpawns);
                }
                break;
            case 8:
                foreach (Transform enemy in waveEightEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveEightTimeBetweenSpawns);
                }
                break;
            case 9:
                foreach (Transform enemy in waveNineEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveNineTimeBetweenSpawns);
                }
                break;
            case 10:
                foreach (Transform enemy in waveTenEnemyPrefabs)
                {
                    SpawnEnemy(enemy);
                    yield return new WaitForSeconds(waveTenTimeBetweenSpawns);
                }
                break;
            default:
                break;
        }

        if(waveNumber > 10)
        {
            SoundManagerScript.PlaySound("win");
            SceneManager.LoadScene("WinScene");
        }
    }
    void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public int GetWave()
    {
        return waveNumber;
    }
}
