using Oculus.Interaction;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerControllerWithHandPoses))]
public class PlayerLocomotionMenu : MonoBehaviour
{
    [SerializeField]
    private OVRCameraRig cameraRig;

    [SerializeField]
    private GameObject targetHand;

    [SerializeField]
    private GameObject locomotionMenu;

    [SerializeField]
    private Vector3 offsetFromHand = new Vector3(0.5f, 0.5f, 0.5f);

    private PlayerControllerWithHandPoses playerControllerWithHandPoses;

    // menuState
    [SerializeField]
    private InteractableUnityEventWrapper onLocomotionAction;
    private bool locomotionOn = true;

    private void Awake()
    {
        playerControllerWithHandPoses = GetComponent<PlayerControllerWithHandPoses>();
        Debug.Log("Locomotion menu is active");
        onLocomotionAction.WhenSelect.AddListener(() =>
        {
            //locomotionOn = !locomotionOn;
            var locomotionMenuOption = onLocomotionAction.GetComponentInChildren<TextMeshPro>();
            var locomotionMenuState = locomotionOn ? "ON" : "OFF";
            locomotionMenuOption.text = $"LOCOMOTION {locomotionMenuState}";
            playerControllerWithHandPoses.EnableLinearMovement = locomotionOn;

            Debug.Log($"Locomotion state changed to: {locomotionMenuState}");
        });
    }

    public void LocomotionVisibility(bool state)
    {
        locomotionMenu.SetActive(true);
    }

    private void Update()
    {
        locomotionMenu.transform.position = targetHand.transform.position + offsetFromHand;
        locomotionMenu.transform.rotation = Quaternion.LookRotation(locomotionMenu.transform.position - cameraRig.centerEyeAnchor.transform.position, Vector3.up);
    }

}
    