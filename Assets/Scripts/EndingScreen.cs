using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class EndingScreen : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Application.LoadLevel("Levels/EndingScene");
            }
        }
    }
}