using UnityEngine;

public enum MoveType
{
   KeyBoard,
   Touchpad
}

public class PlayerInputControl : MonoBehaviour
{
   [SerializeField] private MoveType moveType = MoveType.KeyBoard;
   
   private StrategyCameraMove _mainCamera;
   
   private const string XAxis = "Horizontal";
   private const string ZAxis = "Vertical";
   private const string ZoomAxis = "Mouse ScrollWheel";
   private const string XMouseAxis = "Mouse X";

   private void Start()
   {
      _mainCamera = StrategyCameraMove.Instance;
   }

   private void Update()
   {
      CameraMove();
   }

   private void CameraMove()
   {
      if (moveType == MoveType.KeyBoard)
      {
         var horizontal = Input.GetAxis(XAxis);
         var vertical = Input.GetAxis(ZAxis);
         var zoom = Input.GetAxis(ZoomAxis);
         var rotate = Input.GetAxis(XMouseAxis);
         bool accelerate = Input.GetKey(KeyCode.LeftShift);
         
         _mainCamera.Move(horizontal, vertical,accelerate);
         _mainCamera.Zoom(zoom);
         if (Input.GetMouseButton(1)) _mainCamera.Rotate(rotate);
      }

      if (moveType == MoveType.Touchpad)
      {
         
      }
   }
}
