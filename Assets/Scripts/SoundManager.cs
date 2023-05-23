using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    public AudioSource ControlAudio { get => controlAudio; set => controlAudio = value; }

    private void Awake()
    {
        ControlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionAudios(int indice, float Volumen)
    {
        ControlAudio.PlayOneShot(audios[indice], Volumen);
    }
}
