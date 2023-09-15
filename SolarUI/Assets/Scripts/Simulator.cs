using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulator : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text planetInfo;
    [SerializeField] Camera cam;

    [SerializeField] List<PlanetaryMotion> planets;

    private float t_0 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Reset()
    {
        foreach(var planet in planets)
        {
            planet.Reset();
        }
        t_0 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "t = " + (Time.time - t_0).ToString();

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.tag == "Planet")
            {
                var planet = hit.collider.gameObject.GetComponent<PlanetaryMotion>();
                planetInfo.text = planet.PlanetInfo();
            }
        }
    }
}
