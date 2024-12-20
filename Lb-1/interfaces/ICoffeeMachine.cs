
namespace Lb_1.interfaces;

public interface ICoffeeMachine
{
    int WaterAmount { get; }
    int CoffeeBeansAmount { get; }
    bool IsWaterHeated { get; }

    void MakeEspresso();
    void MakeLatte();
}