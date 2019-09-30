using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private float move_Speed = 1.0f;
    [SerializeField] private GameObject thrustBlock;
    [SerializeField] private GameObject physicsBlock;
    private ILevelScript lvl;

    private Rigidbody m_Rigidbody;
    private Vector3 move;
    private bool canJump = true;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        if (lvl == null || lvl.Equals(default(ILevelScript)))
        {
            Component[] temp = GameObject.Find("LevelMaster").GetComponents(typeof(Component));
            foreach (Component c in temp)
            {
                if (c is ILevelScript)
                {
                    lvl = c as ILevelScript;
                    break;
                }
            }
        }
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

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            x += -1.0f;
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            x += 1.0f;

        if (canJump && Input.GetKeyDown(KeyCode.RightControl))
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


        /// Other actions
        if (Input.GetKeyDown(KeyCode.Keypad0)) // short tree
        {
            GameObject t = Instantiate(thrustBlock);
            t.GetComponent<ThrustBlockMaster>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(-lvl.GetOffset(), 0f, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1)) // vine
        {
            GameObject t = Instantiate(physicsBlock);
            //t.GetComponent<ShortTree>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(-lvl.GetOffset(), 0f, 0f));
        }
    }

    private void Move()
    {
        m_Rigidbody.velocity = new Vector3(move.x, m_Rigidbody.velocity.y, move.z);
        if (jump)
        {
            print("jumping");
            m_Rigidbody.AddForce(Vector3.up * 300.0f);
            jump = false;
        }
    }

    public void ResetJump()
    {
        canJump = true;
    }

    public void Die()
    {
        Destroy(this);
    }
}
