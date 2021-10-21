using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject circle;
    public GameObject scoreMan;
    private GameObject c;
    private Vector3 range, origin;
    private float waitTime;
    private bool spawned;
    public bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
        origin = transform.position;
        range = Random.insideUnitCircle * 5.0f;
        waitTime = 0.0f;
        spawned = false;
        scoreMan = GameObject.FindWithTag("Score");

    }

    // Update is called once per frame
    void Update()
    {
        //Every three seconds spawn a circle, delete it, then spawn a circle at a new random spot in the spawn zone
        
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          0);
        Vector3 randomCoordinate = origin + randomRange;

        //TODO: Make the wait_time less and less the more circles are destroyed
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
        if (destroyed)
        {
            scoreMan.GetComponent<Score>().IncrementScore();
            destroyed = false;
        }
    }
}
