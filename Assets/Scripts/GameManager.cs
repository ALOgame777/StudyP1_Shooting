using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; // UI Ŭ���� ���� ���ӽ����̽�
using UnityEngine.SceneManagement; // Scene�� �ٷ�� �����ϴ� Ŭ���� ���� ���ӽ����̽�
using UnityEditor; // UnityEditor ���� ����� �ٷ�� Ŭ���� ���� ���ӽ����̽�

public class GameManager : MonoBehaviour
{
    // Singletone Pattern Class
    // Static ���� �Լ�, Ŭ���� �տ� ���� �� ����, �տ� �ٿ��� ������ static
    // ������ ���� (������ ���� ����(public))
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
        // ���� �� �� ���� �����ϵ��� ó��
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
        // ���� ���� ǥ�� �ʱ�ȭ
        AddScore(0);

        // �ְ� ���� ǥ��
        // ����, "BestScore"��� Ű�� ����� �����Ͱ� �ִٸ�...
        if(PlayerPrefs.HasKey("BestScore"))
        {
            // "BestScore" ��� Ű�� ����� �����͸� �ҷ��´�.

            bestScore = PlayerPrefs.GetInt("BestScore");
            scoreUI.text_bestScore.text = bestScore.ToString();

        }
        else
        {
            scoreUI.text_bestScore.text = "0";
        }

        // ���� ���� UI�� ��Ȱ��ȭ�Ѵ�.
        gameOverUI.SetActive(false);
    }

    // ������ �߰��ϰ�, ����� ������ UI�� ����Ѵ�.

    public void AddScore(int point)
    {
        // 1. ������ �����Ѵ�.
        currentScore += point;

        // 2. ������ UI�� ����Ѵ�.
        scoreUI.text_currentScore.text = currentScore.ToString();
        // 3. ����, ���� ������ �ְ� �������� �� ���ٸ�...
        if (currentScore > bestScore)
        {
            // 3-1. ���� ������ �ְ� ������ �����Ѵ�.
            bestScore = currentScore;

            // 3-2. ����� �ְ� ������ UI�� ����Ѵ�.
            scoreUI.text_bestScore.text = bestScore.ToString();
        }
        // ����, ������ ��Ȱ��ȭ ���¶��...
        if (!bossObject.activeInHierarchy)
        {
            // 4. ����, ���� ������ ���� ���忡 �ʿ��� ������ �Ѿ�� ������ Ȱ��ȭ�Ѵ�.
            if (currentScore >= bossAppearScore)
            {
                // 4-1 ������ Ȱ��ȭ�Ѵ�.
                bossObject.SetActive(true);
                // 4-2 ������ EnemyFactory���� ��� ��Ȱ��ȭ ó���� �Ѵ�.
                //����� ��
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
    // ���� ������ �Ǹ� ������ �Լ�
    public void ShowGameOverUI()
    {
        // ���� ���� UI ������Ʈ�� Ȱ��ȭ�Ѵ�.
        gameOverUI.SetActive(true);

        // ������Ʈ �ð��� 0 ������� �����Ѵ�. (�ð��� �����)
        Time.timeScale = 0;
            
    }

    // ����ϱ� ��ư�� ������ �� ������ �Լ�
    public void ContinueGame()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    
    // ������ û�Ǻ��� �ٽ� �����ϴ� �Լ�
    public void RestartGame()
    {
        // ������Ʈ �ð��� �ٽ� 1������ �����Ѵ�.
        Time.timeScale = 1.0f;
        // ���� ���� �ٽ� �����Ѵ�.
        SceneManager.LoadScene(0);
    }

    // ���ø����̼��� �����ϴ� �Լ�
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 1. �������� �ܿ�
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. ���ø����̼��� ���
        Application.Quit();
#endif
    }
}
