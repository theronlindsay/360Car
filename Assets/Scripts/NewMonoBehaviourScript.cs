using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using static UnityEngine.Rendering.GPUSort;

public class SteeringWheel : XRBaseInteractable
{
    [SerializeField] private Transform wheelTransform;

    public UnityEvent<float> OnWheelRotated;

    private float currentAngle = 0.0f;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        currentAngle = FindWheelAngle();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        currentAngle = FindWheelAngle();
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if(isSelected)
            {
                RotateWheel();
            }
        }
    }

    private void RotateWheel()
    {
        float totalAngle = FindWheelAngle();
        float angleDifference = currentAngle - totalAngle;

        wheelTransform.Rotate(transform.forward, -angleDifference);

        currentAngle = totalAngle;
        OnWheelRotated?.Invoke(angleDifference);
    }


    private float FindWheelAngle()
    {
        float totalAngle = 0;
        foreach (IXRSelectInteractor interactor in interactorsSelecting)
        {
            Vector2 direction = FindLocalPoint(interactor.transform.position);
            totalAngle += ConvertToAngle(direction) * FindRotationSensitivity();
        }

        return totalAngle;
    }

    private Vector2 FindLocalPoint(Vector3 position)
    {
        return transform.InverseTransformPoint(position).normalized;
    }
    private float ConvertToAngle(Vector2 direction)
    {
        return Vector2.SignedAngle(transform.up, direction);
    }
    private float FindRotationSensitivity()
    {
        return 1.0f / interactorsSelecting.Count;
    }
}
   