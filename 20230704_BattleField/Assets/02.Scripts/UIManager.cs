using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       //UI ���̺귯�� ȣ��    
using UnityEngine.SceneManagement;          //��� ��ȯ �����ϴ� ���̺귯�� ȣ��
using UnityEditor;                          //Unity Editor (window �ü������ ����Ƽ�� ����ϴ� ���) ���̺귯�� ȣ��


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text FinalKillText;                  //���� ų �� 

    void Start()
    {
        FinalKillText = GameObject.Find("Canvas_UI").transform.GetChild(2).GetChild(3).GetComponent<Text>();
        FinalKillText.text = "Final Kill : " + GameManager.instance.Totalkill.ToString();
        
        //��� �� ���콺 Ŀ�� ���̵���
        Cursor.lockState = CursorLockMode.None;     //���콺 Ŀ�� ������ �ʵ��� 
        Cursor.visible = true;                      //���콺 Ŀ�� ���̵���

        //(Ư�� Ű�� ������)  ���콺 Ŀ�� �� ���̰�
        //Cursor.lockState = CursorLockMode.Locked;     //���콺 Ŀ�� ������ �ʵ��� 
        //Cursor.visible = false;                      //���콺 Ŀ�� ���̵���

    }

    public void PlayGame() 
    {

        SceneManager.LoadScene("BattleFieldScene");     //���� ������ ��ȯ
    }

    public void Quit()
    {
//��ũ�� : �Լ� ȣ�� ���� �̸� ����� ����Ǵ� ��
        
        //�� ���� ���Ḧ �ؾ��� 
        //1. Unity���� ���� :
        //2. Build�� �������� ���� : 

#if UNITY_EDITOR //����Ƽ ������ : �����쿡�� ����Ƽ�� ����ϴ� ���
        //UnityEditor.EditorApplication.isPlaying = false;  //����Ƽ ������ ���̺귯���� ������� �ʴ� ���
        EditorApplication.isPlaying = false;
#else
       Application.Quit();                             //������ ������ ����
#endif


    }


}
