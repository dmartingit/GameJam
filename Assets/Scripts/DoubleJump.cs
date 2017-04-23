using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{

    public class DoubleJump : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerController player = col.gameObject.GetComponent<PlayerController>();
                player.SetDoubleJump(true);
                Destroy(gameObject);
            }
        }

    }
}