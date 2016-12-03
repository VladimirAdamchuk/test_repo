﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject EnemyPrefab;
    public FollowObject cameraMover;

    public int spawnRateMax = 5;
    public int spawnRateMin = 1;

    public Transform[] spawnPosition;
    public List<Transform> enemiesSpawend = new List<Transform>();

    public bool spawnEnemiesNow;

    bool holdPlayer;

	void Start ()
    {
	
	}
	
	

	void Update ()
    {
        if (spawnEnemiesNow)
        {
            holdPlayer = true;
            SpawnEnemies();
            spawnEnemiesNow = false;
        }
        if (holdPlayer)
        {
            cameraMover.enabled = false;

        }
        else
        {
            cameraMover.enabled = true;
        }
        if(enemiesSpawend.Count == 0)
        {
            holdPlayer = false;
        }
	}
    void SpawnEnemies()
    {
        int ranValue = Random.Range(spawnRateMin, spawnRateMax + 1);
        for(int i = 0; i<ranValue; i++)
        {
            int ranSpawn = Random.Range(0, spawnPosition.Length);
            GameObject go = Instantiate(EnemyPrefab, spawnPosition[ranSpawn].position, Quaternion.identity) as GameObject;
            enemiesSpawend.Add(go.transform);
        }
    }
}
