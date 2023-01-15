using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlocksRow : MonoBehaviour
{
    public bool check;
    public List<float> blocksHeight = new List<float>();
    public float delay;

    public int blocksInRow;
    public GameObject[] caughtBlocks;
    public LayerMask layerMask;

    RaycastHit[] hittedBlocks;

    void Update()
    {
        if (check)
        {
            if (blocksHeight.Count < 1) check = false;
            blocksHeight.Sort();

            StartCoroutine("Delay");
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

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < blocksHeight.Count; i++)
        {
            if (SendLaser(blocksHeight[i])) CheckBlocks();
        }
    }
}
