using UnityEngine;

public class SWireCutter : MonoBehaviour
{
    public SBomb bomb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wire"))
        {
            SWire wire = other.GetComponent<SWire>();
            if (wire != null && bomb != null)
            {
                bomb.CutWire(wire.wireIndex);
                other.gameObject.SetActive(false);
            }
        }
    }
}
