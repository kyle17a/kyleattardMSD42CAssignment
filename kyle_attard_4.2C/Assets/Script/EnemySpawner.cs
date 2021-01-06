using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigsList;

    int startingWave = 0;


    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigsList[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        Instantiate(
            waveConfig.GetTruckPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

            
    }
}
