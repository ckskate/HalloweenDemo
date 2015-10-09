using System;
using UnityEngine;
using UnityEngine.VR;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 3f;
        public float YSensitivity = 3f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;


        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;

			if (VRSettings.loadedDevice == VRDeviceType.Oculus) {
				m_CharacterTargetRot = InputTracking.GetLocalRotation (VRNode.LeftEye);
				m_CameraTargetRot = InputTracking.GetLocalRotation (VRNode.LeftEye);
			}
        }


        public void LookRotation(Transform character, Transform camera)
        {
			character.localRotation = InputTracking.GetLocalRotation (VRNode.LeftEye) * Quaternion.Euler (90f, 90f, 90f);
			camera.localRotation = Quaternion.Euler (0f, 0f, 0f);




//			float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
//            float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
//
//            m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
//            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
//
//            if(clampVerticalRotation)
//                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
//
//            if(smooth)
//            {
//                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
//                    smoothTime * Time.deltaTime);
//                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
//                    smoothTime * Time.deltaTime);
//            }
//            else
//            {
//				character.localRotation = m_CharacterTargetRot;
//				camera.localRotation = m_CameraTargetRot;
//            }

//			if (VRSettings.loadedDevice == VRDeviceType.Oculus) {
//				character.localRotation = InputTracking.GetLocalRotation (VRNode.LeftEye) * Quaternion.Euler (45f, 45f, 0f);
//				camera.localRotation = InputTracking.GetLocalRotation (VRNode.LeftEye) * Quaternion.Euler (45f, 45f, 0f);
//			}
        }


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
