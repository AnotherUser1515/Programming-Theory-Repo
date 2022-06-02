using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(DespawnTimer());
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
