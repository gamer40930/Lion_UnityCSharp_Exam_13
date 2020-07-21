using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource winMusic;
    public Runner a;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("MIN").GetComponent<Runner>();
        winMusic = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "MIN")
        {
            winMusic.Play();
            print("gole");
        }
    }



}
