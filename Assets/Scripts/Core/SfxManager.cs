using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SfxManager : MonoBehaviour
    {
        public enum SfxType
        {
            Win = 0,
            Wall = 1,
            Score = 2,
            Paddle = 3
        }

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<AudioClip> clips;

        private Vector3 _cameraPosition;
        
        private void Awake()
        {
            if (Camera.main != null) 
                _cameraPosition = Camera.main.transform.position;
        }
        
        public void PlaySound(params SfxType[] sfxTypes)
        {
            foreach (var sfxType in sfxTypes)
            {
                audioSource.PlayOneShot(clips[(int)sfxType]);
            }
        }
    }
}
