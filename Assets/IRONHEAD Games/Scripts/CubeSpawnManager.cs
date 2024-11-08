using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnManager : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject[] Cubeprefabs;
   

    public float timeRate;

    void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes() {

        while (true)
        {

            int spawnIndex = Random.Range(0, Spawnpoints.Length);
            int cubeIndex = Random.Range(0, Cubeprefabs.Length);

            Instantiate(Cubeprefabs[cubeIndex], Spawnpoints[spawnIndex].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(timeRate);
        }

    }

    //TODO: Implementar-ho fent servir una coroutine
    private void Update()
    {
        
    }
}
