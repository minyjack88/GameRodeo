using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceSoundScript : MonoBehaviour {

    public GameObject SoundSoucre;
    public float rottaionSpeed = 2;
    public AudioClip[] ClipToUse;

    public float maxApperInterval = 10;
    public float minApperInterval = 5;

    private float ApperensTimer;
    private AudioSource aSource;

    void Start()
    {
        aSource = SoundSoucre.GetComponent<AudioSource>();
        ApperensTimer = Random.Range(minApperInterval,maxApperInterval);
    }


    void Update()
    {
        if (ApperensTimer >= 0 && !aSource.isPlaying)
        {
            AudioClip clip = ClipToUse[Random.Range(0, ClipToUse.Length)];
            if (aSource.clip != clip)
            {
                aSource.clip = clip;
                aSource.Play();
                ApperensTimer = Random.Range(minApperInterval, maxApperInterval);
            }
        }
        else if(!aSource.isPlaying)
            ApperensTimer -= Time.deltaTime;


        transform.RotateAround(Vector3.zero, Vector3.forward, rottaionSpeed * Time.deltaTime);

    }

}
