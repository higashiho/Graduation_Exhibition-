using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioController : BaseAudio
    {
        // Start is called before the first frame update
        void Start()
        {
            if(audioSource != null)
            {
                Destroy(this.gameObject);
                return;
            }
            audioSource = this.GetComponent<AudioSource>();
            PlayerAoudio = this.transform.GetChild(0).GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            DontDestroyOnLoad(this);
        }
    }
}