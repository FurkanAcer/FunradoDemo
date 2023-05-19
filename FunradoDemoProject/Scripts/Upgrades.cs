using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject _upgrade;
    public Transform[] spawnPoints; 
    private int spawnCount = 3;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnObject(i);
        }
    }
    private void SpawnObject(int index)
    {
        Transform spawnPoint = spawnPoints[index];
        GameObject spawnedObject = Instantiate(_upgrade, spawnPoint.position, spawnPoint.rotation);
        spawnedObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }


}

