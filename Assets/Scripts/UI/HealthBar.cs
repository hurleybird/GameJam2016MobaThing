﻿using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private RectTransform rect;
    [SerializeField]
    private Camera camToUse;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Image lowerBar;
    [SerializeField]
    private Image bar;
    private Canvas canvas;

    public void Init(Health _health)
    {
        health = _health;
    }

	void Start () {
        rect = GetComponent<RectTransform>();
        canvas = transform.parent.GetComponentInParent<Canvas>();
        camToUse = canvas.worldCamera;
        SetLocation();
    }
	
	void FixedUpdate  () {

        if (health == null)
        {
            Destroy(gameObject);
            return;
        }
        else if (!health.gameObject.activeInHierarchy)
            rect.anchoredPosition = new Vector2(1000, 1000);
        else
            SetLocation();
    }

    void SetLocation()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, camToUse.WorldToScreenPoint(health.transform.position), canvas.worldCamera, out pos);
        transform.position = canvas.transform.TransformPoint(pos);
        rect.anchoredPosition += new Vector2(0, 50);

        bar.fillAmount = health.CurrentHealth() / health.MaxHealth();
        lowerBar.fillAmount = 1 - bar.fillAmount;
    }
}
