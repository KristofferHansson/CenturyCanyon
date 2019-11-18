using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] protected GameObject waterBox;
    [SerializeField] protected GameObject pastAndFuture;
    [SerializeField] protected GameObject futureOnly;
    [SerializeField] protected GameObject player1Prefab;
    [SerializeField] protected GameObject player2Prefab;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected UIMiddleman ui = null;

    protected GameObject p1;
    protected GameObject p2;
    protected float offset;
    protected bool player1InLadder = false;
    protected bool player2InLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        if (ui is null || ui == null)
            ui = GameObject.Find("UIMaster").GetComponent<UIMiddleman>();

        offset = waterBox.GetComponent<Renderer>().bounds.extents.magnitude * 2 + 100;

        GameObject p2Map = Instantiate(pastAndFuture, pastAndFuture.transform.position + new Vector3(offset, 0.0f, 0.0f), Quaternion.identity);

        futureOnly.transform.position += new Vector3(offset, 0.0f, 0.0f);

        p1 = Instantiate(player1Prefab);
        p1.transform.position = spawnPoint.position;

        p2 = Instantiate(player2Prefab);
        p2.transform.position = spawnPoint.position + new Vector3(offset, 0.0f, 0.0f);
    }

    public float GetOffset()
    {
        return offset;
    }

    // When one of the players dies
    public void ReportFailure()
    {
        print(player1InLadder);
        print(player2InLadder);
        ui.ShowEndGamePanel();

        if (!(p1 is null))
        {
            p1.GetComponent<PlayerController1>().Die();
            p1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            p1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            p1.GetComponent<Rigidbody>().useGravity = false;
            p1 = null;
        }

        if (!(p2 is null))
        {
            p2.GetComponent<PlayerController2>().Die();
            p2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            p2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            p2.GetComponent<Rigidbody>().useGravity = false;
            p2 = null;
        }
    }

    // Player enters end-level trigger
    public void PlayerIn(bool player1)
    {
        if (player1)
            player1InLadder = true;
        else
            player2InLadder = true;

        if (player1InLadder && player2InLadder)
        {
            LevelComplete();
        }
    }

    // Player exits end-level trigger
    public void PlayerOut(bool player1)
    {
        if (player1)
            player1InLadder = false;
        else
            player2InLadder = false;
    }

    public void LevelComplete()
    {
        ui.ShowLevelCompletePanel();
    }
}
