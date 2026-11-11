using UnityEngine;

[RequireComponent(typeof(Light))]
public class SpotlightScrollAngle : MonoBehaviour
{
    private Light spotLight;

    [Header("Settings")]
    public float scrollSensitivity = 100f;
    public float minAngle = 10f;
    public float maxAngle = 160f;

    void Start()
    {
        spotLight = GetComponent<Light>();
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            spotLight.spotAngle -= scrollInput * scrollSensitivity;
            // Keep the angle within valid Unity spotlight bounds (1 to 179 degrees)
            spotLight.spotAngle = Mathf.Clamp(spotLight.spotAngle, minAngle, maxAngle);

        }
    }
}