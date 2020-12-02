using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveconfig;
    List<Transform> wavepoints;

    int wavepointIndex=0;

   void Start()
    {
        wavepoints = waveconfig.GetWayPoints();
        transform.position = wavepoints[wavepointIndex].transform.position;
    }

    void Update()
    {
        Move();
        
    }
    public void SetWaveConfig(WaveConfig waveconfig)
    {
        this.waveconfig = waveconfig;
    }
    private void Move()
    {
        if (wavepointIndex <= wavepoints.Count-1)
        {
            var targetposition = wavepoints[wavepointIndex].transform.position;
            var movement = waveconfig.GetMovementSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, movement);
            if(transform.position==targetposition)
            {
                wavepointIndex++;
            }
        }
        else { Destroy(gameObject); }
       
    }
    
}
