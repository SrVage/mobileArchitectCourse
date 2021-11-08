using Code.Camera;
using Code.Infrastructure;
using Code.Services.Input;
using UnityEngine;

namespace Code.Hero
{
    public class MoveHero:MonoBehaviour
    {
        [SerializeField]
        private float _speedHero = 5;
        private UnityEngine.Camera _camera;
        private IInputService _inputService;
        private CharacterController _characterController;

        private void Awake()
        {
            _inputService = Game.InputService;
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
            _camera.GetComponent<CameraFollowing>().SetFollowing(transform);
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
    }
}