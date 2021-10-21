using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDestroy : MonoBehaviour
{
    public GameObject spawn;
    void Start()
    {
        spawn = GameObject.FindWithTag("Spawn");
    }
    void OnMouseDown()
    {
        spawn.GetComponent<Spawner>().destroyed = true;
        Destroy(gameObject);
    }
}
