using UnityEngine.Audio;
using UnityEngine;

public class NameAudioManager : MonoBehaviour
{
    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayDelayed(2.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
