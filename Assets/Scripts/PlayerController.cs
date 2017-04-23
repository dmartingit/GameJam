using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam {
    public class PlayerController : MonoBehaviour {

        public float m_maxSpeedX = 3f;
        public float m_maxSpeedY = 5f;
        public LayerMask m_grounds;
        public Transform m_groundCheck;

        public enum state {
            none, air, water, fire, earth
        };

        public state m_state = state.none;
        public bool m_isClimbing = false;

        private float m_velX;
        private float m_velY;
        private bool m_flipDirection = false;
        private bool m_canJump = false;
        private bool m_canDoubleJump = false;

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


        public bool GetUpKeyPress()
        {
            return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        }

        public bool GetDown()
        {
            return Input.GetKey(KeyCode.S);
        }

        private void Start()
        {
            m_animator = this.GetComponent<Animator>();
            GetComponent<Rigidbody2D>().freezeRotation = true;
        }

        public void die()
        {
            transform.position = GameObject.Find("Spawn").transform.position;
            m_state = state.none;
        }

        private bool isGrounded()
        {
            return Physics2D.OverlapCircle(m_groundCheck.transform.position, 0.15f, m_grounds);
        }

        private void FixedUpdate()
        {
            m_velX = GetComponent<Rigidbody2D>().velocity.x;
            m_velY = GetComponent<Rigidbody2D>().velocity.y;
            GetComponent<Rigidbody2D>().gravityScale = 1;

            if (!m_canJump && (m_velY > 0))
            {
                m_animator.SetInteger("Transition", 2);
            }

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
                m_velX = 1 * m_maxSpeedX;
            } else if( GetLeft())
            {
                m_animator.SetInteger("Transition", 1);
                if (!m_flipDirection)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    m_flipDirection = !m_flipDirection;
                }
                //transform.Translate(-m_velX, 0, 0);
                m_velX = -1 * m_maxSpeedX;
            }
            else if(m_canJump)
            {
                m_animator.SetInteger("Transition", 0);
                m_velX = 0;
            }

            if (GetUp() && (m_canDoubleJump && (m_state == state.air)))
            {
                m_animator.SetInteger("Transition", 2);
                m_velY = 1 * m_maxSpeedY;
                m_canDoubleJump = false;
            }

            if (GetUp() && m_canJump && !m_isClimbing)
            {
                m_animator.SetInteger("Transition", 0);
                m_velY = 1 * m_maxSpeedY;
                m_canDoubleJump = true;
            }
            
            if (m_isClimbing)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                if(GetUpKeyPress())
                {
                    transform.Translate(0, 0.02f, 0);
                } else if(GetDown())
                {
                    transform.Translate(0, -0.02f, 0);
                }
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(m_velX, m_velY);
        }
    }
}