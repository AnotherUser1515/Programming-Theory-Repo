using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    void Update()
    { 
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true);
            pooledProjectile.transform.position = GenerateSpawnPosition();
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(1f, 10f);
        float spawnPosY = Random.Range(1f, 5f);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 15);
        return randomPos;
    }
}
