using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam {
    public class PlayerController : MonoBehaviour {

        private float velocityX = 0.05f;
        private float velocityY = 0.05f;
        private bool flipDirection = false;

        private Animator animator;

        public bool GetRigth()
        {
            return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        }

        public bool GetLeft()
        {
            return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        }

        public bool GetUp()
        {
            return Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W);
        }

        private void Start()
        {
            animator = this.GetComponent<Animator>();
        }

        private void Update()
        {
            if (GetRigth())
            {
                animator.SetInteger("Transition",1);
                if(flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    flipDirection = !flipDirection;
                }
                transform.Translate(velocityX, 0, 0);
            } else if( GetLeft())
            {
                animator.SetInteger("Transition", 1);
                if (!flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    flipDirection = !flipDirection;
                }
                transform.Translate(-velocityX, 0, 0);
            }
            else
            {
                animator.SetInteger("Transition", 0);
            }
        }
    }
}