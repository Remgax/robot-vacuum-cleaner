using UnityEngine;
public abstract class IRobot
{
    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract bool isOn();
    public abstract float GetCurrentBatteryLevel();
    public abstract bool isBatteryLow();
    public abstract void Move(Vector3 direction);
    public abstract void ReturnToBase();
    public abstract void setSensorRadius(float radius);
    public abstract void checkCollision();


}
