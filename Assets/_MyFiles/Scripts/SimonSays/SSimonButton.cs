using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SimonButton : MonoBehaviour
{
    [SerializeField] private SSimonSays simon;
    [SerializeField] private int buttonIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        { 
            simon.ButtonPressed(buttonIndex);
            Debug.Log("WHYYYYYYYY");
        }
    }
}
