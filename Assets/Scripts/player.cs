using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotSpeed = 10f;

    public LayerMask targetRaycast;

    Rigidbody2D rb;
    float normalizedSpeed;

    private LineRenderer lineRenderer;
    public int nbRayCast = 120;
    private float angleInRadians;
    
    void Start()
    {
        angleInRadians = (2 * Mathf.PI) / nbRayCast;
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        rb.inertia = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        float curX = 1f;
        float curY = 0f;
        float maxRayDistance = 5f;

        Vector3 curVec = new (curX, curY, 0f);
        curVec = Vector3.Normalize(curVec);        

        for(int i=0 ; i < nbRayCast ; i++)
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, curVec, maxRayDistance, ~LayerMask.GetMask("DontReflect"));
            // Perform the raycast
            if (hit.collider != null)
            {
                  Debug.Log(hit.collider.name);

                  //hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                  hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                // Do something with the hit information
            }
            
            curX = curX * Mathf.Cos(angleInRadians) - curY * Mathf.Sin(angleInRadians);
            curY = curX * Mathf.Sin(angleInRadians) + curY * Mathf.Cos(angleInRadians);

            curVec = new (curX, curY, 0f);
            curVec = Vector3.Normalize(curVec);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical"); 
        normalizedSpeed = verticalInput * _speed;

        // Debug.Log(horizontalInput + " " + verticalInput);
        rb.MovePosition(gameObject.transform.position + gameObject.transform.up * normalizedSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation - horizontalInput * _rotSpeed * Time.fixedDeltaTime);
    }
}