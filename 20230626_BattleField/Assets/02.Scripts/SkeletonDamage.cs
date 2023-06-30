using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                            //UI ���̺귯�� ���

public class SkeletonDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;                 //�ִϸ�����
    [SerializeField] private GameObject bloodEffect;            //��ȿ��
    [SerializeField] private CapsuleCollider capsuleCollider;   //ĸ�� �ݶ��̴�
    [SerializeField] private Canvas canvas;               //UI���̺귯�� �ʿ�
    [SerializeField] private Image hpBar;                 //UI���̺귯�� �ʿ�
    [SerializeField] private Text hpText;                 //UI���̺귯�� �ʿ�

    public float hp = 100f;                                     //HP
    public float hpInit = 100f;                                 //HP �ʱⰪ
    public static bool isDie = false;                           //�������


    void Start()
    {
        canvas = transform.GetChild(3).GetComponent<Canvas>();
        hpBar = transform.GetChild(3).GetChild(1).GetComponent<Image>();
        hpText = transform.GetChild(3).GetChild(2).GetComponent<Text>();
        //�ʱ갪 ���� : ���� �������ϴ°� �켱������ ���;� �Ѵ�.
        capsuleCollider = GetComponent<CapsuleCollider>();              //�ڽ��� ���۳�Ʈ���� ȣ��
        animator = GetComponent<Animator>();                            //�ڽ��� ���۳�Ʈ���� ȣ��
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        hpBar.color = Color.green;                                       //
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}


    private void OnCollisionEnter(Collision collision)          //�浹ü
    {
        if (collision.gameObject.CompareTag("BULLET"))          //�浹�� ��ü�� �±װ� BULLET�̸�
        {
            Destroy(collision.gameObject);                      //BULLET ����
            GameObject IbloodEffect = Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);  //��ȿ�� ���� ����(��ȿ��, �浹�� ��ġ, ȸ�� ����)
            Destroy(IbloodEffect, 1.5f);
            animator.SetTrigger("isHit");                       //���� �ִϸ��̼� 
            HP_Manager();
            if (hp <= 0)                                        //hp�� 0���� ������
            {
                Die();                                          //Die() ȣ��
            }

        }
    }

    private void HP_Manager()
    {
        hp -= 35f;                                          //�浹�Ҷ����� hp -35 ���̰�
        hp = Mathf.Clamp(hp, 0f, 100f);                     //HP ������ ���������� ������ ��
        hpBar.fillAmount = hp / hpInit;                     //?
        hpText.text = " HP: " + hp.ToString();              //HP : ���ڸ� ��� (���� + ���ڸ� ������������ �ٲ㼭 ���� ������ ���)


        if (hpBar.fillAmount <= 0.3f)                       //HP�� 30���� �̸��̸�
        {
            hpBar.color = Color.red;
        }
        else if (hpBar.fillAmount <= 0.5f)                 //HP�� 50���� �̸��̸�
        {
            hpBar.color = Color.yellow;
        }
    }

    void Die()
    {
        animator.SetTrigger("isDie");                           //��� �ִϸ��̼� ȣ��
        GetComponent<Rigidbody>().isKinematic = true;           //�ذ� ������� �� ����ȿ��(�浹 �������� �и��� ȿ��) ���� ����
        capsuleCollider.enabled = false;                        //ĸ�� �ݶ��̴� ��Ȱ��ȭ (���� ���� �Ͼ�� �ʵ���)
        isDie = true;                                           //��� Ȯ��
        canvas.enabled = false;
        Destroy(gameObject, 5.0f);                              //����ϸ� ��ü �������

    }
}
