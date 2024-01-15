using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{

    public void DamageSound(AudioSource damageSound)
    {
        damageSound.Play();
    }
    public void GameOverSound(AudioSource gameOverSound)
    {
        gameOverSound.Play();
    }
    public void GemSound(AudioSource gemSound)
    {
        gemSound.Play();
    }
    public void PuffSound(AudioSource puffSound)
    {
        puffSound.Play();
    }
}
