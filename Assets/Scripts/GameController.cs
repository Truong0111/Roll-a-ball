using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public Coin coin;
    public Bomb bomb;
    public Player player;
    public float spawnTimeCoin;
    public float spawnTimeBomb;
    float m_spawnTimeCoin;
    float m_spawnTimeBomb;
    int m_score;
    bool m_isGameOver;
    GameUIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTimeCoin = 0;
        m_spawnTimeBomb = 10f;
        m_ui = FindObjectOfType<GameUIManager>();
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.SetLastScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTimeCoin = 0;
            m_spawnTimeBomb = 0;
            m_ui.showGameOverPanel(true);
            return;
        }
        m_spawnTimeCoin -= Time.deltaTime;
        m_spawnTimeBomb -= Time.deltaTime;
        if (m_spawnTimeCoin <= 0)
        {
            Debug.Log("Spawn coin");
            SpawnCoin();
            m_spawnTimeCoin = spawnTimeCoin;
        }
        if(m_spawnTimeBomb <= 0)
        {
            Debug.Log("Spawn Bomb");
            SpawnBomb();
            m_spawnTimeBomb = spawnTimeBomb;
        }
    }

    public void SpawnCoin()
    {
        float randXPos = Random.Range(-8f,8f);
        float randZPos = Random.Range(-8f,8f);
        Vector3 spawnPos = new Vector3(randXPos,0.5f,randZPos);
        if (spawnPos == player.transform.position)
        {
            SpawnCoin();
        }
        if (coin)
        {
            Instantiate(coin,spawnPos,Quaternion.identity);
        }
    }

    public void SpawnBomb()
    {
        float randXPos = Random.Range(-8f, 8f);
        float randZPos = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(randXPos, 0.4f, randZPos);
        if(spawnPos == player.transform.position)
        {
            SpawnBomb();
        }
        if (bomb)
        {
            Instantiate(bomb, spawnPos, Quaternion.identity);
        }
    }

    public void setScore(int score)
    {
        m_score = score;
    }

    public int getScore()
    {
        return m_score;
    }

    public void ScoreIncreament()
    {
        if (m_isGameOver)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.SetLastScoreText("Score: " + m_score);
    }

    public void setIsGameOver(bool isGameOver)
    {
        m_isGameOver = isGameOver;
    }

    public bool getIsGameOver()
    {
        return m_isGameOver;
    }

    public void Replay()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        Debug.Log("BackMenu");
        SceneManager.LoadScene("MenuScene");
    }
}
