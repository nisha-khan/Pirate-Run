using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapCamera : MonoBehaviour
{
    [SerializeField] private RectTransform levelMapContent;

    private Vector2 minCameraPos;
    private Vector2 maxCameraPos;

    private void Start()
    {
        CalculateCameraBounds();
    }

    private void CalculateCameraBounds()
    {
        // Check if the levelMapContent variable is assigned.
        if (levelMapContent != null)
        {
            // Calculate the boundaries based on the size of the level map content.
            Vector2 levelMapSize = levelMapContent.sizeDelta;
            Vector2 viewportSize = GetComponent<RectTransform>().sizeDelta; // Use the size of the LevelMapCamera's RectTransform.

            minCameraPos = levelMapSize - viewportSize;
            maxCameraPos = Vector2.zero;

            // Ensure the boundaries are clamped to non-negative values.
            minCameraPos.x = Mathf.Max(0, minCameraPos.x);
            minCameraPos.y = Mathf.Max(0, minCameraPos.y);
        }
    }

    private void Update()
    {
        // Update the camera's position to clamp it within the calculated boundaries.
        Vector2 clampedPosition = Vector2.ClampMagnitude(transform.localPosition, maxCameraPos.magnitude);
        transform.localPosition = new Vector3(clampedPosition.x, clampedPosition.y, transform.localPosition.z);
    }
}
