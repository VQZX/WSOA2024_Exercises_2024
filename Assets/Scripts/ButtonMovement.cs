using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
     [SerializeField]
     private float unitSpeed = 10;

     [SerializeField]
     private TargetMovement targetMovement;
     
     public void MoveLeft()
     {
          Move(Vector2.left);
     }
     
     public void MoveRight()
     {
          Move(Vector2.right);
     }
     
     public void MoveUp()
     {
          Move(Vector2.up);
     }
     
     public void MoveDown()
     {
          Move(Vector2.down);
     }

     private void Move(Vector2 direction)
     {
          var nextPosition = targetMovement.Position;
          nextPosition += direction * unitSpeed * Time.deltaTime;
          targetMovement.TryMoveTarget(nextPosition);
     }
}