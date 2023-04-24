using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_rb;
    public GameController m_gc;
    public float speed;
    bool isOnGround;
    public AudioSource aus;
    public AudioClip eatCoinSound;
    public AudioClip loseSound;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        if(Input.anyKey)
        {
            Movement();
        }
        else if(isOnGround)
        {
            m_rb.velocity /= 1.03f;
        }
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(-moveHorizontal,0.0f,-moveVertical);
        m_rb.AddForce(move * speed);
    }
    private void Jump()
    {
        m_rb.AddForce(Vector3.up * 400f);
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bomb"))
        {
            col.gameObject.SetActive(false);
            if (aus && loseSound && !m_gc.getIsGameOver())
            {
                aus.PlayOneShot(loseSound);
            }
            Destroy(gameObject);
            m_gc.setIsGameOver(true);
        }
        if (col.gameObject.CompareTag("Coin"))
        {
            col.gameObject.SetActive(false);
            m_gc.removeCoinPos(col.gameObject.transform.position);
            if (aus && eatCoinSound)
            {
                aus.PlayOneShot(eatCoinSound);
            }
        }
        if (col.gameObject.CompareTag("Bungee"))
        {
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
            speed = 5f;
        }
    }
}
