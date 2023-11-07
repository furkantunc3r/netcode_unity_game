using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : NetworkBehaviour
{
    [SerializeField] RectTransform healthUI;

    [SerializeField] RectTransform healthCanvas;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;

        if (GetComponent<NetworkedHealth>()._health.Value <= 80)
            healthUI.GetChild(0).GetComponent<Image>().color = Color.yellow;
        else if (GetComponent<NetworkedHealth>()._health.Value <= 40)
            healthUI.GetChild(0).GetComponent<Image>().color = Color.red;
    }

    private void Update()
    {
        healthCanvas.transform.rotation = _cam.transform.rotation;
    }

    private void OnEnable()
    {
        GetComponent<NetworkedHealth>()._health.OnValueChanged += healthChanged;
    }
    private void OnDisable()
    {
        GetComponent<NetworkedHealth>()._health.OnValueChanged -= healthChanged;
    }

    private void healthChanged(int previousValue, int newValue)
    {
        healthUI.transform.localScale = new Vector3(newValue / 100f, 1, 1);
        
        if (newValue <= 80)
            healthUI.GetChild(0).GetComponent<Image>().color = Color.yellow;
        else if (newValue <= 40)
            healthUI.GetChild(0).GetComponent<Image>().color = Color.red;
    }
}
