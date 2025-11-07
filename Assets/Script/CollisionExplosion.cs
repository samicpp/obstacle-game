using UnityEngine;

public class CollisionExplosion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    public string tagName = "";
    public string objName = "";
    public Vector3 force;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision info)
    {
        // Debug.Log($"collided with {info.gameObject.tag} -> {info.gameObject.name}");
        if ((tagName != "" && info.gameObject.CompareTag(tagName)) || info.gameObject.name == objName)
        {
            // Debug.Log("trigger");
            rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

