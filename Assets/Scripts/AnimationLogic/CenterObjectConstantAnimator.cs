using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRSF.Core.SetupVR;

namespace Assets.Scripts.AnimationLogic
{
    public class CenterObjectConstantAnimator : MonoBehaviour
    {
        private Transform _target;
        [SerializeField] private Vector3 _rotationOffset;

        private void Awake()
        {
            OnSetupVRReady.Listeners += SetupTarget;
        }

        private void Update()
        {
            if (_target == null)
            {
                _target = VRSF_Components.VRCamera.transform;
                return;
            }

            Vector3 targetPosition = new Vector3(_target.position.x,
                    this.transform.position.y,
                    _target.position.z);
            this.transform.LookAt(targetPosition);
            this.transform.Rotate(_rotationOffset);
        }

        private void OnDestroy()
        {
            OnSetupVRReady.Listeners -= SetupTarget;
        }

        private void SetupTarget(OnSetupVRReady info)
        {
            _target = VRSF_Components.VRCamera.transform;
        }
    }
}
