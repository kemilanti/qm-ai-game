using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;
    private float moveH, moveV;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal") * speed ;
        moveV = Input.GetAxis("Vertical") * speed ;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveH, moveV);
    }
}
