using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; // UI 클래스 관련 네임스페이스
using UnityEngine.SceneManagement; // Scene을 다루고 관리하는 클래스 관련 네임스페이스
using UnityEditor; // UnityEditor 관련 기능을 다루는 클래스 관련 네임스페이스

public class GameManager : MonoBehaviour
{
    // Singletone Pattern Class
    // Static 변수 함수, 클래스 앞에 붙을 수 있음, 앞에 붙여져 있으면 static
    // 독립된 변수 (누구나 접근 가능(public))
    public static GameManager gm;
    public ScoreUI scoreUI;
    public GameObject gameOverUI;
    public GameObject bossObject;
    public GameObject[] enemyFactories;
    public int bossAppearScore = 10;
    int currentScore;

    public int BestScore { get { return bestScore; } }
    int bestScore;

    void Awake()
    {
        // 씬에 단 한 개만 존재하도록 처리
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 현재 점수 표시 초기화
        AddScore(0);

        // 최고 점수 표시
        // 만일, "BestScore"라는 키로 저장된 데이터가 있다면...
        if(PlayerPrefs.HasKey("BestScore"))
        {
            // "BestScore" 라는 키로 저장된 데이터를 불러온다.

            bestScore = PlayerPrefs.GetInt("BestScore");
            scoreUI.text_bestScore.text = bestScore.ToString();

        }
        else
        {
            scoreUI.text_bestScore.text = "0";
        }

        // 게임 오버 UI를 비활성화한다.
        gameOverUI.SetActive(false);
    }

    // 점수를 추가하고, 변경된 점수를 UI에 출력한다.

    public void AddScore(int point)
    {
        // 1. 점수를 누적한다.
        currentScore += point;

        // 2. 점수를 UI에 출력한다.
        scoreUI.text_currentScore.text = currentScore.ToString();
        // 3. 만일, 현재 점수가 최고 점수보다 더 높다면...
        if (currentScore > bestScore)
        {
            // 3-1. 현재 점수를 최고 점수로 갱신한다.
            bestScore = currentScore;

            // 3-2. 변경된 최고 점수를 UI에 출력한다.
            scoreUI.text_bestScore.text = bestScore.ToString();
        }
        // 만일, 보스가 비활성화 상태라면...
        if (!bossObject.activeInHierarchy)
        {
            // 4. 만일, 현재 점수가 보스 등장에 필요한 점수를 넘어서면 보스를 활성화한다.
            if (currentScore >= bossAppearScore)
            {
                // 4-1 보스를 활성화한다.
                bossObject.SetActive(true);
                // 4-2 기존의 EnemyFactory들은 모두 비활성화 처리를 한다.
                //강사님 답
                //for (int i = 0; i < enemyFactories.Length; i++)
                //{
                //    enemyFactories[i].SetActive(false);
                //}
                foreach (GameObject factory in enemyFactories)
                {
                    if (factory != null)
                    {
                        factory.SetActive(false);
                    }
                }

            }
        }

    }
    // 게임 오버가 되면 실행할 함수
    public void ShowGameOverUI()
    {
        // 게임 오버 UI 오브젝트를 활성화한다.
        gameOverUI.SetActive(true);

        // 업데이트 시간을 0 배속으로 변경한다. (시간을 멈춘다)
        Time.timeScale = 0;
            
    }

    // 계속하기 버튼을 눌렀을 때 실행할 함수
    public void ContinueGame()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    
    // 게임을 청므부터 다시 시작하는 함수
    public void RestartGame()
    {
        // 업데이트 시간을 다시 1배율로 변경한다.
        Time.timeScale = 1.0f;
        // 현재 씬을 다시 시작한다.
        SceneManager.LoadScene(0);
    }

    // 어플리케이션을 종료하는 함수
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 1. 에디터일 겨우
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. 어플리케이션일 경우
        Application.Quit();
#endif
    }
}
