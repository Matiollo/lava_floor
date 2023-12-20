using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Transform camera;
    
    public float speed = 6f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    Vector3 velocity;

    public GameObject targetObject; 
    public Canvas canvas; 
    public Image image; 
    public bool canMove;

    public AudioSource jumpSoundEffect;
    public AudioSource deathSoundEffect;
    private bool deathSoundEffectPlayed = false;

    void Start()
    {
        image.gameObject.SetActive(false);
        canMove = true;
    }


    void Update()
    {
        if (canMove)
        {
            MovePlayer(); 
        }
        

        List<Collider> colliders = new List<Collider>(Physics.OverlapSphere(transform.position, 0.01f));

        if (colliders.Contains(targetObject.GetComponent<Collider>()))
        {
            image.gameObject.SetActive(true);
            canMove = false;

            if (!deathSoundEffectPlayed)
            {
                deathSoundEffect.Play();
                deathSoundEffectPlayed = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Babysitter"))
        {
            image.gameObject.SetActive(true);
            canMove = false;

            if (!deathSoundEffectPlayed)
            {
                deathSoundEffect.Play();
                deathSoundEffectPlayed = true;
            }
        }
    }


    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");  

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (characterController.isGrounded)
        {
            velocity.y = 0;

            if (Input.GetButton("Jump"))
            {
                velocity.y = jumpSpeed;
                jumpSoundEffect.Play();
            }
        }

        velocity.y -= gravity * Time.deltaTime;
        
        characterController.Move(velocity * Time.deltaTime);
    }

    
}
