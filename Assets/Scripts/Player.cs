using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector3 MoveVector = Vector3.zero;

    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    Transform MainBGQuadTransform;




    [SerializeField]
    float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }

    void UpdateMove()
    {
        if (MoveVector.sqrMagnitude == 0)
            return;

        MoveVector = AdjustMoveVector(MoveVector);



        transform.position += MoveVector;
    }



    public void PrpcessInput(Vector3 moveDirection)
    {
        MoveVector = moveDirection * Speed * Time.deltaTime;
    }

    private Vector3 AdjustMoveVector(Vector3 moveVector)
    {

        Vector3 result = Vector3.zero;


        result = boxCollider.transform.position + boxCollider.center + moveVector;

        if (result.x - boxCollider.size.x * 0.5f < -MainBGQuadTransform.localScale.x * 0.5f)
            moveVector.x = 0;
        if (result.x + boxCollider.size.x * 0.5f > MainBGQuadTransform.localScale.x * 0.5f)
            moveVector.x = 0;

        if (result.y - boxCollider.size.y * 0.5f < -MainBGQuadTransform.localScale.y * 0.5f)
         moveVector.y = 0;
        if (result.y + boxCollider.size.y * 0.5f > MainBGQuadTransform.localScale.y * 0.5f)
                moveVector.y = 0;



    // // gpt 버전 코드
    
    // 다음 프레임에 이동했을 때의 예상 위치
    // 현재 위치 + 이동 벡터
    // Vector3 nextPos = transform.position + moveVector;

    // // 플레이어 콜라이더의 실제 월드 기준 경계 정보
    // // bounds는 scale, collider 크기 등을 모두 반영한 실제 충돌 범위
    // Bounds playerBounds = boxCollider.bounds;

    // // 맵 배경 오브젝트의 실제 화면상 경계
    // // Renderer.bounds 역시 scale, mesh 크기 등을 반영한 실제 월드 크기
    // Bounds mapBounds = MainBGQuadTransform.GetComponent<Renderer>().bounds;

    // // 플레이어 콜라이더의 반 너비
    // // extents = bounds의 절반 크기
    // float playerHalfX = playerBounds.extents.x;

    // // 플레이어 콜라이더의 반 높이
    // float playerHalfY = playerBounds.extents.y;

    // // 맵의 실제 왼쪽 경계
    // float mapMinX = mapBounds.min.x;

    // // 맵의 실제 오른쪽 경계
    // float mapMaxX = mapBounds.max.x;

    // // 맵의 실제 아래쪽 경계
    // float mapMinY = mapBounds.min.y;

    // // 맵의 실제 위쪽 경계
    // float mapMaxY = mapBounds.max.y;

    // // ---------------------------------------------------------
    // // X축 이동 제한
    // // ---------------------------------------------------------

    // // 플레이어의 왼쪽 끝이 맵 왼쪽을 넘어가면 이동 막기
    // if (nextPos.x - playerHalfX < mapMinX)
    // {
    //     moveVector.x = 0;
    // }

    // // 플레이어의 오른쪽 끝이 맵 오른쪽을 넘어가면 이동 막기
    // if (nextPos.x + playerHalfX > mapMaxX)
    // {
    //     moveVector.x = 0;
    // }

    // // ---------------------------------------------------------
    // // Y축 이동 제한
    // // ---------------------------------------------------------

    // // 플레이어의 아래쪽이 맵 아래를 넘어가면 이동 막기
    // if (nextPos.y - playerHalfY < mapMinY)
    // {
    //     moveVector.y = 0;
    // }

    // // 플레이어의 위쪽이 맵 위를 넘어가면 이동 막기
    // if (nextPos.y + playerHalfY > mapMaxY)
    // {
    //     moveVector.y = 0;
    // }


        return moveVector;
    }


}
