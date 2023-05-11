using UnityEngine;

public class Bungee : MonoBehaviour
{
    [SerializeField] private GameController m_gc;

    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
}
