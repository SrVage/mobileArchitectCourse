using Code.Data;
using Code.Infrastructure;
using Code.Services.Input;
using Code.Services.PesistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Hero
{
    public class MoveHero:MonoBehaviour, ISavedProgress
    {
        [SerializeField]
        private float _speedHero = 5;
        private UnityEngine.Camera _camera;
        private IInputService _inputService;
        private CharacterController _characterController;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }
        

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;
            _characterController.Move(movementVector * _speedHero * Time.deltaTime);
        }

        public void LoadProgress(PlayerData data)
        {
            if (data == null) return;
            if (data.PositionOnLevel.LevelName!=CurrentLevelName())
                return;
            Vector3Data savedPosition = data.PositionOnLevel.Position;
            if (savedPosition!=null)
                Warp(savedPosition.ConvertToVector3());
        }

        private void Warp(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position;
            _characterController.enabled = true;
        }

        public void SavedProgress(PlayerData data)
        {
            data.PositionOnLevel = new PositionOnLevel(CurrentLevelName(),
                transform.position.ConvertToVector3Data());
        }

        private string CurrentLevelName() => SceneManager.GetActiveScene().name;
    }
}