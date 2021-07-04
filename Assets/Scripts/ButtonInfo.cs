using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonInfo : MonoBehaviour
    {
        public HoverButton hoverButton;
        public TextMesh buttonStateText;
        public TextMesh buttonValueText;
        public int pressCount = 0;

        private void Start()
        {
            hoverButton.onButtonDown.AddListener(OnButtonDown);
            hoverButton.onButtonUp.AddListener(OnButtonUp);
            hoverButton.onButtonIsPressed.AddListener(OnButtonPressed);
        }

        private void OnButtonUp(Hand hand)
        {
            buttonStateText.text = "Button UP";
        }

        private void OnButtonDown(Hand hand)
        {
            buttonStateText.text = "Button DOWN";
        }

        private void OnButtonPressed(Hand hand)
        {
            buttonStateText.text = "Button PRESSED";
            pressCount++;
            buttonValueText.text = "PressCount: " + pressCount;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}