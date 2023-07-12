using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject enemyInstance = CreateEnemy(spawnPoint.position);
            enemyInstance.GetComponent<BoidVectorController>().lightOn = other.gameObject.GetComponent<MechanicsManager>().lightsOn;
            other.gameObject.GetComponent<MechanicsManager>().BoidObject = enemyInstance;
        }
    }

    public GameObject CreateEnemy(Vector3 spawn)
    {
        return Instantiate(enemy, spawn, enemy.transform.rotation);
    }
}
