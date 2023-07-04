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
        rigid.AddForce(transform.forward * Speed, ForceMode.Force);  //Velocity : 힘과 방향
        //rigidbody.AddForce(Vector3.forward, ForceMode.Force);          //총알발사시 Vector3는 절대 안된다. 전역 좌표라서 총알 방향이 바뀌지 않는다.

        Destroy(gameObject, 3.0f);                                      //자기 자신(총알)이 남아있지 않도록 3초후 삭제- 메모리 누적 X
    }



    //Update()는 필요없다. 한번만 발사되면 된다.

    //오버로드
}
