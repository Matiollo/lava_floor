using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] sisters;
    private int index;

    public Vector3 spawnPosition;

    Player playerScript;

    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        StartCoroutine(SpawnCharacters());
    }

    IEnumerator SpawnCharacters() {
        while(playerScript.canMove)
        {
            yield return new WaitForSeconds(20);

            index = Random.Range(0, 2);

            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            Instantiate(sisters[index], spawnPosition, rotation);
        }
    }
}
