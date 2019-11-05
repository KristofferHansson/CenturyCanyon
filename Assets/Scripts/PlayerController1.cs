using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : PlayerController
{
    [SerializeField] private float move_Speed = 1.0f;
    [SerializeField] private GameObject shortTreePrefab;
    [SerializeField] private GameObject vinePrefab;
    [SerializeField] private GameObject bbushPrefab;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform skelTransform;

    // Update is called once per frame
    void Update()
    {
        /// Movement
        float x = 0.0f, z = 0.0f;
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            x += -1.0f;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            x += 1.0f;
        }

        if (x != 0)
        {
            if (x < 0)
            {
                // anim left
                anim.SetBool("walking", true);
                skelTransform.rotation = Quaternion.Euler(0, 270f, 0);
            }
            else if (x > 0)
            {
                // anim right
                anim.SetBool("walking", true);
                skelTransform.rotation = Quaternion.Euler(0, 90f, 0);
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            // jump
            jump = true;
            anim.SetBool("jumping", true);
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
            else if (Input.GetKeyDown(KeyCode.R)) // vine
            {
                GameObject t = Instantiate(bbushPrefab);
                t.GetComponent<ShortTree>().Spawn(this.transform.position + new Vector3(1.5f, -0.5f, 0f), new Vector3(lvl.GetOffset(), 0f, 0f));
            }
        }
    }

    public override void ResetJump()
    {
        anim.SetBool("jumping", false);
        canJump = true;
    }
}
