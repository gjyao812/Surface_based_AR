using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject placedObject;

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        if (placedObject != null)
            return;

        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition =
                Touchscreen.current.primaryTouch.position.ReadValue();

            if (raycastManager.Raycast(
                    touchPosition,
                    hits,
                    TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                placedObject = Instantiate(
                    objectToPlace,
                    hitPose.position,
                    hitPose.rotation
                );

                HidePlanes();
            }
        }
    }

    private void HidePlanes()
    {
        if (planeManager == null)
            return;

        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        planeManager.enabled = false;
    }
}