using System.Collections.Generic;
using UnityEngine;

public class CheckBlocksRow : MonoBehaviour
{
    public bool check;
    public List<float> blocksHeight = new List<float>();

    public int blocksInRow;
    public GameObject[] caughtBlocks;
    public LayerMask layerMask;

    RaycastHit[] hittedBlocks;

    void Update()
    {
        if (check)
        {
            blocksHeight.Sort();
            print(blocksHeight[0]);

            for (int i = 0; i < blocksHeight.Count; i++)
            {
                if (SendLaser(blocksHeight[i])) CheckBlocks();
            }
        }
    }

    bool SendLaser(float heightToCheck)
    {
        RaycastHit[] hits = Physics.RaycastAll(new Vector2(-5.78f, heightToCheck), transform.TransformDirection(Vector3.right), Mathf.Infinity, layerMask);
        blocksInRow = hits.Length;

        if (blocksInRow >= 1)
        {
            hittedBlocks = hits;
            return true;
        }
        else
        {
            check = false;
            return false;
        }
    }

    void CheckBlocks()
    {
        caughtBlocks = new GameObject[0];
        caughtBlocks = new GameObject[hittedBlocks.Length];

        for (int i = 0; i < caughtBlocks.Length; i++)
        {
            caughtBlocks[i] = hittedBlocks[i].transform.gameObject;
        }

        if (caughtBlocks.Length == 10) print("Full row: " + caughtBlocks[0].transform.position.y);

        check = false;
    }
}
