using System;
using UnityEngine;

namespace Player
{
    public class PaddleDrag : MonoBehaviour
    {
        public Action<Vector2> OnDrag;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnMouseDrag()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            OnDrag?.Invoke(mousePosition);
        }
    }
}
