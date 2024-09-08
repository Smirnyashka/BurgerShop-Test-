using System;
using Code.Hero;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Services.CameraService
{
    public class CameraValidator : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        private Vector3 _position;

        private void Start()
        {
            
            _position.z = 40;
        }


        private void Update()
        {
            _position = _targetTransform.position;

            _position.y = 20;
            _position.z = _targetTransform.position.z +20f;

            transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * 3f);
        }



    }
}
