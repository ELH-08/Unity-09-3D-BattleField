using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private float Speed = 2500.0f;
    

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid.AddForce(transform.forward * Speed, ForceMode.Force);  //Velocity : ���� ����
        //rigidbody.AddForce(Vector3.forward, ForceMode.Force);          //�Ѿ˹߻�� Vector3�� ���� �ȵȴ�. ���� ��ǥ�� �Ѿ� ������ �ٲ��� �ʴ´�.

        Destroy(gameObject, 3.0f);                                      //�ڱ� �ڽ�(�Ѿ�)�� �������� �ʵ��� 3���� ����- �޸� ���� X
    }



    //Update()�� �ʿ����. �ѹ��� �߻�Ǹ� �ȴ�.

    //�����ε�
}
