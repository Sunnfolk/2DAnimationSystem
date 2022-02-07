using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(Input), typeof(Rigidbody2D))]
public class TestAnimator : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Input _input;
    
    private Vector2 direction;
    private float idleTime;
    public float frameRate;
    public float walkSpeed;

    [SerializeField] private Animations moveAnimation;
 

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //frameRate = moveAnimation.east.Count;
    }

    private void Update()
    {
        #region Initialising Code
            direction = _input.moveDirection;
        #endregion
        
        _rigidbody2D.velocity = direction * walkSpeed;
        
        HandleSpriteFlip();
        SetSprite();
    }

    private void HandleSpriteFlip()
    {
        if (!_spriteRenderer.flipX && direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_spriteRenderer.flipX && direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void SetSprite()
    {
        var directionSprites = GetSpriteDirection();
        if (directionSprites != null)
        {
            //frameRate = directionSprites.Count;
            var playTime = Time.time - idleTime;
            var totalFrames = (int) (playTime * frameRate);
            var frame = totalFrames % directionSprites.Count();

            _spriteRenderer.sprite = directionSprites[frame];
            
        }
        else
        {
            idleTime = Time.time;
        }
        

    }

    private List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;
        
        if (direction.y > 0)
        {
            selectedSprites = Mathf.Abs(direction.x) > 0 ? moveAnimation.northEast : moveAnimation.north;
        }
        else if (direction.y < 0)
        {
            selectedSprites = Mathf.Abs(direction.x) > 0 ? moveAnimation.southEast : moveAnimation.south;
        }
        else
        {
            if (Mathf.Abs(direction.x) > 0) selectedSprites = moveAnimation.east;
        }
        
        return selectedSprites;
    }
}
