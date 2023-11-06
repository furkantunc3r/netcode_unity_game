using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerUI : NetworkBehaviour
{
    [SerializeField] RectTransform healthUI;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (!IsOwner) return;

        healthUI.rotation = Quaternion.LookRotation(healthUI.position - _cam.transform.position);
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
    }
}
