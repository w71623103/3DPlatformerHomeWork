using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float xMove;
    [SerializeField] private float yDirChange;
    [SerializeField] private float yLook;
    [SerializeField] private float lookDirSpeed = 0.5f;
    [SerializeField] private float xSpeed;
    private Rigidbody playerRB;
    [SerializeField]private bool isGrounded = false;
    [SerializeField] float jumpSpeed = 1f;
    /*private BoxCollider push;*/

    [SerializeField] public bool freeze = false;
    [SerializeField] private float freezeTimer = 0f;
    [SerializeField] private float freezeMax = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
/*        push = transform.Find("push").GetComponent<BoxCollider>();
*/    }

    // Update is called once per frame
    void Update()
    {
        yLook += yDirChange;
        if (yDirChange != 0f) changeDir(yLook * lookDirSpeed);

        if (!freeze) playerRB.velocity = new Vector3(xMove * Mathf.Cos(Mathf.Deg2Rad * yLook * lookDirSpeed), playerRB.velocity.y, -xMove * Mathf.Sin(Mathf.Deg2Rad * yLook * lookDirSpeed));

        if (freeze)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer > freezeMax)
            {
                freezeTimer = 0f;
                freeze = false;
            }
        }
    }

    void OnMove(InputValue input)
    {
        xMove = input.Get<Vector2>().y * xSpeed;
        yDirChange = input.Get<Vector2>().x;
        
    }

    void OnJump()
    {
        if (isGrounded)
            playerRB.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }

    /*void OnPush()
    {
        push.enabled = true;
    }*/

    void changeDir(float degree)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + degree, transform.rotation.z), 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
