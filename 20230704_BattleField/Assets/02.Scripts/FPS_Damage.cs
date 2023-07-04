using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                               //UI ���̺귯�� ȣ��                             
using UnityEngine.SceneManagement;                  //�� ��ȯ ���� ���̺귯�� ȣ��
using Unity.VisualScripting;                        //?

public class FPS_Damage : MonoBehaviour
{

    [SerializeField] private Image HPbar;               //HP
    [SerializeField] private float HP;                  //HP
    [SerializeField] private float HPinit = 100f;       //HP �ʱⰪ
    [SerializeField] private GameObject killCanvas;     //����� ��Ÿ���� ĵ����


    void Start()
    {
        killCanvas = GameObject.Find("Canvas_UI").transform.GetChild(2).gameObject;
        HPbar = GameObject.Find("Canvas_UI").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        HP = HPinit;                                //HP�ʱⰪ ����
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
        killCanvas.SetActive(true);                  //��� ĵ���� �ѱ�
        Invoke("EndScene", 3.0f);                    //3�� �Ŀ� ��� �� ȣ��

        
    }

    void EndScene()                                  //��� �� 
    {
        SceneManager.LoadScene("EndScene");          //EndScene���� ��ȯ
    }

}
