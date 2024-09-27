using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEditor;
using TMPro;

public class GameManager : PersistentSingleton<GameManager> 
{
    
    public event Action<int> OnScoreChanged;
    public event Action<float> OnTimerUpdated;
    public event Action OnGameStart;
    public event Action<float> OnGameEnd;
    public event Action OnPlayerDead;

    private BallController player;
    [SerializeField] string gameScene;
    private float timer = 0f;
    
    private bool isGameActive = false;
    public Vector3 checkPointPosition ;
    protected override void Awake()
    {
        base.Awake();
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (scene.name == gameScene)
        {
            isGameActive = true;
            
            
            OnGameStart?.Invoke();
             
            AreaChecker areaChecker = FindObjectOfType<AreaChecker>();
            areaChecker.OnPlayerExitArea += playerDead;
            FinishArea finishArea = FindObjectOfType<FinishArea>();
            if (finishArea != null)
            {
                Debug.Log("finishArea: "+finishArea);
                finishArea.OnPlayerEnterArea += EndGame;
            }

            
            player= FindObjectOfType<BallController>();
            
            Debug.Log("checkPointPosition: "+checkPointPosition);
            // find player or not 
            Debug.Log("player: "+player);
            StartCoroutine(SetPlayerPosition());
        }
        
    }
    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
            OnTimerUpdated?.Invoke(timer);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Game"); 
        timer = 0f;
        checkPointPosition = Vector3.zero;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Start");
    }

    public void EndGame()
    {
        isGameActive = false;
        OnGameEnd?.Invoke(timer);
    }
    
    
    public void RestartGame()
    {
        AreaChecker areaChecker = FindObjectOfType<AreaChecker>();
        areaChecker.OnPlayerExitArea -= playerDead;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void playerDead()
    {
        RestartGame();
        
    }

    private IEnumerator SetPlayerPosition()
    {
        
        yield return null;

        
        player.transform.position = instance.checkPointPosition;
        Debug.Log("Player position set to: " + checkPointPosition);
    }
}