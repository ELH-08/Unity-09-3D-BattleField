using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;                           //UI ���̺귯�� ���

public class ZombieDamage : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bloodEffect;
    [SerializeField] private CapsuleCollider capsuleCollider;
    //[SerializeField] private Image UnityEngine.UI.hpBar;               //UI���̺귯���� ������ �̷� ������ ����ؾ� �Ѵ�.
    [SerializeField] private Canvas canvas;               //UI���̺귯�� �ʿ�
    [SerializeField] private Image hpBar;                 //UI���̺귯�� �ʿ�
    [SerializeField] private Text hpText;                 //UI���̺귯�� �ʿ�
    [SerializeField] private BoxCollider punchCollider;   //UI���̺귯�� �ʿ�

    public float hp = 100f;                               //HP
    public float hpInit = 100f;                           //HP �ʱⰪ

    public static bool isDie = false;                     //�������

    void Start()
    {
        //�ʱ갪 ���� : ���� �������ϴ°� �켱������ ���;� �Ѵ�.
        punchCollider = transform.GetChild(0).GetChild(2).GetComponent<BoxCollider>();
        canvas = transform.GetChild(18).GetComponent<Canvas>();
        hpBar = transform.GetChild(18).GetChild(0).GetChild(0).GetComponent<Image>();
        hpText = transform.GetChild(18).GetChild(0).GetChild(1).GetComponent<Text>();
        capsuleCollider = GetComponent<CapsuleCollider>();                          //�ڽſ��� ȣ��
        animator = GetComponent<Animator>();                                        //�ڽſ��� ȣ��
        bloodEffect = Resources.Load<GameObject>("Effect/Blood");
        hpBar.color = Color.green;                                                  //������� ����

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
        hpText.text = " HP: " + hp.ToString();              //HP : ���ڸ� ��� (���� + ���ڸ� ������������ �ٲ㼭 ���� ������ ���)
        hpBar.fillAmount = hp / hpInit;                     //?

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
        capsuleCollider.enabled = false;                        //ĸ�� �ݶ��̴� ��Ȱ��ȭ (���� ���� �Ͼ�� �ʵ���)
        isDie = true;                                           //��� Ȯ��
        canvas.enabled = false;
        Destroy(gameObject, 5.0f);                              //����ϸ� ��ü �������
        GameManager.instance.KillScore(1);                      //����� GameManager���� ų ���� 1�� ȣ���Ѵ�.
    }


    //public 
    public void PunchColliderEnable()                           //�� �ݶ��̴� Ȱ��ȭ �Լ�
    {
        punchCollider.enabled = true;                           //��ġ �ݶ��̴� Ȱ��ȭ
    }

    //public
    public void PunchColliderDisable()                          //�� �ݶ��̴� ��Ȱ��ȭ �Լ� 
    {
        punchCollider.enabled = false;                          //��ġ �ݶ��̴� ��Ȱ��ȭ
    }

}
