using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlocksRow : MonoBehaviour
{
    public bool check;
    public List<float> blocksHeight = new List<float>();
    private float lastCheckedLine;
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
            lastCheckedLine = heightToCheck;
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

        if (caughtBlocks.Length == 10)
        {
            //Adding points for getting line
            ScoreController.AddScore(40);
            ScoreController.pointsMultiplier += 1;
            ScoreController.timeBeforeReset += 5 + 3 * MainMenuController.pickedDifficulty;

            //Destroying blocks in line
            for (int i = 0; i < caughtBlocks.Length; i++)
            {
                Destroy(caughtBlocks[i]);
            }

            //Falling blocks from above
            GameObject[] restBlocks = GameObject.FindGameObjectsWithTag("Block");

            foreach (GameObject singleBlock in restBlocks)
            {
                singleBlock.transform.position = new Vector3(singleBlock.transform.position.x, singleBlock.transform.position.y - 1.056f, singleBlock.transform.position.z);
            }
        }

        check = false;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < blocksHeight.Count; i++)
        {
            if (lastCheckedLine != blocksHeight[i] && SendLaser(blocksHeight[i])) CheckBlocks();
        }
    }
}
