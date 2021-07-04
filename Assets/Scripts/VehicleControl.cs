using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class VehicleControl : MonoBehaviour
    {
        public GameObject bodyObj;
        public GameObject turretObj;
        public GameObject barrelObj;
        public GameObject barrelRotPoint;

        public HoverButton btnLeft;
        public HoverButton btnRight;
        public HoverButton btnUp;
        public HoverButton btnDown;

        public HoverButton btnShoot;
        public GameObject bulletPrefab;
        public GameObject bulletSpawn;

        int angle = 0;

        // Start is called before the first frame update
        void Start()
        {
            btnLeft.onButtonIsPressed.AddListener(OnButtonLeft);
            btnRight.onButtonIsPressed.AddListener(OnButtonRight);
            btnUp.onButtonIsPressed.AddListener(OnButtonUp);
            btnDown.onButtonIsPressed.AddListener(OnButtonDown);

            btnShoot.onButtonDown.AddListener(OnButtonShoot);
            StartCoroutine(onCoroutine());
        }

        // Update is called once per frame
        void Update()
        {
            angle = (int) barrelObj.transform.localRotation.eulerAngles.x;
        }

        private void OnButtonLeft(Hand hand)
        {
            //buttonStateText.text = "Turret LEFT";
            turretObj.transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }

        private void OnButtonRight(Hand hand)
        {
            //buttonStateText.text = "Turn RIGHT";
            turretObj.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }

        private void OnButtonUp(Hand hand)
        {
            //buttonStateText.text = "Barrel UP";
            if (angle > 300 || angle == 0)
            {
                barrelObj.transform.RotateAround(barrelRotPoint.transform.position, barrelRotPoint.transform.right, -30 * Time.deltaTime);

            }
        }

        private void OnButtonDown(Hand hand)
        {
            //buttonStateText.text = "Barrel DOWN";
            if (angle < 360 & angle >= 300)
            {
                barrelObj.transform.RotateAround(barrelRotPoint.transform.position, barrelRotPoint.transform.right, 30 * Time.deltaTime);
            }
        }

        private void OnButtonShoot(Hand hand)
        {
            //buttonStateText.text = "SHOOT";
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            Rigidbody bulletRigid = newBullet.GetComponent<Rigidbody>();
            bulletRigid.AddForce(bulletSpawn.transform.forward);
        }

        IEnumerator onCoroutine()
        {
            while (true)
            {
                GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 2000);
 
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
