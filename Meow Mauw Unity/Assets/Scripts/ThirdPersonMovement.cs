using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF{
public class ThirdPersonMovement : MonoBehaviour
{

		//Events;
		public delegate void VectorEvent(Vector3 v);
		public VectorEvent OnJump;
		public VectorEvent OnLand;


        private Mover mover;
        float currentVerticalSpeed = 0f;
        bool isGrounded;
        public float movementSpeed = 7f;
        public float jumpSpeed = 10f;
        public float gravity = 10f;


		Vector3 lastVelocity = Vector3.zero;

		public Transform cameraTransform;
        CharacterInput characterInput;
        Transform tr;

        // Use this for initialization
        void Start()
        {
            tr = transform;
            mover = GetComponent<Mover>();
            characterInput = GetComponent<CharacterInput>();
        }

        void FixedUpdate()
        {
            //Run initial mover ground check;
            mover.CheckForGround();

            //If character was not grounded int the last frame and is now grounded, call 'OnGroundContactRegained' function;
            if(isGrounded == false && mover.IsGrounded() == true)
                OnGroundContactRegained(lastVelocity);

            //Check whether the character is grounded and store result;
            isGrounded = mover.IsGrounded();

            Vector3 _velocity = Vector3.zero;

            //Add player movement to velocity;
            _velocity += CalculateMovementDirection() * movementSpeed;
            
            //Handle gravity;
            if (!isGrounded)
            {
                currentVerticalSpeed -= gravity * Time.deltaTime;
            }
            else
            {
                if (currentVerticalSpeed <= 0f)
                    currentVerticalSpeed = 0f;
            }

            //Handle jumping;
            if ((characterInput != null) && isGrounded && characterInput.IsJumpKeyPressed())
            {
                OnJumpStart();
                currentVerticalSpeed = jumpSpeed;
                isGrounded = false;
            }


            //Add vertical velocity;
            _velocity += tr.up * currentVerticalSpeed;

			//Save current velocity for next frame;
			lastVelocity = _velocity;

            mover.SetExtendSensorRange(isGrounded);
            mover.SetVelocity(_velocity);
        }

        private Vector3 CalculateMovementDirection()
        {
            //If no character input script is attached to this object, return no input;
			if(characterInput == null)
				return Vector3.zero;

			Vector3 _direction = Vector3.zero;

			//If no camera transform has been assigned, use the character's transform axes to calculate the movement direction;
			if(cameraTransform == null)
			{
				_direction += tr.right * characterInput.GetHorizontalMovementInput();
				_direction += tr.forward * characterInput.GetVerticalMovementInput();
			}
			else
			{
				//If a camera transform has been assigned, use the assigned transform's axes for movement direction;
				//Project movement direction so movement stays parallel to the ground;
				_direction += Vector3.ProjectOnPlane(cameraTransform.right, tr.up).normalized * characterInput.GetHorizontalMovementInput();
				_direction += Vector3.ProjectOnPlane(cameraTransform.forward, tr.up).normalized * characterInput.GetVerticalMovementInput();
			}

			//If necessary, clamp movement vector to magnitude of 1f;
			if(_direction.magnitude > 1f)
				_direction.Normalize();

			return _direction;
        }

        //This function is called when the controller has landed on a surface after being in the air;
		void OnGroundContactRegained(Vector3 _collisionVelocity)
		{
			//Call 'OnLand' delegate function;
			if(OnLand != null)
				OnLand(_collisionVelocity);
		}

        //This function is called when the controller has started a jump;
        void OnJumpStart()
        {
            //Call 'OnJump' delegate function;
            if(OnJump != null)
                OnJump(lastVelocity);
        }

        //Return the current velocity of the character;
        public Vector3 GetVelocity()
        {
            return lastVelocity;
        }

        //Return only the current movement velocity (without any vertical velocity);
        public  Vector3 GetMovementVelocity()
        {
            return lastVelocity;
        }

        //Return whether the character is currently grounded;
        public bool IsGrounded()
        {
            return isGrounded;
        }
}
}
//I take it back this wasted 7+ hours of my time

   /* //credit goes to Brackeys for this one never woulda figured this out
    //gets the character controller
    public CharacterController controller;
    //Transform = cam
    public Transform cam;

//Default move speed var
    public float speed =6f;
    //For smoothing  turns
    public float turnSmoothTIme = 0.1f;
    //Var for velocity of turning
    float turnSmoothVelovity;*/
      /*  //Gets the inputs for keyboard
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //Gets the direction using the inputs 
        Vector3 direction = new Vector3(horizontal, 0f,vertical).normalized;

        //if the direction is greater that 0.1 start the whole turning thing
        if (direction.magnitude>=0.1f){
            //The target angle is defined by the directions and the camera angle along the y axis
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg+cam.eulerAngles.y;
            //Angle used to be smooth and angle is read as target angle and ref turn smoothing 
            float angle =Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelovity,turnSmoothTIme);
            //Rotation and reads given values and the y from angle
            transform.rotation=Quaternion.Euler(0f,angle,0f);
            //New vector for deciding the move direction using target angle and reads that as forward direction
            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f)* Vector3.forward;
            //makes it move
            controller.Move(moveDir.normalized*speed*Time.deltaTime);
        }*/