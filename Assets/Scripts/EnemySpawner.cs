using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int StartingWave = 0;
    [SerializeField] bool looping = false;
    
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
       

    }
    IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = StartingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        
        for(int enemyCount = 0; enemyCount < waveConfig.GetnumberOfEnemies(); enemyCount++)
        {
            var newEnemy = 
            Instantiate(waveConfig.GetEnemyPrefab(),
            waveConfig.GetWavepoint()[0].transform.position,
            Quaternion.identity);
            newEnemy.GetComponent<FlyingEnemies>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

}
