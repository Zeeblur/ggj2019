using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hazard;
    public GameObject reward;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public List<GameObject> poopers;
    public List<GameObject> gems;

    void Start ()
    {
        StartCoroutine (SpawnWaves ());
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                int myRand = Random.Range(0, 11);

                GameObject go;
                if (myRand < 3)
                {
                    go = Instantiate (reward, spawnPosition, spawnRotation) as GameObject;
                }
                else
                {
                    go = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
                }

                
                go.transform.parent = this.transform;
                poopers.Add(go);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
        }
    }
}