using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAniMotion : MonoBehaviour
{
    //1. �޸� �� ���� ���´�.
    //2. �޸��ٰ� ���߸� �ٽ� ���� �ܴ���.


    [SerializeField]            //private �����ص� �ν����� â���� ���̰� - ���ȋ����� ����ʵ�� ���� private���� ����ϰ�, �� Ȯ���� ���Ŀ��� serialize field�� ���ش�. 
    private Animation CombatSg;

    
    void Start()
    {
        CombatSg = transform.GetChild(0).GetChild(0).GetComponent<Animation>(); // FPSController - FirstPersonCharacter - CombatSG_Player�� �ִϸ��̼�

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))     //���� ����Ʈ�� W�� ���ÿ� ������
        {
            CombatSg.Play("running");

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //���� ����Ʈ�� ����
        {
            CombatSg.Play("runStop"); //�� �ٽ� �ܴ���
        }
        
    }
}
