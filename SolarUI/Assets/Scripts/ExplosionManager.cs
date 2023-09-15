using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private float timeIntantiated;
    // Start is called before the first frame update
    void Start()
    {
        timeIntantiated = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeIntantiated > 1f)
        {
            Destroy(gameObject);
        }
    }
}
