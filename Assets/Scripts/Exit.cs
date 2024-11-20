using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Exit : MonoBehaviour
{
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
            Debug.Log("Finished level");
        }
    }
    private void ButtonActivated()
    {
        if (LevelManager.NumButtonsActivated >= RequiredButtons)
        {
            ExitAllowed = true;

            var em = ExitParticles.emission;
            em.enabled = true;
        }
    }
    private void ButtonDeactivated()
    {
        if (LevelManager.NumButtonsActivated < RequiredButtons)
        {
            ExitAllowed = false;

            var em = ExitParticles.emission;
            em.enabled = false;
        }
    }
}
