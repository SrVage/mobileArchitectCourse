using UnityEngine;

namespace Code.Services.Input
{
    public class InputServiceStandalone:InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
                if (axis != Vector2.zero)
                    return axis;
                return new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
            }
        }
    }
}