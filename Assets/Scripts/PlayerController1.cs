using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private float move_Speed = 1.0f;

    private Rigidbody m_Rigidbody;
    private Vector3 move;
    private bool canJump = true;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0.0f, z = 0.0f;

        // Check for input // Convert to getaxes
        //if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        //    z += 1.0f;
        //else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        //    z += -1.0f;

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            x += -1.0f;
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            x += 1.0f;

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            // jump
            jump = true;
            canJump = false;
        }

        // Update movement vector
        move.x = x;
        move.z = z;
        move.Normalize();
        move = Quaternion.Euler(0f, -45f, 0f) * move;
        move *= move_Speed;
        //move.y = Physics.gravity.y * Time.deltaTime * 2.0f;
        if (move.y < -3.0f)
            move.y = -3.0f;
        else if (move.y > 3.0f)
            move.y = 3.0f;

        Move();
    }

    private void Move()
    {
        m_Rigidbody.velocity = new Vector3(move.x, m_Rigidbody.velocity.y, move.z);
        if (jump)
        {
            print("jumping");
            m_Rigidbody.AddForce(Vector3.up * 400.0f);
            jump = false;
        }
    }

    public void ResetJump()
    {
        canJump = true;
    }
}
