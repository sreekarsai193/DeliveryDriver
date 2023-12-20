using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField] float packageDelay = 0.1f;

    [SerializeField] Color32 hasPackageColor = new Color(1,1,1,1);

    [SerializeField] Color32 noPackageColor = new Color(0,0,0,0);

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sorry");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("package picked up");
            Destroy(other.gameObject,packageDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if(other.tag=="Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
