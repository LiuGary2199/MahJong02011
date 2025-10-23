using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mkey;
public class AxeEvening : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyItem")]    public GameObject AxeHigh;
    public static AxeEvening Instance;
[UnityEngine.Serialization.FormerlySerializedAs("isOpenFly")]
    public bool ItYorkAxe;
[UnityEngine.Serialization.FormerlySerializedAs("leftOrRight")]    public int GushOrBloom;

    private int _InferYorkSlit;
    private int _DotBatSlit;
    
    private void Awake()
    {
        Instance = this;
        _DotBatSlit = 0;
        ItYorkAxe = true;
        _InferYorkSlit = CryBustPeg.instance.LullSoul.bubble_cd;
        GushOrBloom = 0;
    }

    private void OnEnable()
    {
        YorkIEAxe();
    }
   
    public void YorkIEAxe()
    {
        StopCoroutine(nameof(YorkAxeDating));
        StartCoroutine(nameof(YorkAxeDating));
    }
    IEnumerator YorkAxeDating()
    {
        while (ItYorkAxe)
        {   
            if (_DotBatSlit >= _InferYorkSlit)
            {
                LiableAxeHigh();
            }
            _DotBatSlit++;
            yield return new WaitForSeconds(1);
        }
    }

    public void RecordAxeHigh()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<FlyItem>().OceaniaAxeHigh();
            ItYorkAxe = true;
        }
    }

    public void LiableAxeHigh()
    {
        if (!ItYorkAxe) { return; }
        // 新增：引导阶段禁止飞行气泡
        if (LullDeltaMisery.PrecedeDelta <= 1)
        {
            return;
        }
        //if (BubbleManager.GetInstance().IsWinGame()) { return; }
        //  if ( LevelManager.GetInstance().CurLevel > 1 && !WinterErie.IsApple
      if ( !WinterErie.IDFluke())
        {
            ItYorkAxe = false;
            _DotBatSlit = 0;
            GameObject obj = Instantiate(AxeHigh.gameObject);
            obj.transform.SetParent(transform);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = GushOrBloom == 0 ? new Vector3(-650, 0, 0) : new Vector3(650, 0, 0);
        }
    }

    //public void SendFlyCollider(BubbleItem bubble)
    //{
    //    KeyValuesUpdate key = new KeyValuesUpdate(StringConst.SendFlyCollider, bubble);
    //    OutdoorLegend.SendMessage(StringConst.SendFlyCollider, key);
    //}
}
