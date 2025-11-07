using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float jumpClearance;
    public float airboundPenalty = 0.5f;
    
    public Transform player;
    public Rigidbody rb;
    public Collider coll;
    
    public bool allowJump = true;
    public bool allowSideways = true;
    public bool allowFwBw = true;

    void Start()
    {
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    bool Grounded()
    {
        return Physics.Raycast(player.position, Vector3.down, coll.bounds.extents.y + jumpClearance);
    }
    
    void FixedUpdate()
    {
        bool canJump = Grounded();
        if(allowJump && Keyboard.current.spaceKey.IsPressed() && canJump)
        {
            rb.AddForce(Vector3.up * (jumpHeight * Time.deltaTime), ForceMode.Impulse);
        }
        if(allowFwBw && Keyboard.current.wKey.isPressed) rb.AddForce(Time.deltaTime * speed * (canJump ? 1f : airboundPenalty) * Vector3.forward);
        if(allowSideways && Keyboard.current.aKey.isPressed) rb.AddForce(Time.deltaTime * speed * (canJump ? 1f : airboundPenalty) * Vector3.left);
        if(allowFwBw && Keyboard.current.sKey.isPressed) rb.AddForce(Time.deltaTime * speed * (canJump ? 1f : airboundPenalty) * Vector3.back);
        if(allowSideways && Keyboard.current.dKey.isPressed) rb.AddForce(Time.deltaTime * speed * (canJump ? 1f : airboundPenalty) * Vector3.right);
    }
}
