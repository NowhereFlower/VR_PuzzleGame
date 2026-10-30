using UnityEngine;

public class SPuzzleBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] shapesPrefab;
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    [SerializeField] private GameObject Wronglight1;
    [SerializeField] private GameObject Wronglight2;
    [SerializeField] private GameObject Wrongight3;
    [SerializeField] private GameObject Correctlight1;
    [SerializeField] private GameObject Correctlight2;
    [SerializeField] private GameObject Correctlight3;
    [SerializeField] private GameObject socket;
    [SerializeField] private GameObject socket2;
    [SerializeField] private GameObject socket3;
    [SerializeField] private Transform[] spawnPoint4;
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
        for(int i = 0; i < shapesPrefab.Length; i++)
        {
            int ran = Random.Range(0, shapesPrefab.Length);
            if(i == 0)
            {
                Instantiate(shapesPrefab[ran], spawnPoint4[i].position, spawnPoint4[i].rotation).tag = "block1";
            }
            else if (i == 1)
            {
                Instantiate(shapesPrefab[ran], spawnPoint4[i].position, spawnPoint4[i].rotation).tag = "block2";
            }
            else if (i == 2)
            {
                Instantiate(shapesPrefab[ran], spawnPoint4[i].position, spawnPoint4[i].rotation).tag = "block3";
            }
            else
            {
                Instantiate(shapesPrefab[ran], spawnPoint4[i].position, spawnPoint4[i].rotation);
            }
        }
    }

    public void UpdateSocket(int socketNumber, Collider other, bool isEntered)
    {
        int change = isEntered ? 1 : -1;

        if(socketNumber == 1 && other.CompareTag("block1"))
        {
            blockCounter1 = Mathf.Max(0, blockCounter1 + change);
            if(change == 1)
            {
                light1.SetActive(false);
                Wronglight1.SetActive(false);
                Correctlight1.SetActive(true);
            }
            else
            {
                light1.SetActive(false);
                Wronglight1.SetActive(true);
                Correctlight1.SetActive(false);
            }
        }
        else if (socketNumber == 2 && other.CompareTag("block2"))
        {
            blockCounter2 = Mathf.Max(0, blockCounter2 + change);
        }
        else if (socketNumber == 3 && other.CompareTag("block3"))
        {
            blockCounter3 = Mathf.Max(0, blockCounter3 + change);
        }

        blockCounterTotal = blockCounter1 + blockCounter2 + blockCounter3;

    }
}
