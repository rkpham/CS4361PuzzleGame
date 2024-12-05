using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    private bool pressed = false;
    private AudioSource buttonAudio;

    [SerializeField] private Light ButtonLight;
    [SerializeField] private GameObject ButtonPress;
    [SerializeField] private Material PressedMaterial;
    [SerializeField] private Material InactiveMaterial;

    private void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
    }

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
            ScoreManager.Instance.addScore(20);
            if (buttonAudio) buttonAudio.Play();
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
            ScoreManager.Instance.addScore(-20);
        }
    }

private void ToggleButtonState(bool isActive)
    {
        ButtonLight.enabled = isActive;
        ButtonPress.GetComponent<Renderer>().material = isActive ? PressedMaterial : InactiveMaterial;
    }
}
