using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField] private Bomb bomb;
    [SerializeField] private Bungee bungee;
    [SerializeField] private Player player;
    public float spawnTimeCoin;
    public float spawnTimeBomb;
    public float spawnTimeBungee;
    private float countCoin = 6f;
    private float countBungee = 11f;
    private List<Vector3> coinPos;
    private List<Vector3> bombPos;
    private List<Vector3> bungeePos;
    private float m_spawnTimeCoin;
    private float m_spawnTimeBomb;
    private float m_spawnTimeBungee;
    private int m_score;
    public int m_highScore;
    private bool m_isGameOver;
    [SerializeField] private GameUIManager m_ui;
    private void Start()
    {
        Application.targetFrameRate = 60;
        InitGame();
        InitUI();
        LoadHighScore();
    }
    private void InitGame()
    {
        m_spawnTimeCoin = 0;
        m_spawnTimeBomb = 10f;
        m_spawnTimeBungee = 15f;
        coinPos = new List<Vector3>();
        bombPos = new List<Vector3>();
        bungeePos = new List<Vector3>();
    }
    private void InitUI()
    {
        m_ui.SetScoreText( m_score);
        m_ui.SetLastScoreText(m_score);
        m_ui.SetHighScoreText(m_highScore);
    }
    private void Update()
    {
        CheckGamePause();
        CheckGameOver();
        SpawnObject();
        
    }
    private void CheckGamePause()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    private void CheckGameOver()
    {
        if (m_isGameOver)
        {
            m_spawnTimeCoin = 0;
            m_spawnTimeBomb = 0;
            m_spawnTimeBungee = 0;
            m_ui.showGameOverPanel(true);
            return;
        }
    }
    private void SpawnObject()
    {
        m_spawnTimeCoin -= Time.deltaTime;
        m_spawnTimeBomb -= Time.deltaTime;
        m_spawnTimeBungee -= Time.deltaTime;
        if (m_spawnTimeCoin <= 0)
        {
            SpawnCoin();
            m_spawnTimeCoin = spawnTimeCoin;
        }
        if (m_spawnTimeBomb <= 0)
        {
            SpawnBomb();
            m_spawnTimeBomb = spawnTimeBomb;
        }
        if (m_spawnTimeBungee <= 0)
        {
            SpawnBungee();
            m_spawnTimeBungee = spawnTimeBungee;
        }
    }
    private const float spawnLimit = 8.5f;
    private void SpawnCoin()
    {
        
        float randXPos = Random.Range(-spawnLimit, spawnLimit);
        float randZPos = Random.Range(-spawnLimit, spawnLimit);
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

    private void SpawnBomb()
    {
        float randXPos = Random.Range(-spawnLimit, spawnLimit);
        float randZPos = Random.Range(-spawnLimit, spawnLimit);
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

    private void SpawnBungee()
    {
        float randXPos = Random.Range(-spawnLimit + 2f, spawnLimit - 2f);
        float randZPos = Random.Range(-spawnLimit + 2f, spawnLimit - 2f);
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
    private bool checkSpawn(Vector3 spawnPos, List<Vector3> checkSpawnList)
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
    private bool checkPlayerPos(Vector3 spawnPos)
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

    public void setHighScore(int highScore)
    {
        m_highScore = highScore;
    }

    public int getHighScore()
    {
        return m_highScore;
    }

    public void ScoreIncreament()
    {
        if (m_isGameOver)
        {
            return;
        }
        countCoin++;
        m_score++;
        m_ui.SetScoreText(m_score);
        m_ui.SetLastScoreText(m_score);
        if (m_score > m_highScore)
        {
            m_highScore = m_score;
            SaveHighScore();
        }
        m_ui.SetHighScoreText(m_highScore);
    }

    public void setIsGameOver(bool isGameOver)
    {
        m_isGameOver = isGameOver;
    }

    public bool getIsGameOver()
    {
        return m_isGameOver;
    }
    private string GAME_SCENE = "GameScene";
    private string MENU_SCENE = "MenuScene";
    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
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

    public void SaveHighScore()
    {
        SaveSystem.SaveScore(this);
    }

    public void LoadHighScore()
    {
        ScoreData data = SaveSystem.LoadScore();
        m_highScore = data.highScore;
    }
}
