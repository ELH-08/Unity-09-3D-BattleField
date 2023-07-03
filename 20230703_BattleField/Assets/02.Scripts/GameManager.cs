using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ��Ϲ��� = ���� (���� ȯ�� ����)

���Ͱ� �¾�� ����
1. ���� ������
2. �����Ǵ� ��ġ : SpawnPoint
3. �� �� �������� ������ ���� - ex) ���� 3��, �ذ� 5��
4. �ִ� ���� �� ����
*/

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;             //���� ������
    [SerializeField] private GameObject skeletonPrefab;           //�ذ� ������
    [SerializeField] private Transform[] spawnPoints;             //���Ͱ� ������ ��ġ���� ����
    [SerializeField] private float previousTime_Z = 0f;           //���� �ð�_����
    [SerializeField] private float previousTime_S = 0f;           //���� �ð�_�ذ�
    [SerializeField] private int maxCount = 4;                    //�ִ� ���� �� 5������ ����
    

    void Start()
    {
        zombiePrefab = Resources.Load<GameObject>("Zombie");
        skeletonPrefab = Resources.Load<GameObject>("Skeleton");
        spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();  //SpawnPoints�� ã��, �ڽ� ��ü���� ��ġ���� ���� �迭 ���·� ����. (�ڱ� �ڽű��� �����)
        previousTime_Z = Time.time;  //�� ��ũ��Ʈ ���۰� ���ÿ� �ش� �ð� ����
        previousTime_S = Time.time;  //�� ��ũ��Ʈ ���۰� ���ÿ� �ش� �ð� ����


    }

    void Update()
    {

        if (Time.time - previousTime_Z >= 3.0f)  //�귯�� �ð�(����� - ���Žð�)�� 3�� �̻��̸�
        {
            int zombieCount = (int)GameObject.FindGameObjectsWithTag("ZOMBIE").Length; //���̾��Ű���� ���� �±׸� ���� ��ü���� ������ int������ ��ȯ�Ͽ� zombieCount�� ����.
            if (zombieCount <= maxCount)             //������ ���� ���� �ִ� �� �̸��̸�
                CreateZombie();                      //���� ����
            previousTime_Z = Time.time;              //���� �ð��� ���� �ð����� ����
        }

        if (Time.time - previousTime_S >= 5.0f)  //�귯�� �ð�(����� - ���Žð�)�� 3�� �̻��̸�
        {
            int skeletonCount = (int)GameObject.FindGameObjectsWithTag("SKELETON").Length; //���̾��Ű���� �ذ� �±׸� ���� ��ü���� ������ int������ ��ȯ�Ͽ� zombieCount�� ����.
            if (skeletonCount <= maxCount)             //������ ���� ���� �ִ� �� �̸��̸�
                CreateSkeleton();                      //�ذ� ����
            previousTime_S = Time.time;                //���� �ð��� ���� �ð����� ����
        }

        
    }

    void CreateZombie() 
    {
        int index = Random.Range(1, spawnPoints.Length); //�迭�� �ι�° ���� �迭 ���̰� ����  (�ڱ� �ڽ��� ���� �����ؾ� �ϹǷ�)
        Instantiate(zombiePrefab, spawnPoints[index].position, spawnPoints[index].rotation); //(what, where, how rotation)
    }

    void CreateSkeleton() 
    {
        int index = Random.Range(1, spawnPoints.Length); //�迭�� �ι�° ���� �迭 ���̰� ����  (�ڱ� �ڽ��� ���� �����ؾ� �ϹǷ�)
        Instantiate(skeletonPrefab, spawnPoints[index].position, spawnPoints[index].rotation); //(what, where, how rotation)
    }


}
