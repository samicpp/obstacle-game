using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform _follower;
    public Transform followee;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("follow.cs");
        _follower = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _follower.position = followee.position + offset;
    }
}
