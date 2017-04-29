﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class FireElement : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var player = col.gameObject.GetComponent<PlayerController>();
                player.m_state = PlayerController.state.fire;
                player.GetComponent<SpriteRenderer>().color = Color.red;
                Destroy(gameObject);
            }
        }
    }
}