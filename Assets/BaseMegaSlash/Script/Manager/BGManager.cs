// Project  Repository-BaseA
// FileName  BGManager.cs
// Author  AX
// Desc
// CreateAt  2025-09-04 16:09:20 
//


using UnityEngine;

public class BGManager : MonoBehaviour
{
    public static BGManager Instance;

    public Transform[] backgroundPanels;
    public float scrollSpeed = 2f;

    public float panelWidth = 10f;
    public bool autoDetectHeight = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        if (autoDetectHeight && backgroundPanels.Length > 0)
        {
            RectTransform rect = backgroundPanels[0].GetComponent<RectTransform>();
            if (rect != null)
            {
                panelWidth = rect.rect.width;
            }
            else
            {
                panelWidth = 1080;
            }
        }

        for (int i = 0; i < backgroundPanels.Length; i++)
        {
            backgroundPanels[i].localPosition = new Vector3(
                transform.localPosition.x + panelWidth * i,
                transform.localPosition.y,
                transform.localPosition.z
            );
        }
    }


    void Update()
    {
        
        foreach (Transform img in backgroundPanels)
        {
            img.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
            
            if (img.transform.localPosition.x < -panelWidth)
            {
                Vector3 newPos = img.transform.localPosition;
                newPos.x += backgroundPanels.Length * panelWidth;
                img.transform.localPosition = newPos;
            }
        }
     
    }

    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }

    public void PauseScrolling(bool pause)
    {
        this.enabled = !pause;
    }

    public void SlowScrolling(bool isShow)
    {
        scrollSpeed = isShow ? 0.2f : 2f;
    }
}