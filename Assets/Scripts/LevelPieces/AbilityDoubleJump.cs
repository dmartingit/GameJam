using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunAndJump {

	public class AbilityDoubleJump : MonoBehaviour {

		public delegate void StartInteractionDelegate();
		public static event StartInteractionDelegate StartInteractionEvent;
		private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerController player = col.gameObject.GetComponent<PlayerController>();
                // Set big jump true
                player.setDoubljump(true);

                Destroy(gameObject);
            }
        }
	}
}
