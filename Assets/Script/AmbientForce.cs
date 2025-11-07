using System;
using UnityEngine;

public class AmbientForce : MonoBehaviour
{

    private Rigidbody rb;
    private Transform tr;
    public Vector3 ambientForce;
    public Vector3 ambientForceRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        
        Console.WriteLine("wsg gng");
        Debug.Log("wsg gng");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(ambientForceRb * Time.deltaTime);
        tr.Translate(ambientForce * Time.deltaTime);
    }
}
