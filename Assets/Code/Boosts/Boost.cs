using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    public abstract void MakeBoost(IBoostHandler handler);

    protected void CreateEffect(GameObject effect)
    {
        effect = Instantiate(effect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().Play();
    }
}
