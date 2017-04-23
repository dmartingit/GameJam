using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam {
    public class PlayerController : MonoBehaviour {

        public float m_maxSpeed = 6f;
        public LayerMask m_grounds;
        public Transform m_groundCheck;

        private float m_velX;
        private float m_velY;
        private bool m_flipDirection = false;
        private bool m_canJump = false;

        private Animator m_animator;

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
            return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W);
        }

        private void Start()
        {
            m_animator = this.GetComponent<Animator>();
            GetComponent<Rigidbody2D>().freezeRotation = true;
        }

        private bool isGrounded()
        {
            if(Physics2D.OverlapCircle(m_groundCheck.transform.position, 0.15f, m_grounds) != null)
            {
                return true;
            }
            return false;
            
        }

        private void FixedUpdate()
        {
            m_velX = GetComponent<Rigidbody2D>().velocity.x;
            m_velY = GetComponent<Rigidbody2D>().velocity.y;
            
            if (isGrounded())
            {
                m_canJump = true;
            }
            else
            {
                m_canJump = false;
            }

            if (GetRigth())
            {
                m_animator.SetInteger("Transition",1);
                if(m_flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    m_flipDirection = !m_flipDirection;
                }
                //transform.Translate(velX, 0, 0);
                m_velX = 1 * m_maxSpeed;
            } else if( GetLeft())
            {
                m_animator.SetInteger("Transition", 1);
                if (!m_flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    m_flipDirection = !m_flipDirection;
                }
                //transform.Translate(-m_velX, 0, 0);
                m_velX = -1 * m_maxSpeed;
            }
            else
            {
                m_animator.SetInteger("Transition", 0);
                m_velX = 0;
            }

            if (GetUp() && m_canJump)
            {
                m_animator.SetInteger("Transition", 0);
                m_velY = 1 * m_maxSpeed;
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(m_velX, m_velY);
        }
    }
}