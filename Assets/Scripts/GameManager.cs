using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singletone Pattern Class
    // Static 변수 함수, 클래스 앞에 붙을 수 있음, 앞에 붙여져 있으면 static
    // 독립된 변수 (누구나 접근 가능(public))
    public static GameManager gm;
    public ScoreUI scoreUI;
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
    }

}
