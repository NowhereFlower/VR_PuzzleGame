using UnityEngine;
using UnityEngine.InputSystem;
public class SInputTest : MonoBehaviour
{
    //Testing hand inputs to see if the controllers are working
    public InputActionProperty testActionValue;
    public InputActionProperty testActionButton;

    private void Update()
    {
        float value = testActionValue.action.ReadValue<float>();
        //Debug.Log("Value : " + value);

        bool button = testActionButton.action.IsPressed();
        //Debug.Log("VaButtonue : " + button);
    }
}
