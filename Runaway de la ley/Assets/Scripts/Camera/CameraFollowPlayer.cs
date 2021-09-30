using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float cameraPostionZ;
    [SerializeField]
    private float cameraOffsetX;
    [SerializeField]
    private float cameraOffsetY;
    [SerializeField]
    private float speedToMoveCamera;
    [SerializeField]
    private float delayToMoveCamera;

    private float xAcumulada = 0;


    private CharacterController characterController;
    void Start()
    {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
        transform.position = new Vector3(player.transform.position.x + cameraOffsetX, player.transform.position.y + cameraOffsetY, -cameraPostionZ); ;
    }

    void Update()
    {
        changeCameraPositon();
    }

    void changeCameraPositon()
    {

        float cameraMovemetX = 0;
        if (characterController.playerDirection > 0 && xAcumulada < cameraOffsetX)
        {
            cameraMovemetX += speedToMoveCamera;
        }
        else if (characterController.playerDirection < 0 && xAcumulada > -1f*cameraOffsetX)
        {
            cameraMovemetX -= speedToMoveCamera;
            
        }
        cameraMovemetX *= Time.deltaTime;
        xAcumulada += cameraMovemetX;

        if (characterController.isPlayerJumping)
        {
            transform.position = new Vector3(player.transform.position.x + xAcumulada, gameObject.transform.position.y, -cameraPostionZ);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x + xAcumulada, player.transform.position.y + cameraOffsetY, -cameraPostionZ);
        }

    }


}
