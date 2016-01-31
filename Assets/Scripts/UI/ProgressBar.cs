using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    private RectTransform rect;
    [SerializeField]
    private Camera camToUse;
    [SerializeField]
    private Capturable cap;
    [SerializeField]
    private Image lowerBar;
    [SerializeField]
    private Image barTeam1;
    [SerializeField]
    private Image barTeam2;
    private Canvas canvas;

    public void Init(Capturable _cap)
    {
        cap = _cap;
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvas = transform.parent.GetComponentInParent<Canvas>();
        camToUse = canvas.worldCamera;
        SetLocation();
    }

    void FixedUpdate()
    {
        SetLocation();
    }

    void SetLocation()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, camToUse.WorldToScreenPoint(cap.transform.position), canvas.worldCamera, out pos);
        transform.position = canvas.transform.TransformPoint(pos);
        //rect.anchoredPosition += new Vector2(0, 50);

        float capturePoints = cap.CapturePoints();
        float captureTrigger = cap.CaptureTrigger();

        if (capturePoints > 0)
        {
            barTeam1.fillAmount = 0;
            barTeam2.fillAmount = capturePoints / captureTrigger;
            lowerBar.fillAmount = 1 - barTeam2.fillAmount;
        }
        else if (capturePoints < 0)
        {
            barTeam2.fillAmount = 0;
            barTeam1.fillAmount = -capturePoints / captureTrigger;
            lowerBar.fillAmount = 1 - barTeam1.fillAmount;
        }
        else
        {
            barTeam1.fillAmount = 0;
            barTeam2.fillAmount = 0;
            lowerBar.fillAmount = 1;
        }
    }
}

