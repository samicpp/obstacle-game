using UnityEngine;

public class VelocityCap : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 maxVelocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.x > maxVelocity.x) rb.linearVelocity = new Vector3(maxVelocity.x, rb.linearVelocity.y, rb.linearVelocity.z);
        if (rb.linearVelocity.y > maxVelocity.y) rb.linearVelocity = new Vector3(rb.linearVelocity.x, maxVelocity.y, rb.linearVelocity.z);
        if (rb.linearVelocity.z > maxVelocity.z) rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, maxVelocity.z);
    }
}
