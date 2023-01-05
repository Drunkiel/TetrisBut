using UnityEngine;

public class BlockController : MonoBehaviour
{
    public void SetBlocksToBoard()
    {
        GameObject board = GameObject.FindGameObjectWithTag("Board");
        Transform boardTransform = board.transform.GetChild(4).transform;
        Transform[] blocks = new Transform[transform.childCount];

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = transform.GetChild(i).GetComponent<Transform>();
        }

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].name != "Center")
            {
                blocks[i].parent = boardTransform;
                board.GetComponentInChildren<SetHighestPoint>().CheckHighestPoint(Mathf.FloorToInt(blocks[i].position.y));
            }

        }
    }

    public void AutoDestroy(bool destroyAll)
    {
        //Destroying parts to avoid bugs
        if (TryGetComponent<BlockRotation>(out BlockRotation _blockRotation)) Destroy(_blockRotation);
        else if (TryGetComponent<NonStandardBlockRotation>(out NonStandardBlockRotation _nonStandardBlockRotation)) Destroy(_nonStandardBlockRotation);
        Destroy(GetComponent<BlockMovement>());

        if (destroyAll)
        {
            //Spawning next block
            BoardController board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardController>();
            board.spawnBlock = true;

            //Final destroy
            Destroy(gameObject);
        }
    }
}
