using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "WaveConfig")]

public class WaveConfig : ScriptableObject

{
    [SerializeField] GameObject waypoints;
    [SerializeField] float MovementSpeed = 5f;//default
    [SerializeField] GameObject EnemyPic;
    [SerializeField] int numberofEnemies = 5;
    [SerializeField] float timeBetweenSpawn = 0.5f;

    public float GetMovementSpeed()
    {
        return MovementSpeed;
    }


    public List<Transform> GetWayPoints()
    {
        var wavelocation= new List<Transform>();
        foreach(Transform child in waypoints.transform)
        {
            wavelocation.Add(child);
        }
        return wavelocation;
    }
    public int GetnumberofEnemies()
    {
        return numberofEnemies;
    }
    public GameObject getEnemypic()
    {
        return EnemyPic;
    }
    public float gettimebetweenSpawn()
    {
        return timeBetweenSpawn;
    }
}
