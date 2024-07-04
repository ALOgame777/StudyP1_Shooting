using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�÷��̾ ���ϴ� �������� �̵��Ѵ�.
    public float moveSpeed = 0.1f;
    public float rotSpeed = 100f;
    //private Vector3 direction;

    float rotY;
    Animator myAnim;

    #region �ӵ���?
    // ����, �ӷ� = �ӵ�(Vector)
    // ���� ���� ũ��(Scalar)���� �ǹ��� [�Ǽ���] float
    // �ӵ��� ������ ���̰� ������(���� ũ��) (-->) [���� ũ�� + ���� > Vector] x, y , z
    // 2d( Vector x, Vector y) 3d( Vector x , Vector y , Vector z)
    // ������ ���� ������ �Ӹ� ���������� ����.
    #endregion
    #region Life Cycle
    // Life cycle(���� �ֱ�)  Start(�¾��) Update(��ٰ�) 1 Frame : �ڵ带 �� �� �� ������ ���� 1������
    #endregion
    #region ElementWise����, Vector * Scalar
    //ElementWise ���� (x,y,z) +- (x,y,z) x+x , x-x (������ �ٲ� ��)
    //������ ������ �ٲ��� �ʰ� ���� ũ�⸸ ũ�� �ҷ��� �ϸ� Vector * Scalar(0.1f)
    // A - B = B�� ��ġ���� A��ġ�� �ٶ󺸴� ����
    // ��� �뵵 : ��밡 ������ �������� ����, �ڿ� ���Ͱ� �տ� ���͸� ��ġ�ؼ� �ٶ󺸴� ����, �̵��� ���
    // ���� Target�� �ٶ󺸴� ���� ����
    // Target ���� - ���� ����
    #endregion
    #region ��ӵ� � ����
    //**�߿�**
    // �̵� ���� P = P0 + V(����)T(�ð�) -> ���� ��ġ =  ������ ��ġ + ���� * �ð�
    // ��ӵ� � ����
    #endregion
    #region ������ ���� (5��) ���� ������ ��
    //3������ �ڵ��� ������ ���õ� ��(����, ����, ������Ʈ), 2������ �� ������ ���� ������� �ؾ� �ϴ� ��(������ ���̰� �;��� ��)
    // ��ü������ ���� 
    // �������� �ϰڴ�.
    // ������Ʈ �ð� ���� ���� �˻�
    #endregion
    #region Axis(��)
    // x-Axis
    // Negative - , Positive +
    #endregion
    #region 
    
    #endregion

    // ó�� �����Ǿ��� �� �� ���� ����Ǵ� �Լ�
    void Start()
    {
        // ������ �پ��ִ� Animator ������Ʈ ��������
        myAnim = GetComponent<Animator>();
    }


    // �� �����Ӹ��� �ݺ��ؼ� �����ϴ� �Լ�
    void Update()
    {
        #region �̵� ���� �����
        //Vector3 direction = new Vector3(1, 1, 0);
        //transform.position += Vector3.right * moveSpeed;  
        //transform.position += direction * moveSpeed;
        //print(transform.position);
        #endregion

        // ������� �Է� �ޱ�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, v, 0);
        //������ ���̸� ������ 1�� �ٲ۴�. Vector�� ����ȭ(Normalize)
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.eulerAngles += direction * moveSpeed * Time.deltaTime;
        //transform.localScale += direction * moveSpeed * Time.deltaTime;

        // ��ü�� ȸ�� : r = r0 +vt
        rotY += (h * -1) * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotY, 0);

        float inputH = MathF.Abs(h);
        // ����, ������� �¿� �Է��� ���ٸ�
        if(inputH < 0.1f)
        {

            // ��ü�� ȸ������ �ٽ� ������� �������´�.
            //transform.eulerAngles = Vector3.zero;
            #region ���Ϸ� �ޱ� ���� ����ϴ� ���
            // 1. ���Ϸ� �ޱ��� ���� ����ϴ� ���
            //if (MathF.Abs(transform.eulerAngles.y) > 1.0f)
            //{
            //    if (transform.eulerAngles.y < 0)
            //    {
            //        rotY += rotSpeed * Time.deltaTime;
            //    }
            //    else
            //    {
            //        rotY -= rotSpeed * Time.deltaTime;
            //    }
            //    transform.eulerAngles += new Vector3(0, rotY, 0);
            //}
            //else
            //{
            //    transform.eulerAngles = Vector3.zero;
            //}
            #endregion

            //2.  Lerp�� �̿��� ���
            rotY = Mathf.Lerp(rotY, 0, Time.deltaTime);
            transform.eulerAngles = new Vector3(0, rotY, 0);


        }
        #region �ִϸ����͸� ����� ȸ�� �ִϸ��̼� �ֱ�
        // �ִϸ����͸� ����� ȸ�� �ִϸ��̼� �ֱ�
        //if (h > 0.2f)
        //{
        //    myAnim.SetTrigger("RightMove");
        //}
        //else if (h < -0.2f)
        //{
        //    myAnim.SetTrigger("LeftMove");
        //}
        //else
        //{
        //    myAnim.SetTrigger("Idle");
        //}
        #endregion

        #region ������� Ű �Է�
        // Ư�� Ű�� �Է����� �� ����ϴ� �Լ�(Get, GetDown, GetUp)
        //bool value = Input.GetButton("Horizontal");

        //if(Input.GetKey(KeyCode.F1))
        //{
        //    print("F1 Ű�� �������ϴ�.");
        //}
        #endregion

    }
}
