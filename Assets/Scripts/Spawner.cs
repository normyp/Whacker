using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject circle;
    private GameObject c;
    private Vector3 range, origin;
    private float waitTime;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        range = Random.insideUnitCircle * 4.5f;
        waitTime = 0.0f;
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Every three seconds spawn a circle, delete it, then spawn a circle at a new random spot in the spawn zone
        
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          0);
        Vector3 randomCoordinate = origin + randomRange;
        if (!spawned)
        {
            c = Instantiate(circle, randomCoordinate, Quaternion.identity);
            spawned = true;
        }
        if (waitTime <= 3.0f)
        {
            waitTime += Time.deltaTime;
        }
        else
        {
            Destroy(c);
            spawned = false;
            waitTime = 0.0f;
        }
    }
}
