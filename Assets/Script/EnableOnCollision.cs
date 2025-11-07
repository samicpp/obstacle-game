using UnityEngine;

public class EnableOnCollision : MonoBehaviour
{
    public Behaviour component;
    public bool disable;
    public bool toggle;
    public string tagName = "";
    public string objName = "";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision info)
    {
        if ((tagName != "" && info.gameObject.CompareTag(tagName)) || info.gameObject.name == objName)
        {
            if (toggle) component.enabled = !component.enabled;
            else  component.enabled = !disable;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
