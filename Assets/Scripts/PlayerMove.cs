using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어를 원하는 방향으로 이동한다.

    public float moveSpeed = 0.1f;
    //private Vector3 direction;

    #region 속도란?
    // 방향, 속력 = 속도(Vector)
    // 점은 힘의 크기(Scalar)만을 의미함 [실수형] float
    // 속도는 몸통의 길이가 빠르기(힘의 크기) (-->) [힘의 크기 + 방향 > Vector] x, y , z
    // 2d( Vector x, Vector y) 3d( Vector x , Vector y , Vector z)
    // 방향은 꼬리 끝에서 머리 끝방향으로 간다.
    #endregion
    #region Life Cycle
    // Life cycle(생애 주기)  Start(태어나고) Update(살다가) 1 Frame : 코드를 한 번 다 실행한 것을 1프레임
    #endregion
    #region ElementWise연산, Vector * Scalar
    //ElementWise 연산 (x,y,z) +- (x,y,z) x+x , x-x (방향을 바꿀 때)
    //벡터의 방향을 바꾸지 않고 힘의 크기만 크게 할려고 하면 Vector * Scalar(0.1f)
    // A - B = B의 위치에서 A위치를 바라보는 벡터
    // 사용 용도 : 상대가 나한테 오기위한 방향, 뒤에 벡터가 앞에 벡터를 위치해서 바라보는 방향, 이동의 결과
    // 내가 Target을 바라보는 방향 벡터
    // Target 벡터 - 나의 벡터
    #endregion
    #region 등속도 운동 공식
    //**중요**
    // 이동 공식 P = P0 + V(방향)T(시간) -> 현재 위치 =  과거의 위치 + 방향 * 시간
    // 등속도 운동 공식
    #endregion
    #region 오늘의 할일 (5개) 실현 가능한 것
    //3가지는 코딩에 수업에 관련된 것(복습, 예습, 프로젝트), 2가지는 더 발전된 삶을 살기위해 해야 하는 것(습관을 들이고 싶었던 것)
    // 구체적으로 적기 
    // 언제부터 하겠다.
    // 프로젝트 시간 시작 전에 검사
    #endregion
    #region Axis(축)
    // x-Axis
    // Negative - , Positive +
    #endregion
    #region 
    
    #endregion

    // 처음 생성되었을 때 한 번만 실행되는 함수
    void Start()
    {

    }


    // 매 프레임마다 반복해서 실행하는 함수
    void Update()
    {
        //Vector3 direction = new Vector3(1, 1, 0);
        //transform.position += Vector3.right * moveSpeed;  
        //transform.position += direction * moveSpeed;
        //print(transform.position);

        // 사용자의 입력 받기
        float h =  Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, v, 0);
        //벡터의 길이를 무조건 1로 바꾼다. Vector의 정규화(Normalize)
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.eulerAngles += direction * moveSpeed * Time.deltaTime;
        //transform.localScale += direction * moveSpeed * Time.deltaTime;

        // 특정 키를 입력했을 때 사용하는 함수(Get, GetDown, GetUp)
        //bool value = Input.GetButton("Horizontal");

        //if(Input.GetKey(KeyCode.F1))
        //{
        //    print("F1 키를 눌렀습니다.");
        //}
    }
}
