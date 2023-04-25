using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameController m_gc;
    float speed = 200f;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        transform.Rotate(90, 0, 0);
    }
    void Update()
    {
        transform.Rotate(0, 0, -speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            m_gc.ScoreIncreament();
            Destroy(gameObject);
        }        
    }
}
