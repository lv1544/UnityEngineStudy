
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll;
    public float Speed;
    public float OffsetX;
}


public class BGScroller : MonoBehaviour
{
[SerializeField] 
BGScrollData[] ScrollDatas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScroll();
    }

    void UpdateScroll()
    {
        // foreach (var scrollData in ScrollDatas)
        // {
        //     scrollData.Offeset += scrollData.Speed * Time.deltaTime;
        //     scrollData.RenderForScroll.material.mainTextureOffset = new Vector2(0, scrollData.Offeset);
        // }


        for(int i = 0; i < ScrollDatas.Length; i++)
        {
           SetTextureOffset(ScrollDatas[i]);
        }
    }

    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime;
        if(scrollData.OffsetX > 1)
        scrollData.OffsetX = scrollData.OffsetX % 1.0f;


        Vector2 Offset = new Vector2(scrollData.OffsetX,0);
        scrollData.RenderForScroll.material.SetTextureOffset("_MainTex",Offset);
    }


}
