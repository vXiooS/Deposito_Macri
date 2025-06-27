using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            PlayerPortalScript p = c.gameObject.GetComponent<PlayerPortalScript>();
            p._speed *= 2;
            Debug.Log("Player entered portal, speed doubled to: " + p._speed);
        }
    }
}
