using UnityEngine;

public class SSocketChange : MonoBehaviour
{
    private SPuzzleBlock puzzle;

    [SerializeField] private int socketNumber;

    private void Start()
    {
        puzzle = GetComponent<SPuzzleBlock>();
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzle.UpdateSocket(socketNumber, other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        puzzle.UpdateSocket(socketNumber, other, false);
    }
}
