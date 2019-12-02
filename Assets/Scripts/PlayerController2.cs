using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : PlayerController
{
    [SerializeField] private float move_Speed = 1.0f;
    [SerializeField] private GameObject thrustBlock;
    [SerializeField] private GameObject blackHole;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform skelTransform;

    private bool lastRight = false;

    // Update is called once per frame
    void Update()
    {
        /// Movement
        float x = 0.0f, z = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            x += -1.0f;
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            x += 1.0f;

        if (x != 0)
        {
            if (x < 0)
            {
                // anim left
                anim.SetBool("walking", true);
                skelTransform.rotation = Quaternion.Euler(0, 270f, 0);
		        lastRight = false;
            }
            else if (x > 0)
            {
                // anim right
                anim.SetBool("walking", true);
                skelTransform.rotation = Quaternion.Euler(0, 90f, 0);
		        lastRight = true;
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (canJump && Input.GetKeyDown(KeyCode.RightControl))
        {
            // jump
            jump = true;
            canJump = false;
            anim.SetBool("jumping", true);
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
        if (Input.GetKeyDown(KeyCode.Keypad0)) // thrust block
        {
            GameObject t = null;

            if (ResourceManagerFuture.Instance.GetEnergy() > 0)
            {
                ResourceManagerFuture.Instance.Use();
                t = Instantiate(thrustBlock);
                if (lastRight)
                    t.GetComponent<ThrustBlockMaster>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(-lvl.GetOffset(), 0f, 0f));
                else
                    t.GetComponent<ThrustBlockMaster>().Spawn(this.transform.position + new Vector3(-1.5f, -0.5f, 0f), new Vector3(-lvl.GetOffset(), 0f, 0f));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1)) // black hole
        {
            GameObject t = null;

            if (ResourceManagerFuture.Instance.GetEnergy() > 0)
            {
                ResourceManagerFuture.Instance.Use();
                t = Instantiate(blackHole);
                if (lastRight)
                    t.GetComponent<ThrustBlockMaster>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(-lvl.GetOffset(), 0f, 0f));
                else
                    t.GetComponent<ThrustBlockMaster>().Spawn(this.transform.position + new Vector3(-1.5f, -0.5f, 0f), new Vector3(-lvl.GetOffset(), 0f, 0f));
            }
        }
    }

    public override void ResetJump()
    {
        anim.SetBool("jumping", false);
        canJump = true;
    }
}
