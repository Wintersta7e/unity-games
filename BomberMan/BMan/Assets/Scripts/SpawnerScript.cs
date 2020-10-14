using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject bombPrefab;

    private float minX = -2.55f;
    private float maxX = 2.55f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBombs());
    }

    IEnumerator SpawnBombs()        
    {
        // returns with new values
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        Instantiate(bombPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y),
            Quaternion.identity);

        StartCoroutine(SpawnBombs());
    }
}
