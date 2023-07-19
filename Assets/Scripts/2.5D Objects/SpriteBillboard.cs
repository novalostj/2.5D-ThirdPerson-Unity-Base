using UnityEngine;

namespace _2._5D_Objects
{
    public class SpriteBillboard : MonoBehaviour
    {
        public Transform parentTransform;

        public bool staticBillboard;
        public bool freezeXRotation;
        public bool freezeYRotation;
        public bool freezeZRotation;

        public Vector3 freezeValues = new();
        public Vector3 addedRotation = new();

        private Transform mainCamera;

        private void Start()
        {
            SetCamera();
        }

        private void Update()
        {
            if (!mainCamera)
            {
                SetCamera();
                return;
            }

            if (staticBillboard)
            {
                transform.rotation = mainCamera.rotation;
            }
            else
            {
                var parentRot = parentTransform ? parentTransform.rotation : new Quaternion();
                transform.LookAt(mainCamera);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - parentRot.eulerAngles);
            }

            FreezeRotationAxis();
        }

        private void FreezeRotationAxis()
        {
            Vector3 rotation = new()
            {
                x = freezeXRotation ? freezeValues.x : transform.rotation.eulerAngles.x,
                y = freezeYRotation ? freezeValues.y : transform.rotation.eulerAngles.y,
                z = freezeZRotation ? freezeValues.z : transform.rotation.eulerAngles.z
            };

            transform.localRotation = Quaternion.Euler(rotation + addedRotation);
        }

        private void SetCamera()
        {
            var main = Camera.main;
            if (!main) return;

            mainCamera = main.transform;
        }
    }
}