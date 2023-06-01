using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AskeladdenController : MonoBehaviour
{
    public float MoveSpeed;
    public Animator Anim;
    public SpriteRenderer Renderer;
    public EventReference WalkSoundRef;
    
    private Vector3 _moveDirection;
    private Rigidbody2D _rb;
    private EventInstance _walkSoundInstance;
    private bool _soundIsPlaying;

    #region Unity Messages
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _walkSoundInstance = AudioManager.Instance.CreateEventInstance(WalkSoundRef);
    }

    private void Update()
    {
        _moveDirection = InputManager.GetMovement();
        UpdateAnimation();
        UpdateSound();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDirection * MoveSpeed;
    }

    private void UpdateAnimation()
    {
        if (_moveDirection == Vector3.zero)
        {
            Anim.SetBool("IsMoving", false);
            return;
        }

        Anim.SetBool("IsMoving", true);
        Anim.SetFloat("X", _moveDirection.x);
        Anim.SetFloat("Y", _moveDirection.y);

        if(_moveDirection.x < -0.1)
        {
            Renderer.flipX = true;
        }
        else if (_moveDirection.x > 0.1)
        {
            Renderer.flipX = false; 
        }
    }

    private void UpdateSound()
    {
        if (_moveDirection != Vector3.zero && !_soundIsPlaying)
        {
            Debug.Log("Playing sound");
            _walkSoundInstance.start();
            _soundIsPlaying = true;
        }
        
        if (_soundIsPlaying && _moveDirection == Vector3.zero)
        {
            _walkSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            _soundIsPlaying = false;
        }
    }

    private void OnDestroy()
    {
        _walkSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _walkSoundInstance.release();
    }
    #endregion
}
