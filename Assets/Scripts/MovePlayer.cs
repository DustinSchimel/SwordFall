using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 20f;
    public float spikeKnockback = 20f;
    public float maxFallSpeed;
    private Animator animator;

    private Rigidbody rb;
    private Collider playerCollider;
    private Vector3 movement;
    public GameObject swordHitbox;
    public float swordActiveTime;

    private bool leftMovement = true;
    private bool rightMovement = true;
    private bool swingCd;
    public float swingCooldownTime;
    public float damageTime;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        swingCd = true;
        swordHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
        Vector3 vel = rb.velocity;
        if(vel.y < -maxFallSpeed)
        {
            vel.y = -maxFallSpeed;
            rb.velocity = vel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Left Wall"))
        {
            leftMovement = false;
        }
        else if (other.tag.Equals("Right Wall"))
        {
            rightMovement = false;
        }

        if (other.CompareTag("Spikes") || other.CompareTag("Corn")
            || other.CompareTag("Mushroom") || other.CompareTag("BounceMushroom"))
        {
            Debug.Log("Hit Spikes");
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * spikeKnockback);
            animator.SetTrigger("isJumping");
            StartCoroutine(TakeDamage());
        }
        else if (other.CompareTag("TreeBranch"))
        {
            //Destroy the tree branch and take damage
        }
        else if (other.CompareTag("LeafPile"))
        {
            //Destory the leaf pile, cause the attached platforms to swing down towards the walls,
            // and take damage
        }
        else if (other.CompareTag("Pumpkin") || other.CompareTag("CornKernel"))
        {
            //Destroy the projectile and take damage
        }
        else if (other.CompareTag("SpiderWeb"))
        {
            //"Blur warp" a large way upwards and deduct from the score, and delete all existing
            // platforms and enemies
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("SwordDownHitbox"))
        {
            Physics.IgnoreCollision(playerCollider, collision.collider);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Left Wall"))
        {
            leftMovement = true;
        }
        else if (other.tag.Equals("Right Wall"))
        {
            rightMovement = true;
        }
    }

    void moveCharacter(Vector3 direction)
    {
        if ((Input.GetAxis("Horizontal") > 0) && rightMovement)    // Right
        {
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
        if ((Input.GetAxis("Horizontal") < 0) && leftMovement)    // Left
        {
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
        if ((Input.GetAxis("Vertical") < 0) && swingCd)    // Down
        {
            animator.SetTrigger("isSwinging");
            StartCoroutine(ActivateSwordHitbox());
            StartCoroutine(SwingCooldown());
        }
    }

    private IEnumerator ActivateSwordHitbox()
    {
        swordHitbox.SetActive(true);
        yield return new WaitForSeconds(swordActiveTime);
        swordHitbox.SetActive(false);
    }

    private IEnumerator SwingCooldown()
    {
        swingCd = false;
        yield return new WaitForSeconds(swingCooldownTime);
        swingCd = true;
    }
    private IEnumerator TakeDamage()
    {
        swordHitbox.SetActive(false);
        swingCd = false;
        yield return new WaitForSeconds(damageTime);
        swingCd = true;
    }
}
