using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class LoftOption : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Mildly_Lieu;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Option_Lieu;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Mat_Slit;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Option_Gallop;
    private void Awake()
    {
        if (Mat_Slit == RunTime.Awake)
        {
            CoarseEndear();
        }
    }
    private void Start()
    {
        if (Mat_Slit == RunTime.Start)
        {
            CoarseEndear();
        }
    }

    public void CoarseEndear()
    {
        if (Option_Lieu == LayoutType.Sprite_First_Weight)
        {
            if (Mildly_Lieu == TargetType.UGUI)
            {

                float Climb= Screen.width / Option_Gallop;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(Climb, Climb, Climb);
            }
        }
        if (Option_Lieu == LayoutType.Screen_First_Weight)
        {
            if (Mildly_Lieu == TargetType.Scene)
            {
                float Climb= HowDefineSoul.HowWhatever().EndRefugeMedia() / Option_Gallop;
                transform.localScale = transform.localScale * Climb;
            }
        }
        
        if (Option_Lieu == LayoutType.Bottom)
        {
            if (Mildly_Lieu == TargetType.Scene)
            {
                float screen_bottom_y = HowDefineSoul.HowWhatever().EndRefugeWeldon() / -2;
                screen_bottom_y += (Option_Gallop + (HowDefineSoul.HowWhatever().EndCorpseSalt(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
