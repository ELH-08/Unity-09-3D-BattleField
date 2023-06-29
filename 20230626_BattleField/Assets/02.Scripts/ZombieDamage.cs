using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bloodEffect;
    public float hp = 100f;                         //HP
    public float hpInit = 100f;                     //HP �ʱⰪ
    [SerializeField] private CapsuleCollider capsuleCollider;
    public static bool isDie = false;               //�������

    void Start()
    {
        //�ʱ갪 ���� : ���� �������ϴ°� �켱������ ���;� �Ѵ�.
        animator = GetComponent<Animator>();                            //�ڽ��� ���۳�Ʈ���� ȣ��
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        capsuleCollider = GetComponent<CapsuleCollider>();              //�ڽ��� ���۳�Ʈ���� ȣ��

    }

    //void Update(){}

    private void OnCollisionEnter(Collision collision)          //�浹ü
    {
        if (collision.gameObject.CompareTag("BULLET"))          //�浹�� ��ü�� �±װ� BULLET�̸�
        {
            Destroy(collision.gameObject);                      //BULLET ����
            GameObject IbloodEffect = Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);  //��ȿ�� ���� ����(��ȿ��, �浹�� ��ġ, ȸ�� ����)
            Destroy(IbloodEffect, 1.5f);
            animator.SetTrigger("isHit");                       //���� �ִϸ��̼� 
            hp -= 35f;                                          //�浹�Ҷ����� hp -35 ���̰�
            if (hp <= 0)                                        //hp�� 0���� ������
            {
                Die();                                          //Die() ȣ��
            }

        }
    }

    void Die() 
    {
        animator.SetTrigger("isDie");                           //��� �ִϸ��̼� ȣ��
        capsuleCollider.enabled = false;                        //ĸ�� �ݶ��̴� ��Ȱ��ȭ (���� ���� �Ͼ�� �ʵ���)
        isDie = true;                                           //��� Ȯ��


    }

}
