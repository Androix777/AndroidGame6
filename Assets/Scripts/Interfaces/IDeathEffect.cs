interface IDeathEffect
{
    DeathCause AllowedDeathCause
    {
        get;
        set;
    }
    void ActivateEffect();
}
