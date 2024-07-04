using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delayTime = 2.0f;
    float currentTime = 0;
    #region 타이머 3,2,1 전역 변수
    // 출력할 변수 값
    // 전역 변수 3, 2, 1
    //float printTime = 1.0f;
    //int timeCount = 3;
    //bool isTimerStart = true;
    #endregion

    // 지정한 시간이 될 때마다 에너미를 생성한다.
    // 지정 시간, 에너미 프리팹, 경과된 시간
    void Start()
    {
        // Invoke 함수를 이용한 타이머 기능
        // 1회용 타이머
        // Invoke()

        //Invoke("InvokeTest", 2.5f);
        //InvokeRepeating("InvokeTest", 3.0f, 1.0f);
        // Invoke 함수는 매개변수가 없는 함수만 사용 가능하다.
        
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > delayTime)
        {
            // 에너미를 생성한다.
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;

            // 경과 시간을 다시 0으로 초기화한다.
            currentTime = 0;
        }


        #region 타이머 함수 사용
        //타이머 3,2,1 함수 사용
        //if(isTimerStart)
        //{
        //    printTime = 3;
        //    StartTimer();     
        //}
        // 그냥 for문은 시간 개념이 없다.
        // 다음 프레임에 하지 않는다.
        // 시간 마다 카운트 다운 3, 2, 1 , start하기
        // 1초마다 출력
        // 반복 할때마다 바꾸기

        // 3초부터 카운트 다운을 시작한다.
        // 단, 매 1초마다 남은 시간을 출력한다.

        // 마지막에는 "Start"로 출력한다.
        // 남은 시간이 0초가 되면 카운트를 중단한다. 시작시 멈춘다.


        // void StartTimer()
        //{
        //    currentTime += Time.deltaTime;
        //    if (currentTime > printTime)
        //    {
        //        if (timeCount == 0)
        //        {
        //            print("Start");
        //            isTimerStart = false;
        //            // 재사용
        //            currentTime = 0;
        //            printTime = 3;
        //        }
        //        else
        //        {
        //            print(timeCount);

        //        }
        //        timeCount--;
        //        currentTime = 0;

        //    }
        //}
        #endregion

    }
    void InvokeTest()
    {
        print("인보크 기능 실시!");
    }

}
