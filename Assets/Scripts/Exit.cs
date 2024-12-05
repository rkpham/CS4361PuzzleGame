using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class Exit : MonoBehaviour
{
    private int NumButtonsActivated = 0;

    [SerializeField] private int RequiredButtons = 1;

    private bool ExitAllowed = false;
    private ParticleSystem.EmissionModule emissionModule;
    private AudioSource audioSource;

    [SerializeField] private AudioClip activationSound;
    [SerializeField] private AudioClip deactivationSound;

    private void Awake()
    {
        var em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

        if (particleSystem != null)
        {
            emissionModule = particleSystem.emission;
            emissionModule.enabled = false;
        }
        else
        {
            Debug.LogWarning("Exit: No ParticleSystem found.");
        }

        if (audioSource == null)
        {
            Debug.LogError("Exit: No AudioSource component found.");
        }
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
            ScoreManager.Instance.addScore(10);
            LevelManager.LoadNextLevel();
        }
    }
    private void ButtonActivated()
    {
        NumButtonsActivated += 1;

        if (NumButtonsActivated >= RequiredButtons)
        {
            ExitAllowed = true;

            var em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
            PlaySound(activationSound);
        }
    }
    private void ButtonDeactivated()
    {
        NumButtonsActivated -= 1;

        if (NumButtonsActivated < RequiredButtons)
        {
            ExitAllowed = false;

            var em = GetComponent<ParticleSystem>().emission;
            em.enabled = false;
            PlaySound(deactivationSound);
        }
    }
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void OnDestroy()
    {
        EventManager.onButtonActivated -= ButtonActivated;
        EventManager.onButtonDeactivated -= ButtonDeactivated;
    }

    private void OnDisable()
    {
        EventManager.onButtonActivated -= ButtonActivated;
        EventManager.onButtonDeactivated -= ButtonDeactivated;
    }
}
