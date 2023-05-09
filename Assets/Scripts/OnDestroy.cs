using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    public AudioClip wav;

    void Start()
    {
    }

    void OnTriggerEnter(Collider collision)
    {
        AudioSource.PlayClipAtPoint(wav, gameObject.transform.position);
        Destroy(gameObject);
    }

}
