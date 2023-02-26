using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerUnitController : MonoBehaviour
{
    #region Variables
    [field: Header("Stats")]
    [field: SerializeField] public PlayerUnitSO BaseStats { get; private set; }
    [field: SerializeField] public List<MuzzleController> Muzzles { get; private set; }

    [Header("State Management")]
    public PlayerUnitPlacingState PlacingState = new PlayerUnitPlacingState();
    public PlayerUnitRotatingState RotatingState = new PlayerUnitRotatingState();
    public PlayerUnitActiveState ActiveState = new PlayerUnitActiveState();
    public PlayerUnitDeadState DeadState = new PlayerUnitDeadState();

    [HideInInspector] public Rigidbody2D Body { get; private set; }
    [HideInInspector] public SpriteRenderer Sprite { get; private set; }

    private PlayerUnitState currentState;
    private float health;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        health = BaseStats.health;
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SwitchState(ActiveState);
    }

    private void Update()
    {
        currentState.Update(this);
    }
    #endregion

    #region State Management
    public void SwitchState(PlayerUnitState newState)
    {
        if (currentState != null)
            currentState.Terminate(this);

        currentState = newState;
        currentState.Initialize(this);
    }
    #endregion

    #region Unit Status Related Methods
    public void TakeDamage(float damage)
    {
        if (currentState != ActiveState)
            return;

        health -= damage;

        if (health <= 0)
            SwitchState(DeadState);
    }
    #endregion
}
