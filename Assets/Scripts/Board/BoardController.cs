using System.Linq;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public bool spawnBlock;

    public GameObject[] allBlockTypes;
    public int[] restOfBlocks;
    public Transform placeToSpawn;

    void Update()
    {
        if (spawnBlock) SpawnBlock();
    }

    void SpawnBlock()
    {
        if (restOfBlocks.Length == 0) Fill();

        int randomNumber = Random.Range(0, restOfBlocks.Length);

        Instantiate(allBlockTypes[restOfBlocks[randomNumber]], placeToSpawn.position, Quaternion.identity);
        restOfBlocks = restOfBlocks.Except(new int[] { restOfBlocks[randomNumber] }).ToArray();
        spawnBlock = false;
    }

    void Fill()
    {
        restOfBlocks = new int[allBlockTypes.Length];

        for (int i = 0; i < restOfBlocks.Length; i++)
        {
            restOfBlocks[i] = i;
        }
    }
}