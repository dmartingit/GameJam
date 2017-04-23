using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class LadderRemovalBlock : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var player = col.gameObject.GetComponent<PlayerController>();
                player.m_isClimbing = false;
            }
        }
    }
}