using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] RectTransform healthUI;

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
