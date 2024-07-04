using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delayTime = 2.0f;
    float currentTime = 0;
    #region Ÿ�̸� 3,2,1 ���� ����
    // ����� ���� ��
    // ���� ���� 3, 2, 1
    //float printTime = 1.0f;
    //int timeCount = 3;
    //bool isTimerStart = true;
    #endregion

    // ������ �ð��� �� ������ ���ʹ̸� �����Ѵ�.
    // ���� �ð�, ���ʹ� ������, ����� �ð�
    void Start()
    {
        // Invoke �Լ��� �̿��� Ÿ�̸� ���
        // 1ȸ�� Ÿ�̸�
        // Invoke()

        //Invoke("InvokeTest", 2.5f);
        //InvokeRepeating("InvokeTest", 3.0f, 1.0f);
        // Invoke �Լ��� �Ű������� ���� �Լ��� ��� �����ϴ�.
        
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > delayTime)
        {
            // ���ʹ̸� �����Ѵ�.
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;

            // ��� �ð��� �ٽ� 0���� �ʱ�ȭ�Ѵ�.
            currentTime = 0;
        }


        #region Ÿ�̸� �Լ� ���
        //Ÿ�̸� 3,2,1 �Լ� ���
        //if(isTimerStart)
        //{
        //    printTime = 3;
        //    StartTimer();     
        //}
        // �׳� for���� �ð� ������ ����.
        // ���� �����ӿ� ���� �ʴ´�.
        // �ð� ���� ī��Ʈ �ٿ� 3, 2, 1 , start�ϱ�
        // 1�ʸ��� ���
        // �ݺ� �Ҷ����� �ٲٱ�

        // 3�ʺ��� ī��Ʈ �ٿ��� �����Ѵ�.
        // ��, �� 1�ʸ��� ���� �ð��� ����Ѵ�.

        // ���������� "Start"�� ����Ѵ�.
        // ���� �ð��� 0�ʰ� �Ǹ� ī��Ʈ�� �ߴ��Ѵ�. ���۽� �����.


        // void StartTimer()
        //{
        //    currentTime += Time.deltaTime;
        //    if (currentTime > printTime)
        //    {
        //        if (timeCount == 0)
        //        {
        //            print("Start");
        //            isTimerStart = false;
        //            // ����
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
        print("�κ�ũ ��� �ǽ�!");
    }

}
