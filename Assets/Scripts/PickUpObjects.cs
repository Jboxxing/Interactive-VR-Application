using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// https://www.informit.com/articles/article.aspx?p=2931573&seqNum=2
public class PickUpObjects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject controller;
    private bool pointerIsDown;

    // Start is called before the first frame update
    void Start()
    {
        pointerIsDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerIsDown)
        {
            Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;
            Vector3 controllerDirect = pointerTransform.rotation * Vector3.forward;
            Ray ray = new Ray(pointerTransform.position, controllerDirect);
            Vector3 newPos = ray.GetPoint(Vector3.Distance(transform.position, pointerTransform.position));
            if (newPos.y < 0)
                newPos.y = 0;
            transform.position = newPos;
            // Boundaries for plane (ground): x = [-105, 110] units, z = [-110, 105] units
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pointerIsDown = false;
                Vector3 randomPos = new Vector3(Random.Range(-105.0f, 110.0f), transform.position.y, Random.Range(-110.0f, 105.0f));
                transform.position = randomPos;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerIsDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerIsDown = false;
    }
}
