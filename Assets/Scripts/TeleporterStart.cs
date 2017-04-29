using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class TeleporterStart : MonoBehaviour
    {
        public int m_teleporterExitID = 0;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var player = col.gameObject.GetComponent<PlayerController>();
                var teleporterList = FindObjectsOfType<TeleporterExit>();
                foreach (var tp in teleporterList)
                {
                    if (tp.m_teleporterExitID == m_teleporterExitID)
                    {
                        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
                        player.transform.position = tp.transform.position;
                        return;
                    }
                }
            }
        }
    }
}
