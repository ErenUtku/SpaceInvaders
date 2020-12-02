using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping;
    [SerializeField]int startingwave = 0;
    IEnumerator Start()
    {
        do
        {
           yield return StartCoroutine(SpawnAllwaves());
        } while (looping == true);
    }
    IEnumerator SpawnAllwaves()
    {
        for(int waveIndex = startingwave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesinWave(currentWave));
        }
        
    }

    IEnumerator SpawnAllEnemiesinWave(WaveConfig waveConfig)
    {
        for (int enemycount = 0; enemycount < waveConfig.GetnumberofEnemies(); enemycount++)
        {
            var newenemy = Instantiate
            (waveConfig.getEnemypic(),
            waveConfig.GetWayPoints()[0].transform.position,
            Quaternion.identity
            );
            newenemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.gettimebetweenSpawn());
         
        }
    }


}
