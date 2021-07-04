using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class VehicleMovement : MonoBehaviour
    {
        public LinearMapping linMappingForwBackw;
        public LinearMapping linMappingLeftRight;
        public float forwardVal = 0;
        public float turningVal = 0;

        // Start is called before the first frame update
        void Start()
        {
            if (linMappingForwBackw == null)
            {
                linMappingForwBackw = linMappingForwBackw.GetComponent<LinearMapping>();
            }

            if (linMappingLeftRight == null)
            {
                linMappingLeftRight = linMappingLeftRight.GetComponent<LinearMapping>();
            }

            linMappingForwBackw.value = 0.5f;
            linMappingLeftRight.value = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            forwardVal = linMappingForwBackw.value;
            if (forwardVal >= 0.0f & forwardVal < 0.5f)
            {
                transform.Translate(Vector3.back * forwardVal * Time.deltaTime);
            }
            if (forwardVal > 0.5f)
            {
                transform.Translate(Vector3.forward * forwardVal * Time.deltaTime);
            }

            turningVal = linMappingLeftRight.value;
            if (turningVal != 0)
            {
                if (turningVal >= 0.0f & turningVal < 0.5f)
                {
                    transform.RotateAround(transform.position, transform.up, 30 * Time.deltaTime);
                }
                if (turningVal > 0.5f)
                {
                    transform.RotateAround(transform.position, transform.up, -30 * Time.deltaTime);
                }
            }
        }
    }
}
