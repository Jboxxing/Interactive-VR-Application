using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeleportPlayer : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    /*
    public Transform controller;
    Ray ray;
    RaycastHit hit;
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // https://github.com/Kinshuk23/Teleport_Controller-Daydream/blob/main/Assets/Scripts/Teleport.cs
    // https://developers.google.com/vr/reference/unity/class/GvrControllerInput
    // https://developers.google.com/vr/reference/unity/class/GvrControllerInputDevice
    void Update()
    {
        /*
        if (GvrControllerInput.ClickButtonDown)
        {
            // ray = new Ray(camera.transform.position, camera.forward);
            ray = new Ray(controller.transform.position, controller.forward);
            Debug.DrawRay(controller.transform.position, controller.forward, Color.green, 1);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.transform.CompareTag("Teleport"))
                {
                    player.transform.position = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
                }
            }
        }
        */
    }

    // https://www.informit.com/articles/article.aspx?p=2931573&seqNum=2
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 worldPos = eventData.pointerCurrentRaycast.worldPosition;
        Vector3 playerPos = new Vector3(worldPos.x, player.transform.position.y, worldPos.z);
        player.transform.position = playerPos;
    }
}
