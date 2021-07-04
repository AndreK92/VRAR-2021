using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem
{
    public class LinearInformation : MonoBehaviour
    {
        public LinearMapping linearMapping;
        public TextMesh sliderValueText;
        private float currValue;

        void Awake()
        {
            if (linearMapping == null)
            {
                linearMapping = linearMapping.GetComponent<LinearMapping>();
            }
            currValue = linearMapping.value;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(currValue != linearMapping.value)
            {
                sliderValueText.text = "SliderValue: " + linearMapping.value;
            }

        }
    }
}

