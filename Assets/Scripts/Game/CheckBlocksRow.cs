using UnityEngine;

public class CheckBlocksRow : MonoBehaviour
{
    public int blocksInRow;
    public LayerMask layerMask;

    public void CheckBlocks(int heightToCheck)
    {
        blocksInRow = 0;
        RaycastHit[] hit = Physics.RaycastAll(new Vector3(transform.position.x, heightToCheck * 1.056f, transform.position.z), transform.TransformDirection(Vector3.right), 100f, layerMask);
        blocksInRow = hit.Length;
    }
}
