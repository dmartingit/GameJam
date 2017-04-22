using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam {
    public class PlayerController : MonoBehaviour {

        public float m_maxSpeed = 0.02f;

        private float m_velX;
        private float m_velY;
        private bool m_flipDirection = false;

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
            return Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W);
        }

        private void Start()
        {
            m_animator = this.GetComponent<Animator>();
        }

        private void Update()
        {
            m_velX = GetComponent<Rigidbody2D>().velocity.x;
            m_velY = GetComponent<Rigidbody2D>().velocity.y;
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
            } else
            {
                m_animator.SetInteger("Transition", 0);
                m_velX = 0;
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(m_velX, m_velY);
        }
    }
}