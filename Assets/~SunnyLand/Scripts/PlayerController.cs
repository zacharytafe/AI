using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f; //Move speed
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4; //Amount of damage cuased by player to enemies
        public float damageForce = 4f; //Amount of damage taken by the player
        public float maxVelocity = 3f;
        public float maxSlopeangle = 45f;
        [Header("Grounding")]
        public float rayDistance = .5f;
        public bool isGrounded = false;
        [Header("crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        [Header("Climb")]
        public float climbSpeed = 5f;
        public bool isClimbing = false;
        public bool isOnSlope = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;
        // References
        private SpriteRenderer rend;
        private Rigidbody2D rigid;

        #region Unity Functions
        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Functions
        public void Jump()
        {

        }

        public void Crouch()
        {

        }

        public void UnCrouch()
        {

        }

        public void Move(float horizontal)
        {

        }

        public void Climb(float vertical)
        {

        }

        public void Hurt(int damage)
        {

        }

        private void DetectGround()
        {

        }

        private void CheckGround(RaycastHit2D hit)
        {

        }

        private void LimitVelocity()
        {

        }

        private void StopClimbing()
        {

        }

        private void DisablePhysics()
        {

        }

        private void EnablePhysics()
        {

        }


        #endregion
    }
}