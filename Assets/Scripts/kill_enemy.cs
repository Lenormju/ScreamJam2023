using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_enemy : MonoBehaviour
{
    private Collider2D collider;
    private Animator anim ;

    public float battery_consumtion = 10;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
       collider = GetComponent<Collider2D>();
       collider.enabled = false ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {            
            anim.SetTrigger("flash");
            collider.enabled = true ;
        }
    }

    public void DisableHitbox(){
        GameManager.battery_level -= battery_consumtion;
        collider.enabled = false ;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            CatchMe en = col.GetComponent<CatchMe>();
            en.KillMe();
        }
    }

}
