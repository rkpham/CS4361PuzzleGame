using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool pressed = false;

    [SerializeField] private Light ButtonLight;
    [SerializeField] private GameObject ButtonPress;
    [SerializeField] private Material PressedMaterial;
    [SerializeField] private Material InactiveMaterial;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Box")
        {
            if (!pressed)
            {
                pressed = true;
                EventManager.RaiseOnButtonActivated();
            }
            ButtonLight.enabled = true;
            ButtonPress.GetComponent<Renderer>().material = PressedMaterial;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Box")
        {
            if (pressed)
            {
                pressed = false;
                EventManager.RaiseOnButtonDeactivated();
            }
            ButtonLight.enabled = false;
            ButtonPress.GetComponent<Renderer>().material = InactiveMaterial;
        }
    }
}
