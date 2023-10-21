using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotSpeed = 10f;

    Rigidbody2D rb;
    float normalizedSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical"); 
        normalizedSpeed = verticalInput * _speed;

        Debug.Log(horizontalInput + " " + verticalInput);
        rb.MovePosition(gameObject.transform.position + gameObject.transform.up * normalizedSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation - horizontalInput * _rotSpeed * Time.fixedDeltaTime);
    }
}