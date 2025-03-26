internal class Program
{
    private static void Main(string[] args)
    {
        ContainerShip cs1 = new ContainerShip();
        ContainerLiquid containerLiquid = new ContainerLiquid(200, 500, 2000, 500);
        Payload milk = new Payload("Milk", 800);
        containerLiquid.Load(milk);
        Console.WriteLine(containerLiquid);
    }
}