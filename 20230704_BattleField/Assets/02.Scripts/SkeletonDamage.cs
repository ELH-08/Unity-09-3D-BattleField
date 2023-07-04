using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                            //UI ���̺귯��(ĵ����, �̹���, �ؽ�Ʈ ��) ���

public class SkeletonDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;                 //�ִϸ�����
    [SerializeField] private GameObject bloodEffect;            //�� ȿ��
    [SerializeField] private CapsuleCollider capsuleCollider;   //ĸ�� �ݶ��̴�
    [SerializeField] private Canvas canvas;                     //ĵ����
    [SerializeField] private Image HPbar;                       //HP ü�¹� �̹���
    [SerializeField] private Text HPtext;                       //HP �ؽ�Ʈ 

    
    public float HP = 100f;                                     //HP
    public float HPInit = 100f;                                 //HP �ʱ� ��
    public static bool isDie = false;                           //��� ����
    public BoxCollider swordCollider;                        //�ذ� �� �ݶ��̴� - ������ ������ ã�� ���� ���� ��� ����.

    void Start()
    {
        //�ʱ갪 ���� : ���� �������ϴ°� �켱������ ���;� �Ѵ�.
        canvas = transform.GetChild(3).GetComponent<Canvas>();
        HPbar = transform.GetChild(3).GetChild(1).GetComponent<Image>();
        HPtext = transform.GetChild(3).GetChild(2).GetComponent<Text>();
        capsuleCollider = GetComponent<CapsuleCollider>();                  //(�� ��ũ��Ʈ�� �޸�)�ڽ��� ���۳�Ʈ���� ȣ��
        animator = GetComponent<Animator>();                                //(�� ��ũ��Ʈ�� �޸�)�ڽ��� ���۳�Ʈ���� ȣ��
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        HPbar.color = Color.green;                                          //�ذ� HP ü�¹ٸ� �ʷϻ�
    }



    private void OnCollisionEnter(Collision collision)          //�浹ü ����
    {
        if (collision.gameObject.CompareTag("BULLET"))          //�浹�� ��ü�� �±װ� BULLET�̸�
        {
            Destroy(collision.gameObject);                      //BULLET ����
            GameObject IbloodEffect = Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);  //��ȿ�� ���� ����(��ȿ��, �浹�� ��ġ, ȸ�� ����)
            Destroy(IbloodEffect, 1.5f);                        //������ �� ȿ�� ����
            animator.SetTrigger("isHit");                       //���� �ִϸ��̼� 
            HP_Manager();
            if (HP <= 0)                                        //hp�� 0���� ������
            {
                Die();                                          //Die() ȣ��
            }

        }
    }

    private void HP_Manager()
    {
        HP -= 35f;                                          //�浹�Ҷ����� hp -35 ���̰�
        HP = Mathf.Clamp(HP, 0f, 100f);                     //HP ������ ���������� ������ ��
        HPbar.fillAmount = HP / HPInit;                     //?
        HPtext.text = " HP: " + HP.ToString();              //HP : ���ڸ� ��� (���� + ���ڸ� ������������ �ٲ㼭 ���� ������ ���)


        if (HPbar.fillAmount <= 0.3f)                       //HP�� 30���� �̸��̸�
        {
            HPbar.color = Color.red;
        }
        else if (HPbar.fillAmount <= 0.5f)                 //HP�� 50���� �̸��̸�
        {
            HPbar.color = Color.yellow;
        }
    }

    void Die()                                                  //��� �Լ�
    {
        animator.SetTrigger("isDie");                           //��� �ִϸ��̼� ȣ��
        GetComponent<Rigidbody>().isKinematic = true;           //�ذ� ������� �� ����ȿ��(�浹 �������� �и��� ȿ��) ���� ����
        capsuleCollider.enabled = false;                        //ĸ�� �ݶ��̴� ��Ȱ��ȭ (���� ���� �Ͼ�� �ʵ���)
        isDie = true;                                           //��� Ȯ��
        canvas.enabled = false;
        Destroy(gameObject, 5.0f);                              //����ϸ� ��ü �������
        GameManager.instance.KillScore(1);                      //����� GameManager���� ų ���� 1�� ȣ���Ѵ�.

    }

    //public 
    public void SwordColliderEnable()                           //�� �ݶ��̴� Ȱ��ȭ �Լ�
    {
        swordCollider.enabled = true;                           //�� �ݶ��̴� Ȱ��ȭ     
    }

    //public
    public void SwordColliderDisable()                          //�� �ݶ��̴� ��Ȱ��ȭ �Լ� 
    {
        swordCollider.enabled = false;                          //�� �ݶ��̴� ��Ȱ��ȭ
    }
}
