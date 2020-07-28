using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ValueStat
{
    [SerializeField]private float value = 1;
    private float increase = 1;
    private float more = 1;
    [SerializeField]private float minValue = float.MinValue;
    [SerializeField]private float maxValue = float.MaxValue;

    private float valueDefault = 1;
    private float increaseDefault = 1;
    private float moreDefault = 1;

    public float GetStatValue()
    {
        return Mathf.Clamp(value * increase * more,minValue,maxValue) ;
    }

    public void SetAsDefault()
    {
        valueDefault = value;
        increaseDefault = increase;
        moreDefault = more;
    }

    public void SetDefault()
    {
        value = valueDefault;
        increase = increaseDefault;
        more = moreDefault;
    }

#region GetSet
    public void SetValue(float value)
    {
        this.value = value;
    }

    public float GetValue()
    {
        return value;
    }

    public void SetIncrease(float increase)
    {
        this.increase = increase;
    }

    public float GetIncrease()
    {
        return increase;
    }

    public void SetMore(float more)
    {
        this.more = more;
    }

    public float GetMore()
    {
        return more;
    }

    public void AddValue(float value)
    {
        SetValue(GetValue() + value);
    }

    public void AddIncrease(float increase)
    {
        SetIncrease(GetIncrease() + increase);
    }

    public void AddMore(float more)
    {
        SetMore(GetMore() + more);
    }
#endregion
}
