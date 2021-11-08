using System;
using UnityEngine;

namespace Code.Camera
{
    public class CameraFollowing:MonoBehaviour
    {
        [SerializeField] private Vector3 _angle;
        [SerializeField] private float _distance;
        [SerializeField] private float _yOffset;
        private Transform _followingObject;

        public void SetFollowing(Transform transform)
        {
            _followingObject = transform;
        }

        private void LateUpdate()
        {
            if (_followingObject == null) return;
            Quaternion rotation = Quaternion.Euler(_angle);
            var position = rotation * new Vector3(0, 0, -_distance) + _followingObject.position + Vector3.up * _yOffset;
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}