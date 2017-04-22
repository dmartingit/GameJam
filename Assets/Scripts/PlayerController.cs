using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam {
    public class PlayerController : MonoBehaviour
    {

        private float velocityX = 0.05f;
        private float velocityY = 0.05f;
        private bool m_grounded = true;
        private Collider2D m_collider;
        private bool flipDirection = false;

        public LayerMask WhatIsGround;
        private Transform GroundCheck;
        private Animator animator;

        private const float GROUND_CHECK_RADIUS = 0.01f;


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
                animator.SetInteger("Transition", 1);
                if (flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    flipDirection = !flipDirection;
                }
                transform.Translate(velocityX, 0, 0);
            }
            else if (GetLeft())
            {
                animator.SetInteger("Transition", 1);
                if (!flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    flipDirection = !flipDirection;
                }
                transform.Translate(-velocityX, 0, 0);
            }
            else if (GetUp())
            {
                animator.SetInteger("Transition", 1);
                transform.Translate(0, velocityX, 0);

            }
            else
            {
                animator.SetInteger("Transition", 0);
            }
        }
        private bool isGroundet()
        {
            m_collider = Physics2D.OverlapCircle(GroundCheck.position, GROUND_CHECK_RADIUS, WhatIsGround);
            if (m_collider != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}