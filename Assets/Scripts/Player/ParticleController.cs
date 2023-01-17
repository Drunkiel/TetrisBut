using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject runParticle;

    public void RotateParticle(int rotationX)
    {
        runParticle.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f * rotationX); 
    }
}
