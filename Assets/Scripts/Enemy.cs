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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSpeed()
    {
        
    }

    void UpdateMove()
    {
        
    }

    void Arrived()
    {
        
    }

    public void Apear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentSpeed = MaxSpeed;
        CurrentState = State.Appear;
    }

    public void Disappear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentSpeed = MaxSpeed; 
        CurrentState = State.Disappear;

    }
    
    
    
}
