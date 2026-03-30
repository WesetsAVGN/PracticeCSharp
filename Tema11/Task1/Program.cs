namespace PracticeTasks;

class Program
{
    static void Main()
    {
        VehicleFactory factory = new CarFactory();
        IVehicle vehicle = factory.CreateVehicle();
        vehicle.Move();
    }
}