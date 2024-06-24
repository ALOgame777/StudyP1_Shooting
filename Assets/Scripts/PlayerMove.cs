using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�÷��̾ ���ϴ� �������� �̵��Ѵ�.

    public float moveSpeed = 0.1f;
    //private Vector3 direction;

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

    }


    // �� �����Ӹ��� �ݺ��ؼ� �����ϴ� �Լ�
    void Update()
    {
        //Vector3 direction = new Vector3(1, 1, 0);
        //transform.position += Vector3.right * moveSpeed;  
        //transform.position += direction * moveSpeed;
        //print(transform.position);

        // ������� �Է� �ޱ�
        float h =  Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, v, 0);
        //������ ���̸� ������ 1�� �ٲ۴�. Vector�� ����ȭ(Normalize)
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.eulerAngles += direction * moveSpeed * Time.deltaTime;
        //transform.localScale += direction * moveSpeed * Time.deltaTime;

        // Ư�� Ű�� �Է����� �� ����ϴ� �Լ�(Get, GetDown, GetUp)
        //bool value = Input.GetButton("Horizontal");

        //if(Input.GetKey(KeyCode.F1))
        //{
        //    print("F1 Ű�� �������ϴ�.");
        //}
    }
}
