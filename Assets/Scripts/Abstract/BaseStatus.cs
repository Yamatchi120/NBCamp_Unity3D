using UnityEngine;

public abstract class BaseStatus : MonoBehaviour
{
    private float baseJumpPower = 15f;
    public float BaseJumpPower
    {
        get { return baseJumpPower; }
        set { baseJumpPower *= value; }
    }
    private float maxHp;
    public float MaxHp { get; private set; }
    private float currentHp;
    public float CurrentHp
    {
        get { return currentHp; }
        set { currentHp = Mathf.Clamp(value, 0, MaxHp); }
    }
    private float equipHp;
    public float EquipHp { get; private set; }

    protected virtual void Awake()
    {
        MaxHp = 100f;
        CurrentHp = MaxHp;
    }
}