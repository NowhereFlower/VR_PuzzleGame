using UnityEngine;

public class SPuzzleBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] shapesPrefab;
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    [SerializeField] private GameObject Wronglight1;
    [SerializeField] private GameObject Wronglight2;
    [SerializeField] private GameObject WrongLight3;
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

    //Puts random Shapes around the table and 3 blocks has the tags for the sockets
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
                Instantiate(shapesPrefab[ran], spawnPoint4[i].position, spawnPoint4[i].rotation).tag = "block";
            }
        }
    }

    //Checks if tags for the sockets are correct or not
    public void UpdateSocket(int socketNumber, Collider other, bool isEntered)
    {
        int change = isEntered ? 1 : -1;

        if(socketNumber == 1 && other.CompareTag("block1"))
        {
            blockCounter1 = Mathf.Max(0, blockCounter1 + change);
            Wronglight1.SetActive(false);
            light1.SetActive(false);
            Correctlight1.SetActive(true);
        }
        else if (socketNumber == 2 && other.CompareTag("block2"))
        {
            blockCounter2 = Mathf.Max(0, blockCounter2 + change);
            Wronglight2.SetActive(false);
            light2.SetActive(false);
            Correctlight2.SetActive(true);
        }
        else if (socketNumber == 3 && other.CompareTag("block3"))
        {
            blockCounter3 = Mathf.Max(0, blockCounter3 + change);
            WrongLight3.SetActive(false);
            light3.SetActive(false);
            Correctlight3.SetActive(true);
        }
        if (socketNumber == 1 && other.CompareTag("block"))
        {
            blockCounter1 = Mathf.Max(0, blockCounter1 + change);
            Wronglight1.SetActive(true);
            light1.SetActive(false);
            Correctlight1.SetActive(false);
        }
        if (socketNumber == 2 && other.CompareTag("block"))
        {
            blockCounter1 = Mathf.Max(0, blockCounter1 + change);
            Wronglight2.SetActive(true);
            light2.SetActive(false);
            Correctlight2.SetActive(false);
        }
        if (socketNumber == 3 && other.CompareTag("block"))
        {
            blockCounter1 = Mathf.Max(0, blockCounter1 + change);
            WrongLight3.SetActive(true);
            light3.SetActive(false);
            Correctlight3.SetActive(false);
        }

        blockCounterTotal = blockCounter1 + blockCounter2 + blockCounter3;

    }
}
