using System;
using UnityEngine;

namespace Player
{
    public class PaddleDrag : MonoBehaviour
    {
        public Action<float> OnDrag;
        private float _lastPosition;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnMouseDown()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition).y;
            _lastPosition = mousePosition;
        }

        private void OnMouseDrag()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition).y;
            var delta = mousePosition - _lastPosition;
            _lastPosition = mousePosition;
            
            OnDrag?.Invoke(delta);
        }
    }
}
