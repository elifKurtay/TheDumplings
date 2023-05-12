using Oculus.Interaction;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerControllerWithHandPoses))]
public class PlayerLocomotionMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject locomotionMenu;

    // menuState
    [SerializeField]
    private InteractableUnityEventWrapper onLocomotionAction;

    private PlayerControllerWithHandPoses playerControllerWithHandPoses;

    private bool locomotionOn = true;

    private void Awake()
    {
        playerControllerWithHandPoses = GetComponent<PlayerControllerWithHandPoses>();
        Debug.Log("Locomotion menu is active");
    }

    public void LocomotionVisibility(bool state)
    {
        locomotionMenu.SetActive(state);
    }

    private void Update()
    {
        //locomotionMenu.transform.position = targetHand.transform.position + offsetFromHand;
        //locomotionMenu.transform.rotation = Quaternion.LookRotation(locomotionMenu.transform.position - cameraRig.centerEyeAnchor.transform.position, Vector3.up);
    }

    public void ToggleLocomotion() {
        locomotionOn = !locomotionOn;
        var locomotionMenuOption = onLocomotionAction.GetComponentInChildren<TextMeshPro>();
        var locomotionMenuState = locomotionOn ? "ON" : "OFF";
        locomotionMenuOption.text = $"LOCOMOTION {locomotionMenuState}";
        playerControllerWithHandPoses.EnableLinearMovement = locomotionOn;

        Debug.Log($"Locomotion state changed to: {locomotionMenuState}");
    }

}
    