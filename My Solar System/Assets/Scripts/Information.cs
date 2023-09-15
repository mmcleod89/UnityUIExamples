using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    [SerializeField] Text infoDisplay;
    [SerializeField] string planetName;

    private Planet thisPlanet;

    // Start is called before the first frame update
    void Start()
    {
        thisPlanet = GetComponent<Planet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        infoDisplay.text = "Name: " + planetName + "\nPosition = " + transform.position.ToString() + "\nVelocity = " + thisPlanet.getVelocity().ToString() + "\n";
        infoDisplay.text += "Number of moons = " + thisPlanet.numMoons + "\n";
    }
}
