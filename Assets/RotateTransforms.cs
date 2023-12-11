using System.Collections.Generic;
using UnityEngine;

public class RotateTransforms : MonoBehaviour
{
    [SerializeField]
    private List<Transform> targetTransforms;

    [SerializeField]
    private float angularSpeed = 10.0f;

    [SerializeField]
    private float offset = 10.0f;

    [SerializeField]
    public float offsetSpeed = 1.0f;

    private List<float> rotationOffsets;

    private void Awake()
    {
        rotationOffsets = new List<float>();
        GenerateRotationOffsets();
        ApplyInitialRotationOffsets();
    }

    private void Update()
    {
        RotateTransformsAroundZAxis();
        UpdateGlobalOffset();
        UpdateRotationOffsetsList();
    }

    public void UpdateOffsetSpeed(float newOffsetSpeed)
    {
        offsetSpeed = newOffsetSpeed;
    }

    private void GenerateRotationOffsets()
    {
        rotationOffsets.Clear();
        for (int i = 0; i < targetTransforms.Count; i++)
        {
            rotationOffsets.Add(offset * (i + 1));
        }
    }

    private void ApplyInitialRotationOffsets()
    {
        for (int i = 0; i < targetTransforms.Count; i++)
        {
            targetTransforms[i].Rotate(0, 0, rotationOffsets[i]);
        }
    }

    private void RotateTransformsAroundZAxis()
    {
        for (int i = 0; i < targetTransforms.Count; i++)
        {
            float angle = angularSpeed * Time.deltaTime;
            targetTransforms[i].Rotate(0, 0, angle);
        }
    }

    private void UpdateGlobalOffset()
    {
        for (int i = 0; i < targetTransforms.Count; i++)
        {
            offset += offsetSpeed * (i + 1) * Time.deltaTime;
        }
    }

    private void UpdateRotationOffsetsList()
    {
        for (int i = 0; i < targetTransforms.Count; i++)
        {
            rotationOffsets[i] = offset * (i + 1);
        }
    }
}
