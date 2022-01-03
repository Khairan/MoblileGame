using JoostenProductions;
using Tools;
using UnityEngine;


namespace Game.InputLogic
{
    internal class TappingInputView : BaseInputView
    {
        private Touch theTouch;

        private Vector2 touchStartPosition = Vector2.zero;
        private Vector2 touchEndPosition = Vector2.zero;
        private Vector2 direction = Vector2.zero;
        
        private float movingTreshold = 100f;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            if (Input.touchCount > 0)
            {
                theTouch = Input.GetTouch(0);
                
                if (theTouch.phase == TouchPhase.Began)
                {
                    touchStartPosition = theTouch.position;
                }
                else if (theTouch.phase == TouchPhase.Moved || theTouch.phase != TouchPhase.Ended)
                {
                    touchEndPosition = theTouch.position;
                }
                else if (theTouch.phase == TouchPhase.Ended)
                {
                    direction = touchEndPosition - touchStartPosition;
                }
            }

            if(touchStartPosition == touchEndPosition && touchStartPosition != Vector2.zero)
            {
                direction = new Vector2(touchStartPosition.x - Screen.width / 2, 0);
                if (Mathf.Abs(direction.x) <= movingTreshold)
                    direction = Vector2.zero;
            }

            if (direction.sqrMagnitude > 1)
                direction.Normalize();

            if (direction.x > 0)
                OnRightMove(direction.x * Time.deltaTime * _speed);
            else if (direction.x <0)
                OnLeftMove(direction.x * Time.deltaTime * _speed);
        }
    }
}