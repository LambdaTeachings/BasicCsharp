#if UNITY_EDITOR

using UnityEngine;

public class CreateMinecraftWorld : MonoBehaviour
{
    public int height = 8;
    public int xyDimenstions = 50;
    public float Resolution = 1f;
    public float seed = 0;

    GameObject _container;

    private void Awake()
    {
        Generate();
    }

    [ContextMenu("Generate")]
    public void Generate()
    {
        if (_container != null)
        {
            Destroy(_container);
        }

        _container = new GameObject("minecraft");

        for (int i = 0; i < xyDimenstions; i++)
        {
            for (int j = 0; j < xyDimenstions; j++)
            {
                var perlinX = ((float)i / xyDimenstions + seed) * Resolution;
                var perlinY = ((float)j / xyDimenstions + seed) * Resolution;

                var noise = Mathf.PerlinNoise(perlinX, perlinY) * height;

                for (int k = 0; k < noise; k++)
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i, k, j);

                    cube.transform.SetParent(_container.transform);
                }
            }
        }
    }
}
#else
Console.WriteLine("You need to run this code inside Unity.");
#endif