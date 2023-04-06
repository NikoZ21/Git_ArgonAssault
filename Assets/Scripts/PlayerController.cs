using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float controlSpeed;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;

    [Header("Rotation Settings")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchfactor = -10f;
    [SerializeField] float positionYawFactor = -10;
    [SerializeField] float controllRollFactor = 10;
    float xThrow, yThrow;

    [Header("Shooting Settings")]
    [SerializeField] GameObject[] lasers;

    void Update()
    {
        ProccessTranslation();
        ProccessRotation();
        ProccessFiring();
    }

    private void ProccessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlTHrow = yThrow * controlPitchfactor;

        float pitch = pitchDueToPosition + pitchDueToControlTHrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controllRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProccessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");


        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProccessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLaserState(true);
        }
        else
        {
            SetLaserState(false);
        }
    }

    private void SetLaserState(bool isActive)
    {
        foreach (var item in lasers)
        {
            var emission = item.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
        }
    }
}
