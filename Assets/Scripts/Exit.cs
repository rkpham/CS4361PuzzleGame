using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Exit : MonoBehaviour
{
    private int NumButtonsActivated = 0;

    [SerializeField] private int RequiredButtons = 1;
    [SerializeField] private ParticleSystem ExitParticles;

    private bool ExitAllowed = false;

    private void Awake()
    {
        var em = ExitParticles.emission;
        em.enabled = false;
    }

    private void OnEnable()
    {
        EventManager.onButtonActivated += ButtonActivated;
        EventManager.onButtonDeactivated += ButtonDeactivated;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && ExitAllowed)
        {
            LevelManager.LoadNextLevel();
        }
    }
    private void ButtonActivated()
    {
        NumButtonsActivated += 1;

        if (NumButtonsActivated >= RequiredButtons)
        {
            ExitAllowed = true;

            var em = ExitParticles.emission;
            em.enabled = true;
        }
    }
    private void ButtonDeactivated()
    {
        NumButtonsActivated -= 1;

        if (NumButtonsActivated < RequiredButtons)
        {
            ExitAllowed = false;

            var em = ExitParticles.emission;
            em.enabled = false;
        }
    }
}
