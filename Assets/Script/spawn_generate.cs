﻿using UnityEngine;

public class spawn_generate : MonoBehaviour {
    private float lastSpawnTime = 0;
    public float spawnInterval = 1.0f;
    public float spawnRadius = 2.0f;

    public GameObject enemyPrefab;
    public GameObject player;

    

    private void Update()
    {
        //spawnInterval 마다 update한다.
        if(Time.time - lastSpawnTime > spawnInterval)
        {
            Spawn();
            lastSpawnTime = Time.time;
        }
    }

    //spawn 생성 함수
    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab);
        var theta = Random.Range(0, 2 * Mathf.PI);
        var spawnPos = new Vector3(Mathf.Cos(theta), 0, Mathf.Sin(theta)) * spawnRadius;

        enemy.transform.position = player.transform.position + spawnPos;
    }
}