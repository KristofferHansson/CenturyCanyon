using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : PlayerController
{
    [SerializeField] private float move_Speed = 1.0f;
    [SerializeField] private GameObject shortTreePrefab;
    [SerializeField] private GameObject vinePrefab;

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
}
