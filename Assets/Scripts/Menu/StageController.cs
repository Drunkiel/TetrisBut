using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject[] allBlocks;
    public int currentBlock;
    public Transform placeToSpawn;

    void Start()
    {
        int randomNumber = Random.Range(0, allBlocks.Length);

        SpawnBlock(randomNumber);
    }

    void SpawnBlock(int number)
    {
        Destroy(GameObject.FindGameObjectWithTag("FallingBlock"));

        Instantiate(allBlocks[number], placeToSpawn.position, Quaternion.identity, transform);
    }

    public void ChangeBlock(int value)
    {
        int newBlockValue = currentBlock + value;

        if (newBlockValue < 0)
        {
            newBlockValue -= value;
            newBlockValue += allBlocks.Length - 1;
        }
        else if (newBlockValue >= allBlocks.Length)
        {
            newBlockValue -= value;
            newBlockValue -= allBlocks.Length - 1;
        }

        currentBlock = newBlockValue;
        SpawnBlock(newBlockValue);
    }
}
