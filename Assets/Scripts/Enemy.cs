using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State 
    {
        None = -1, // 사용전
        Ready = 0, // 준비완료
        Appear,    //등장
        Battle,    //전투중
        Dead,      //사망
        Disappear, //퇴장
    }
    
    [SerializeField]
    State CurrentState = State.None;

    private const float MaxSpeed = 10.0f;
    private const float MaxSpeedTime = 10.0f;
    
    [SerializeField]
    Vector3 TargetPosition = Vector3.zero;

    [SerializeField] private float CurrentSpeed; 
    
    Vector3 CurrentVelocity;

    float MoveStartTime = 0.0f;
    float BattleStartTime = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Appear(new Vector3(7.0f,transform.position.y,transform.position.z));
        }

        switch (CurrentState)
        {
            case State.None:
            case State.Ready:
                break;
            case State.Dead:
                break;
            case State.Appear:
            case State.Disappear:
                UpdateSpeed();
                UpdateMove(); 
                break;
            case State.Battle:
                UpdateBattle();
                break;
        }

    }

    void UpdateSpeed()
    {
       CurrentSpeed = Mathf.Lerp(CurrentSpeed, MaxSpeed,(Time.time - MoveStartTime)/MaxSpeedTime );
    }

    void UpdateMove()
    {
        float distance = Vector3.Distance(TargetPosition, transform.position);
        
        if (distance <= 0.01f)
        {
            Arrived();
        }
        
        if (CurrentSpeed <= 0.01f)
        {
            return;
        }
        
        CurrentVelocity = (TargetPosition - transform.position).normalized * CurrentSpeed;
        
       transform.position = Vector3.SmoothDamp(transform.position,TargetPosition, ref CurrentVelocity,distance/ CurrentSpeed,MaxSpeed);
        
    }

    void Arrived()
    {
        CurrentSpeed = 0.0f;
        
        if (CurrentState == State.Appear)
        {
            CurrentState = State.Battle;
            BattleStartTime = Time.time;
        }
        else // if( currentState == State.Disappear)
        {
            CurrentState = State.None;
        }

}

    public void Appear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentSpeed = MaxSpeed;
        CurrentState = State.Appear;
        MoveStartTime = Time.time;
    }

    public void Disappear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentSpeed = 0.0f;
        CurrentState = State.Disappear;
        MoveStartTime = Time.time;

    }
    
    
    void UpdateBattle()
    {
        if (Time.time - BattleStartTime > 3.0f)
        {
            Disappear(new Vector3(-15.0f,transform.position.y,transform.position.z));
        }
   
    }

    
}
