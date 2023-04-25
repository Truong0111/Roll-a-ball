using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public Coin coin;
    public Bomb bomb;
    public Bungee bungee;
    public Player player;
    public float spawnTimeCoin;
    public float spawnTimeBomb;
    public float spawnTimeBungee;
    float countCoin = 12f;
    float countBungee = 11f;
    List<Vector3> coinPos;
    List<Vector3> bombPos;
    List<Vector3> bungeePos;
    float m_spawnTimeCoin;
    float m_spawnTimeBomb;
    float m_spawnTimeBungee;
    int m_score;
    bool m_isGameOver;
    GameUIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTimeCoin = 0;
        m_spawnTimeBomb = 10f;
        m_spawnTimeBungee = 15f;
        coinPos = new List<Vector3>();
        bombPos = new List<Vector3>();
        bungeePos = new List<Vector3>();
        m_ui = FindObjectOfType<GameUIManager>();
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.SetLastScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (m_isGameOver)
        {
            m_spawnTimeCoin = 0;
            m_spawnTimeBomb = 0;
            m_spawnTimeBungee = 0;
            m_ui.showGameOverPanel(true);
            return;
        }
        m_spawnTimeCoin -= Time.deltaTime;
        m_spawnTimeBomb -= Time.deltaTime;
        m_spawnTimeBungee -= Time.deltaTime;
        if (m_spawnTimeCoin <= 0)
        {
            SpawnCoin();
            m_spawnTimeCoin = spawnTimeCoin;
        }
        if(m_spawnTimeBomb <= 0)
        {
            SpawnBomb();
            m_spawnTimeBomb = spawnTimeBomb;
        }
        if(m_spawnTimeBungee <= 0)
        {
            SpawnBungee();
            m_spawnTimeBungee = spawnTimeBungee;
        }
    }
    
    public void SpawnCoin()
    {
        float randXPos = Random.Range(-8.5f,8.5f);
        float randZPos = Random.Range(-8.5f,8.5f);
        Vector3 spawnPos = new Vector3(randXPos,0.5f,randZPos);
        if (checkSpawn(spawnPos,coinPos) || checkSpawn(spawnPos,bombPos))
        {
            return;
        }
        if(coin && countCoin != 0)
        {
            Instantiate(coin,spawnPos,Quaternion.identity);
            coinPos.Add(spawnPos);
            countCoin--;
        }
    }

    public void SpawnBomb()
    {
        float randXPos = Random.Range(-8.5f, 8.5f);
        float randZPos = Random.Range(-8.5f, 8.5f);
        Vector3 spawnPos = new Vector3(randXPos, 0.4f, randZPos);
        if(checkSpawn(spawnPos,bombPos) || checkSpawn(spawnPos, coinPos)
            || checkSpawn(spawnPos,bungeePos)) 
        {
            return;
        }
        if(bomb)
        {
            Instantiate(bomb, spawnPos, Quaternion.identity);
            bombPos.Add(spawnPos);
        }
    }

    public void SpawnBungee()
    {
        float randXPos = Random.Range(-6f, 6f);
        float randZPos = Random.Range(-6f, 6f);
        Vector3 spawnPos = new Vector3(randXPos, 0.01f, randZPos);
        if(checkSpawn(spawnPos,bungeePos) || checkSpawn(spawnPos, bombPos))
        {
            return;
        }
        if(bungee && countBungee != 0)
        {
            Instantiate(bungee,spawnPos, Quaternion.identity);
            bungeePos.Add(spawnPos);
            countBungee--;
        }
    }
    bool checkSpawn(Vector3 spawnPos, List<Vector3> checkSpawnList)
    {
        if (checkSpawnList.Count != 0)
        {
            foreach (Vector3 check in checkSpawnList)
            {
                Vector3 tmp = spawnPos - check;
                if (tmp.sqrMagnitude >= 0 && tmp.sqrMagnitude <= 2.25f || checkPlayerPos(spawnPos)) return true;
            }
        }
        return false;
    }
    bool checkPlayerPos(Vector3 spawnPos)
    {
        Vector3 tmp = spawnPos - player.transform.position;
        if (tmp.sqrMagnitude >= 0 && tmp.sqrMagnitude <= 2.25f) return true;
        return false;
    }
    public void removeCoinPos(Vector3 spawnPos)
    {
        coinPos.Remove(spawnPos);
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
        countCoin++;
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Pause()
    {
        Time.timeScale = 0;
        m_ui.showGamePausePanel(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        m_ui.showGamePausePanel(false);
    }
}
