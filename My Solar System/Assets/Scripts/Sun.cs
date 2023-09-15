using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] public float GM = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReverseGravity()
    {
        GM *= -1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
