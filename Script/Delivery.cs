using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;

    bool hasPackaged;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D() {
        
        Debug.Log("Ouchh!!");
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Package" && !hasPackaged)
        {
            Debug.Log("Package picked up");
            hasPackaged = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackaged)
        {
            Debug.Log("Package is Delivered!");
            hasPackaged = false;
            spriteRenderer.color = noPackageColor;
        }
    }
    
    
}
