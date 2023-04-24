using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameController m_gc;

    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
