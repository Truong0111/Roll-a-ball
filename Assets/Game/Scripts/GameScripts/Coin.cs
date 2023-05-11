using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameController m_gc;
    [SerializeField] private float speed = 200f;
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
