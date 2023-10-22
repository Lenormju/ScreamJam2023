using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMe : MonoBehaviour
{
    private Animator anim;

    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool justeunefoisauchalet = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && justeunefoisauchalet == false)
        {
            justeunefoisauchalet = true;
            GameManager.battery_level -= 50;
            KillMe();
        }
    }

    public void KillMe()
    {
        anim.SetTrigger("ChtaiChopay");
    }

    public void DestroyEnemy(){
        Destroy(gameObject);
    }

    public void Explode()
    {
        explosion.SetActive(true);
    }
}
