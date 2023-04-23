using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player : MonoBehaviour
{
    Rigidbody m_rb;
    public GameController m_gc;
    public float speed = 10f;
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
        else
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
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bomb"))
        {
            col.gameObject.SetActive(false);
            if (aus && loseSound && !m_gc.getIsGameOver())
            {
                Debug.Log("Phat am thua cuoc");
                aus.PlayOneShot(loseSound);
            }
            Destroy(gameObject);
            m_gc.setIsGameOver(true);
        }
        if (col.gameObject.CompareTag("Coin"))
        {
            col.gameObject.SetActive(false);
            if (aus && eatCoinSound)
            {
                Debug.Log("Phat am an coin");
                aus.PlayOneShot(eatCoinSound);
            }
            Debug.Log("An 1 coin");
        }
    }


}
