    using UnityEngine;

    public class ControlSettings : MonoBehaviour
    {
        private Control _tapControl;
        private Control _swipeControl;
        private Player _player;
        
        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _tapControl = FindObjectOfType<TapControl>();
            _swipeControl = FindObjectOfType<SwipeControl>();

        }

        private void ChangePlayerControl<T>(T control) where T : Control
        {
            var currentContol = _player.GetComponent<Control>();
            currentContol.enabled = false;
            control.enabled = true;

        }

        public void Change()
        { 
            ChangePlayerControl(_tapControl);
            
        }
        
    }
