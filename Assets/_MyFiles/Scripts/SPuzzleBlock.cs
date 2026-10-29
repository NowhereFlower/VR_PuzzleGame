using UnityEngine;

public class SPuzzleBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] shapePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private int blockCounter1 = 0;
    [SerializeField] private int blockCounter2 = 0;
    [SerializeField] private int blockCounter3 = 0;
    [SerializeField] private int blockCounterTotal = 0;


    private void Awake()
    {
        RandomShape();
    }

    private void RandomShape()
    {
        int index = Random.Range(0, shapePrefab.Length);
        int index2 = Random.Range(0, shapePrefab.Length);
        int index3 = Random.Range(0, shapePrefab.Length);
        Instantiate(shapePrefab[index], spawnPoint.position, spawnPoint.rotation);
        Instantiate(shapePrefab[index2], spawnPoint2.position, spawnPoint2.rotation);
        Instantiate(shapePrefab[index3], spawnPoint3.position, spawnPoint3.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("block1"))
        {
            blockCounter1++;
        }
        if (other.CompareTag("block2"))
        {
            blockCounter2++;
        }
        if (other.CompareTag("block3"))
        {
            blockCounter3++;
        }
        blockCounterTotal = blockCounter1 + blockCounter2 + blockCounter3;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("block1"))
        {
            blockCounter1--;
        }
        if (other.CompareTag("block2"))
        {
            blockCounter2--;
        }
        if (other.CompareTag("block3"))
        {
            blockCounter3--;
        }
        blockCounterTotal = blockCounter1 + blockCounter2 + blockCounter3;
    }
}
