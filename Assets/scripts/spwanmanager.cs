using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class spwanmanager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    private health healthScript;
    [SerializeField] private float spawnTime;



    void Start()
    {
        StartCoroutine(spawningObstacles(spawnTime));
    }

    IEnumerator spawningObstacles(float range)
    {
        while (true)
        {
            yield return new WaitForSeconds(range);
            Vector2 randomPos = new Vector2(Random.Range(-2.3f, 2.3f), 6);
            Instantiate(obstacles[Random.Range(0, 3)], randomPos, transform.rotation);
        }
    }

}
