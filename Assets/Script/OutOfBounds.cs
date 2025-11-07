using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;

    [SerializeField] private Vector3 spawnpoint;
    private Quaternion spawnRotation;
    public Vector3 offset;
    public Quaternion rotationOffset;

    public Vector3 top;
    public Vector3 bottom;

    private GameObject prefab;
    public bool clone;
    [SerializeField] private int clones = 1;
    public bool despawn;
    public float despawnTime;
    public bool resetVelocity;
    public bool resetAngularVelocity;
    public bool resetRotation;

    public List<Behaviour> disable = new();
    public List<Behaviour> enable = new();
    
    private bool done = false;
    
    public bool useTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Respawn");
        player = GetComponent<Transform>();
        if (!useTransform) rb = GetComponent<Rigidbody>();
        spawnpoint = player.position;
        spawnRotation = player.rotation;
        prefab = gameObject;
        // if (toClone == null) toClone = gameObject;
        // Debug.Log($"prefab is this {prefab == gameObject}");
    }
 
    // Update is called once per frame
    void Update()
    {
        if 
        (!done && (
            player.position.x > top.x || player.position.x < bottom.x || 
            player.position.y > top.y || player.position.y < bottom.y || 
            player.position.z > top.z || player.position.z < bottom.z
        ))
        {
            if (clone)
            {
                done = true;
                Quaternion rot = spawnRotation;
                if (!resetRotation) rot = player.rotation;
                // GameObject prefab = Resources.Load<GameObject>(prefabName);
                
                for (int i = 0; i < clones; i++)
                {
                    GameObject cloned = Instantiate(prefab, spawnpoint, rot);
                    
                    if (!useTransform)
                    {
                        var crb = cloned.GetComponent<Rigidbody>();
                        if(!resetVelocity) crb.linearVelocity = rb.linearVelocity;
                        if(!resetAngularVelocity) crb.angularVelocity = rb.angularVelocity;
                    } 
                    
                    var oob = cloned.GetComponent<OutOfBounds>();
                    oob.DisableEnable();
                    
                    cloned.SetActive(true);
                }
                
                if (despawn) Destroy(gameObject, despawnTime);
            }
            else if (despawn)
            {
                Destroy(gameObject, despawnTime);
            }
            else if (useTransform)
            {
                player.position = spawnpoint + offset;
                DisableEnable();
            }
            else
            {
                // player.position = spawnpoint;
                rb.MovePosition(spawnpoint + offset);
                // Debug.Log("Respawning player");

                if (resetVelocity) rb.linearVelocity = Vector3.zero;
                if (resetAngularVelocity) rb.angularVelocity = Vector3.zero;
                if (resetRotation) rb.rotation = spawnRotation;
                DisableEnable();
            }
        }
    }

    void DisableEnable()
    {
        foreach (Behaviour b in disable) b.enabled = false;
        foreach (Behaviour b in enable) b.enabled = true;
    }
}
