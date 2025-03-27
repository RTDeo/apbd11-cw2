internal class Program
{
    private static void Main(string[] args)
    {
        // ContainerShip cs1 = new ContainerShip();
        // ContainerLiquid containerLiquid = new ContainerLiquid(200, 500, 2000, 500);
        // Payload milk = new Payload("Milk", 400);
        // containerLiquid.Load(milk);
        // Console.WriteLine(containerLiquid);
        // containerLiquid.Unload();
        // Console.WriteLine(containerLiquid);

        ContainerGas cg1 = new ContainerGas(500, 500, 2000, 1000);
        Payload cm1 = new Payload("CO", 300);
        Payload cm2 = new Payload("CO", 350);
        Payload cm3 = new Payload("O", 45);

        cg1.Load(cm1);
        Console.WriteLine(cg1); // 300
        cg1.Load(cm2);
        Console.WriteLine(cg1); // 650
        cg1.Load(cm3);
        Console.WriteLine(cg1); // 695
        // cg1.Unload();
        // Console.WriteLine(cg1); // 30
        // cg1.Load(cm2);
        // cg1.Load(cm2);
        // cg1.Load(cm2);
    }
}