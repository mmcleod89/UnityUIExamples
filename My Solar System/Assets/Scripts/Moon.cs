using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private Planet myPlanet;
    private float r;
    private float phi;
    private float omega;

    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(2f, 4f);
        phi = Random.Range(0f, Mathf.PI * 2);
        omega = Random.Range(-10f, 10f);
    }

    public void SetPlanet(Planet p)
    {
        myPlanet = p;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = new Vector3(r * Mathf.Sin(phi), 0f, r * Mathf.Cos(phi));

        transform.position = myPlanet.transform.position + pos;

        phi = phi + omega * Time.deltaTime;
    }
}
