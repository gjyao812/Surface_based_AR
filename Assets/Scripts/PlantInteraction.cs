using UnityEngine;
using UnityEngine.InputSystem;

public class PlantInteraction : MonoBehaviour
{
    public Camera arCamera;

    public float rotationSpeed = 0.2f;
    public float scaleSpeed = 0.005f;

    private GameObject selectedPlant;

    private Vector2 lastTouchPosition;
    private float lastTouchDistance;

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        var primaryTouch = Touchscreen.current.primaryTouch;
        var secondaryTouch = Touchscreen.current.touches[1];

        if (primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition =
                primaryTouch.position.ReadValue();

            Ray ray =
                arCamera.ScreenPointToRay(touchPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedPlant = hit.collider.transform.root.gameObject;

                lastTouchPosition = touchPosition;
            }
        }

        if (selectedPlant == null)
            return;

        if (primaryTouch.press.isPressed &&
            secondaryTouch.press.isPressed)
        {
            Vector2 pos1 =
                primaryTouch.position.ReadValue();

            Vector2 pos2 =
                secondaryTouch.position.ReadValue();

            float currentDistance =
                Vector2.Distance(pos1, pos2);

            if (lastTouchDistance > 0)
            {
                float difference =
                    currentDistance - lastTouchDistance;

                float scaleChange =
                    difference * scaleSpeed;

                Vector3 newScale =
                    selectedPlant.transform.localScale +
                    Vector3.one * scaleChange;

                float minScale = 0.05f;
                float maxScale = 2.0f;

                newScale.x =
                    Mathf.Clamp(newScale.x, minScale, maxScale);

                newScale.y =
                    Mathf.Clamp(newScale.y, minScale, maxScale);

                newScale.z =
                    Mathf.Clamp(newScale.z, minScale, maxScale);

                selectedPlant.transform.localScale =
                    newScale;
            }

            lastTouchDistance = currentDistance;

            return;
        }
        else
        {
            lastTouchDistance = 0;
        }

        if (primaryTouch.press.isPressed)
        {
            Vector2 currentPosition =
                primaryTouch.position.ReadValue();

            Vector2 delta =
                currentPosition - lastTouchPosition;

            selectedPlant.transform.Rotate(
                Vector3.up,
                -delta.x * rotationSpeed,
                Space.World
            );

            lastTouchPosition = currentPosition;
        }
    }
}