using UnityEngine;

public class MapConfig : MonoBehaviour
{
    private const float _width = 10;
    private const float _height = 10;

    public static Vector3 GetRandomPointInside()
    {
        var xPos = Random.Range(-_width, _width);
        var zPos = Random.Range(-_height, _height);
        return new Vector3(xPos, 0, zPos);
    }

    public static Vector3 GetRandomPointOutside(float distance = 5)
    {
        int directionX = Random.Range(0, 2) == 0 ? 1 : -1;
        var xPos = Random.Range((_width + distance) * directionX, _width * directionX);
        int directionZ = Random.Range(0, 2) == 0 ? 1 : -1;
        var zPos = Random.Range((_height + distance) * directionZ, _height * directionZ);

        return new Vector3(xPos, 0, zPos);
    }
}
