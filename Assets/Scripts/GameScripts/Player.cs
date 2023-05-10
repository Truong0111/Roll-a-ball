using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public GameController gc;
    public float speed;
    bool isOnGround;
    public AudioSource aus;
    public AudioClip eatCoinSound;
    public AudioClip loseSound;
    public AudioClip jumpSound;
    public VirtualJoyStick moveJoyStick;
    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            Movement();
        }
        else if (isOnGround)
        {
            rb.velocity /= 1.03f;
        }
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(moveJoyStick.InputDirection != Vector3.zero)
        {
            rb.AddForce(-moveJoyStick.InputDirection * speed);
        }

        Vector3 move = new Vector3(-moveHorizontal,0.0f,-moveVertical);
        rb.AddForce(move * speed);
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * 400f);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bomb"))
        {
            col.gameObject.SetActive(false);
            if (aus && loseSound && !gc.getIsGameOver())
            {
                aus.PlayOneShot(loseSound);
            }
            Destroy(gameObject);
            gc.setIsGameOver(true);
        }
        if (col.gameObject.CompareTag("Coin"))
        {
            col.gameObject.SetActive(false);
            gc.removeCoinPos(col.gameObject.transform.position);
            if (aus && eatCoinSound)
            {
                aus.PlayOneShot(eatCoinSound);
            }
        }
        if (col.gameObject.CompareTag("Bungee"))
        {
            if(aus && jumpSound) 
            {
                aus.PlayOneShot(jumpSound);
            }
            Jump();
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            speed = 30f;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            speed = 0f;
        }
    }
}
