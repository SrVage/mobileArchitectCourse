using UnityEngine;

namespace Code.Services.Input
{
    public class InputServiceMobile:InputService
    {
        public override Vector2 Axis => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}