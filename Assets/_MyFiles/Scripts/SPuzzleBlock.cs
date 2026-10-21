using UnityEngine;

public class SPuzzleBlock : MonoBehaviour
{
    [SerializeField] private int blockCounter1 = 0;
    [SerializeField] private int blockCounter2 = 0;
    [SerializeField] private int blockCounter3 = 0;
    [SerializeField] private int blockCounterTotal = 0;
    
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
