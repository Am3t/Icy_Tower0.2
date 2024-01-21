using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenaration : MonoBehaviour
{
    public GameObject platformPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();

        for (int i = 0; i < 10; i++){
            SpawnerPosition.x = Random.Range(-3f, 3f);
            SpawnerPosition.y += Random.Range(2f,4f);

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);
        }
    }

}
