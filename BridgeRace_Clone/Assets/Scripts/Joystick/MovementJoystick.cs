using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MovementJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector3 joystickVector;

    private Vector3 touchPos;
    private Vector3 originalPos;
    private float radius;
    private void Start()
    {
        originalPos = joystickBG.transform.position;
        radius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2;
    }
    public void PointerDown()
    {
        joystick.SetActive(true);
        joystickBG.SetActive(true);
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        touchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 dragPos = pointerEventData.position;
        joystickVector = (dragPos - touchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, touchPos);

        if (joystickDist < radius)
        {
            joystick.transform.position = touchPos + joystickVector * joystickDist;
        }
        else
        {
            joystick.transform.position = touchPos + joystickVector * radius;
        }
    }
    public void PointerUp()
    {
        joystickVector = Vector3.zero;
        joystick.transform.position = originalPos;
        joystickBG.transform.position = originalPos;
        joystick.SetActive(false);
        joystickBG.SetActive(false);
    }
}
