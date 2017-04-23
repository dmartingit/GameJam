using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class WaterElement : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var player = col.gameObject.GetComponent<PlayerController>();
                player.m_state = PlayerController.state.water;
                player.GetComponent<SpriteRenderer>().color = Color.cyan;
                Destroy(gameObject);
            }
        }
    }
}