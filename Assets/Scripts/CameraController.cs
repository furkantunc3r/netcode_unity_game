using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;


    private Transform CameraTransform;

    private Vector3 offSetPos;

    [SerializeField]
    private float CameraMoveSpeed=.5f;
    private void Awake()
    {
        CameraTransform= GetComponent<Transform>();
        offSetPos=CameraTransform.position;
    }
    private void LateUpdate()
    {
        CameraTransform.position = Vector3.Lerp(CameraTransform.position,
                    offSetPos + new Vector3(PlayerObject.transform.position.x, 0, PlayerObject.transform.position.z),
                    Time.deltaTime * CameraMoveSpeed);

        //CameraTransform.position = offSetPos + new Vector3(PlayerObject.transform.position.x, 0 , PlayerObject.transform.position.z);
    }


}
