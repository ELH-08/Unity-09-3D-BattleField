using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   


public class FPS_Damage : MonoBehaviour
{

    [SerializeField] private Image HPbar;
    [SerializeField] private float HP;
    [SerializeField] private float HPinit = 100f; //�ʱⰪ


    void Start()
    {
        HPbar = GameObject.Find("Canvas_UI").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        HP = HPinit; //HP�ʱⰪ ����
        HPbar.color = Color.red;


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PUNCH"))   //���� �浹�� �±װ� ��ġ��
        {
            HP -= 15f;                              //HP -15�� ����
            HP = Mathf.Clamp(HP, 0f, 100f);         //HP ���� ���� (�￩�� 0�̸�, ȸ���� �Ծ 100�̻� ���ǵ���)
            HPbar.fillAmount = HP / HPinit;
            //if (HP <= 0f)
            //    PlayerDie();
        }

        if (other.gameObject.CompareTag("SWORD"))   //���� �浹�� �±װ� ���̸�
        {
            HP -= 25f;                              //HP -25�� ����
            HP = Mathf.Clamp(HP, 0f, 100f);         //HP ���� ���� (�￩�� 0�̸�, ȸ���� �Ծ 100�̻� ���ǵ���)
            HPbar.fillAmount = HP / HPinit;
            //if (HP <= 0f)
            //    PlayerDie();
        }

        //if (HP <= 0f)
        //    PlayerDie();


    }

    void PlayerDie() 
    {
        Debug.Log("�÷��̾� ���!");
    }

}
