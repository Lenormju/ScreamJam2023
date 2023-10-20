using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    Rigidbody2D rb;
    Vector3 normalizedSpeedVector;

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
        normalizedSpeedVector = new Vector3(horizontalInput, verticalInput, 0).normalized * _speed;
        rb.MovePosition(gameObject.transform.position + normalizedSpeedVector * Time.fixedDeltaTime);
    }
}