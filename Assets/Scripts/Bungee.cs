using UnityEngine;

public class Bungee : MonoBehaviour
{
    public GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
