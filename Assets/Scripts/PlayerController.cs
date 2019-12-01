using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected LevelScript lvl;
    protected Rigidbody m_Rigidbody;
    protected Vector3 move;
    protected bool canJump = true;
    protected bool jump = false;

    private int vineCt = 0;
    private bool inVine = false; // in vine collision (can be true while !onVine or onVine)
    private bool onVine = false; // attached to vine
    private float lastReleasedVine = 0.0f;
    private VineSegmentTrigger vineSeg = null;

    private bool isUnderwater = false;

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

    protected void Move()
    {
        if (onVine)
        {
            m_Rigidbody.AddForce(move);
            if (jump)
            {
                // release player from vine
                vineSeg.ReleasePlayer();
                lastReleasedVine = Time.time;
                onVine = false;
                return;
            }
        }
        else
        {
            if (isUnderwater)
                move *= 0.3f;

            m_Rigidbody.velocity = new Vector3(move.x, m_Rigidbody.velocity.y, move.z);
            if (jump)
            {
                m_Rigidbody.AddForce(Vector3.up * 300.0f);
                jump = false;
                canJump = false;
            }
        }
    }

    public virtual void ResetJump()
    {
        canJump = true;
    }

    public void Die()
    {
        Destroy(this);
    }


    public void SetOnVine(VineSegmentTrigger vineSeg)
    {
        this.vineSeg = vineSeg;
        onVine = true;
        inVine = true;
        canJump = true;
    }

    public bool IsOnVine()
    {
        return onVine;
    }

    public bool IsInVine()
    {
        return (vineCt > 0);// && (Time.time - lastReleasedVine <= 0.1f));
    }

    public void VineEntered()
    {
        vineCt++;
    }

    public void VineExited()
    {
        vineCt--;
        if (vineCt < 1)
        {
            lastReleasedVine = Time.time;
            inVine = false;
        }
    }

    public void SetUnderwater(bool tf)
    {
        isUnderwater = tf;
    }
}
