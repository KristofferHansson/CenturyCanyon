using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private float move_Speed = 1.0f;
    [SerializeField] private GameObject shortTreePrefab;
    [SerializeField] private GameObject vinePrefab;
    private LevelScript lvl;

    private Rigidbody m_Rigidbody;
    private Vector3 move;
    private bool canJump = true;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        if (lvl == null || lvl.Equals(default(LevelScript)))
        {
            Component[] temp = GameObject.Find("LevelMaster").GetComponents(typeof(Component));
            foreach (Component c in temp)
            {
                if (c is LevelScript)
                {
                    lvl = c as LevelScript;
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /// Movement
        float x = 0.0f, z = 0.0f;
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            x += -1.0f;
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            x += 1.0f;
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            // jump
            jump = true;
        }
        // Update movement vector
        move.x = x;
        move.z = z;
        move.Normalize();
        move *= move_Speed;
        //move.y = Physics.gravity.y * Time.deltaTime * 2.0f;
        if (move.y < -3.0f)
            move.y = -3.0f;
        else if (move.y > 3.0f)
            move.y = 3.0f;

        Move();

        if (canJump)
        {
            /// Other actions
            if (Input.GetKeyDown(KeyCode.E)) // short tree
            {
                GameObject t = Instantiate(shortTreePrefab);
                t.GetComponent<ShortTree>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(lvl.GetOffset(), 0f, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.Q)) // vine
            {
                GameObject t = Instantiate(vinePrefab);
                t.GetComponent<ShortTree>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(lvl.GetOffset(), 0f, 0f));
            }
        }
    }

    private void Move()
    {
        m_Rigidbody.velocity = new Vector3(move.x, m_Rigidbody.velocity.y, move.z);
        if (jump)
        {
            m_Rigidbody.AddForce(Vector3.up * 300.0f);
            jump = false;
            canJump = false;
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
