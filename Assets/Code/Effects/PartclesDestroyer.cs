using UnityEngine;

public class PartclesDestroyer : MonoBehaviour
{
    private void Start()
    {
        var particle = GetComponent<ParticleSystem>();
        Destroy(gameObject, particle.main.duration);
    }
}
