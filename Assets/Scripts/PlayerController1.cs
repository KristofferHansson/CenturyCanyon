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

    private bool lastRight = false;

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
            float yOffset = -0.5f;
            GameObject t = null;
            if (Input.GetKeyDown(KeyCode.E)) // short tree
            {
                //t = Instantiate(shortTreePrefab);
                if (ResourceManagerPast.Instance.GetNumberOf("tree") > 0)
                {
                    t = Instantiate(shortTreePrefab);
                    ResourceManagerPast.Instance.Use("tree");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q)) // vine
            {
                if (ResourceManagerPast.Instance.GetNumberOf("vine") > 0)
                {
                    yOffset = -1f;
                    t = Instantiate(vinePrefab);
                    ResourceManagerPast.Instance.Use("vine");
                }
            }
            else if (Input.GetKeyDown(KeyCode.R)) // bbush
            {
                if (ResourceManagerPast.Instance.GetNumberOf("bush") > 0)
                {
                    t = Instantiate(bbushPrefab);
                    ResourceManagerPast.Instance.Use("bush");
                }
            }

            if (!(t is null))
            {
                if (lastRight)
                    t.GetComponent<ShortTree>().Spawn(this.transform.position + new Vector3(1.5f, yOffset, 0f), new Vector3(lvl.GetOffset(), 0f, 0f));
                else
                    t.GetComponent<ShortTree>().Spawn(this.transform.position + new Vector3(-1.5f, yOffset, 0f), new Vector3(lvl.GetOffset(), 0f, 0f), false);
            }
        }
    }

    public override void ResetJump()
    {
        anim.SetBool("jumping", false);
        canJump = true;
    }
}
