using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkingPanel : MonoBehaviour
{
    [SerializeField] private Button StartAsClientButton;
    [SerializeField] private Button StartAsHostButton;
    [SerializeField] private Button StartAsServerButton;


    

    private void Awake()
    {
        StartAsClientButton.onClick.AddListener(OnClick_StartAsClientButton);
        StartAsHostButton.onClick.AddListener(OnClick_StartAsHostButton);
        StartAsServerButton.onClick.AddListener(OnClick_StartAsServerButton);



    }

    public void OnClick_StartAsServerButton()
    {
       NetworkManager.Singleton.StartServer();

    }

    public void OnClick_StartAsClientButton()
    {

       NetworkManager.Singleton.StartClient();
       
        

    }
    public void OnClick_StartAsHostButton()
    {
        NetworkManager.Singleton.StartHost();



    }




}
