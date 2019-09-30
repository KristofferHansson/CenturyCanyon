﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PColliderEnter2 : MonoBehaviour
{
    [SerializeField] private PlayerController2 pc;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.name.Equals("PCapsule2"))
            pc.ResetJump();
    }
}
