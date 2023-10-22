using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMe : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coucou! Tu veux voir ma ...");
            GameManager.battery_level -= 50;
            anim.SetTrigger("ChtaiChopay");
        }
    }

    public void DestroyEnemy(){
        Destroy(gameObject);
    }
}
