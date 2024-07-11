using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Legacy text 클래스 사용시
using TMPro; // Text mesh pro  클래스 사용시

public class ScoreUI : MonoBehaviour
{
    public Text text_currentScore;
    public Text text_bestScore;
    public TextMeshPro text_score;

    void Start()
    {
        //폰트 색상
        //text_bestScore.color = new Color(1, 0, 0);

    }

    void Update()
    {
    }
}
