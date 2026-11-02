using UnityEngine;

public class SSocketChange : MonoBehaviour
{
    private SPuzzleBlock puzzle;

    [SerializeField] private int socketNumber;

    private void Start()
    {
        puzzle = GetComponentInParent<SPuzzleBlock>(); //Is Parent since the SPuzzleBlock is on the parent of the sockets
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
