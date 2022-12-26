using UnityEngine;

public class ColorController : MonoBehaviour
{
    public MeshRenderer platform;

    public Material[] materials;

    public void ChangeColor(int i)
    {
        platform.material = materials[i];
    }
}
