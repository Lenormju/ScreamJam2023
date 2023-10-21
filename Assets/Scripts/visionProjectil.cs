using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionProjectil : MonoBehaviour
{
    public float speed = 5f;
    
    private float lifeTime = 0.5f; 
    public Vector3 vectorDir;

    void Start()
    {
        // Utilisez la fonction Destroy avec un délai pour détruire l'objet après 0,5 seconde
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacez le projectile vers l'avant
        transform.Translate(vectorDir * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }

    }
}
