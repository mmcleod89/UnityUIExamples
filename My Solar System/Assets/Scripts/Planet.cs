using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float phi;
    [SerializeField] Moon moonObject;
    public int numMoons = 0;

    private Sun theSun;

    [SerializeField] Vector3 velocity;
    
    public Vector3 getVelocity()
    {
        return velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(radius * Mathf.Sin(phi), 0f, radius * Mathf.Cos(phi));
        theSun = FindObjectOfType<Sun>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate acceleration
        Vector3 acc = -theSun.GM / (transform.position.sqrMagnitude) * transform.position.normalized;

        // update position & velocity
        transform.position = transform.position + velocity * Time.deltaTime;
        velocity = velocity + acc * Time.deltaTime;

        transform.eulerAngles = transform.eulerAngles + new Vector3(0f, 100f * Time.deltaTime, 0f);
    }

    private void OnMouseDown()
    {
        var myMoon = Instantiate<Moon>(moonObject);
        myMoon.SetPlanet(this);
        numMoons++;
    }
}
