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
            PerformClimb();
            PerformMove();
            PerformJump();
        }

        void FixedUpdate()
        {
            DetectGround();
            CheckSlope();
        }

        void OnDrawGizmos()
        {
            // Draw the ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin,
                            groundRay.origin + groundRay.direction * rayDistance);
            // Draw direction line
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position - right * 1f,
                            transform.position + right * 1f);
        }
        #endregion

        #region Custom Functions
        public void Jump()
        {
            isJumping = true;
        }

        public void Crouch()
        {

        }

        public void UnCrouch()
        {

        }

        public void Move(float horizontal)
        {
            // If there is horizontal input
            if(horizontal != 0)
            {
                // Flip the sprite in the correct direction
                rend.flipX = horizontal < 0;
            }
            // Store the input for later
            inputH = horizontal;
        }

        public void Climb(float vertical)
        {

        }

        public void Hurt(int damage)
        {

        }

        private void PerformClimb()
        {

        }

        private void PerformMove()
        {
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            // Add force in direction using horizontal input
            rigid.AddForce(right * inputH * speed);
            // Limit the velocity to max velocity
            LimitVelocity();
        }

        private void PerformJump()
        {
            // Are we jumping?
            if (isJumping)
            {
                // Are we allowed to jump?
                if(currentJump < maxJumpCount)
                {
                    // Increment jump by 1
                    currentJump++;
                    rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                // Jump is finished!
                isJumping = false;
            }
        }

        private void DetectGround()
        {
            // Create a ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            // Shoot ray below the player and get all the hits
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin,
                                                       groundRay.direction,
                                                       rayDistance);
            // Loop through all the hits
            foreach (var hit in hits)
            {
                // Check if we hit an enemy
                CheckEnemy(hit);
                // Check if we hit the ground
                CheckGround(hit);
                if (CheckGround(hit))
                {
                    // Exit the loop
                    break;
                }
            }
        }

        private void CheckSlope()
        {
            if(isOnSlope)
            {
                rigid.drag = 5f;
            }
            else
            {
                rigid.drag = 0f;
            }
        }

        private bool CheckGround(RaycastHit2D hit)
        {
            if (hit.collider != null &&             // Exisit AND
                hit.collider.name != name &&        // is not the player AND
                hit.collider.isTrigger == false)    // is not a trigger
            {
                // Reset the jump
                currentJump = 0;
                // Player is in the grounded state
                isGrounded = true;
                // Update the ground normal
                groundNormal = hit.normal;

                // Check for slopes
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                if(Mathf.Abs(slopeAngle) > 0 &&
                   Mathf.Abs(slopeAngle) < maxSlopeangle)

                if (slopeAngle >= maxSlopeangle)
                    {
                        rigid.AddForce(Physics2D.gravity);
                    }
                 
                // Check if we entered a slope


                // Return true! (ground is found)
                return true;
            }
            // Return false! (ground is not found)
            return false;
        }

        private void CheckEnemy(RaycastHit2D hit)
        {

        }

        private void LimitVelocity()
        {
            // Cache rigid velocity into smaller variable
            Vector3 vel = rigid.velocity;
            // if vel length is greater than max Velocity
            if (vel.magnitude > maxVelocity)
            {
                // Cap the velocity to maxVelocity
                vel = vel.normalized * maxVelocity;
            }
            // Apply newly calculated vel to rigidbody
            rigid.velocity = vel;
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