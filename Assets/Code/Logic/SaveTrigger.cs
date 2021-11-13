using System;
using Code.Infrastructure;
using Code.Services.LoadSavedProgress;
using Code.Services.PesistentProgress;
using UnityEngine;

namespace Code.Logic
{
    public class SaveTrigger:MonoBehaviour
    {
        private ISavedProgressLoader _saveLoader;
        [SerializeField] private BoxCollider _collider;

        private void Awake()
        {
            _saveLoader = AllServices.Container.Single<ISavedProgressLoader>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoader.SaveData();
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!_collider) return;
            Gizmos.color = new Color32(30, 200, 50, 100);
            Gizmos.DrawCube(transform.position+_collider.center, _collider.size);
        }
    }
}