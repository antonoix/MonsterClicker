using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayBoostCollect()
    {
        PlaySound(Resources.Load("Sounds/Boost") as AudioClip);
    }

    public void PlayLose()
    {
        PlaySound(Resources.Load("Sounds/Lose") as AudioClip);
    }

    private void PlaySound(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }
}
