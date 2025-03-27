internal class Program
{
    private static void Main(string[] args)
    {
        ContainerShip cs1    = new ContainerShip();
        ContainerCooling cc1 = new ContainerCooling(500, 500, 2000, 2000, EProduct.CHOCOLATE, 26.6);
        ContainerLiquid cl1  = new ContainerLiquid(500, 500, 2000, 1000);

        // Product payloads
        PayloadProduct pp1 = new PayloadProduct("Hershey's Bar", 200, EProduct.CHOCOLATE);
        PayloadProduct pp2 = new PayloadProduct("Gouda", 100, EProduct.CHEESE);
        PayloadProduct pp3 = new PayloadProduct("Galaxy Chocolate Bar", 500, EProduct.CHOCOLATE);
        
        // Regular payloads
        Payload pl1 = new Payload("Water", 400);
        Payload pl2 = new Payload("Vodka", 200);
        
        cc1.Load(pp1); 
        // cc1.Load(pp2); // PayloadMismatchException: Product is not the same type, CHEESE -> CHOCOLATE
        cc1.Load(pp3);
        Console.WriteLine(cc1);

        cl1.Load(pl1);
        cl1.Load(pl2); // 
        Console.WriteLine(cl1);
    }
}