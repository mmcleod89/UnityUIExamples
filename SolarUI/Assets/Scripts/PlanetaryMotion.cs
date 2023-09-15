using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryMotion : MonoBehaviour
{
    [SerializeField] float init_radius;
    [SerializeField] float init_phi;
    [SerializeField] Vector3 init_velocity;
    [SerializeField] GameObject explosion;
    private Vector3 velocity;

    const float GM = 10f;

    // Planet info
    [SerializeField] string planetName;

    [SerializeField] Material highlightMat;
    Material naturalMat;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        renderer = GetComponent<Renderer>();
        naturalMat = new Material(renderer.material);
    }

    public void Reset()
    {
        transform.position = new Vector3(init_radius * Mathf.Sin(init_phi), 0f, init_radius * Mathf.Cos(init_phi));
        velocity = init_velocity;
    }


    // Update is called once per frame
    void Update()
    {
        // Update Position
        transform.position = transform.position + Time.deltaTime * velocity;

        // Update Velocity
        Vector3 acc = - GM / (transform.position.sqrMagnitude) * transform.position.normalized;
        velocity += Time.deltaTime * acc;
    }

    public string PlanetInfo()
    {
        string info = "Name: " + planetName + "\n";
        info += "Radial distance: " + transform.position.magnitude.ToString() + "\n";
        info += "Velocity: " + velocity.ToString() + "\n";
        return info;
    }

    private void OnMouseDown()
    {
        var blast = Instantiate<GameObject>(explosion);
        blast.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        renderer.material = highlightMat;
    }

    private void OnMouseExit()
    {
        renderer.material = naturalMat;
    }
}
