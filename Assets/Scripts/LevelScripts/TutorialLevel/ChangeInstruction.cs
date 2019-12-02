using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeInstruction : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private string newText;
    private bool changed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!changed && other.gameObject.name.Equals("P1Capsule") || other.gameObject.name.Equals("P2Capsule"))
        {
            text.text = newText;
            changed = true;
        }
    }
}
