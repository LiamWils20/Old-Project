using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource audioSource1;

    private List<AudioSource> audioClips = new List<AudioSource>();

    public float timeBetweenShots = 0.25f;
    float timer;

    private void Awake()
    {
        audioClips.Add(audioSource);
        audioClips.Add(audioSource1);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource1 = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource != enabled)
        {
            audioSource1.Play();
        }

        timer += Time.deltaTime;
        if (timer > timeBetweenShots)
        {
            Debug.Log("Timer:" + timer);
        }
    }

}
