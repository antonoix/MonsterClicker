using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private List<Light> _lights;

    public void ActivateLight(Vector3 pos)
    {
        Light lightToActivate = null;
        float minDistance = float.MaxValue;
        foreach (var light in _lights)
        {
            var distance = (pos - light.transform.position).magnitude;
            if (distance < minDistance)
            {
                lightToActivate = light;
                minDistance = distance;
            }
        }
        StartCoroutine(ActivateLight(lightToActivate));
    }

    private IEnumerator ActivateLight(Light light)
    {
        Color deafault = light.color;
        light.color = Color.red;
        yield return new WaitForSeconds(1);
        light.color = deafault;
    }
}
