internal class Program
{
    private static void Main(string[] args)
    {
        ContainerShip cs1    = new ContainerShip(20, 3, 200);
        ContainerShip cs2    = new ContainerShip(5, 2, 20);

        // 1 - Stworzenie kontenera danego typu
        ContainerCooling cc1 = new ContainerCooling(500, 500, 2000, 2000, EProduct.CHOCOLATE, 26.6);
        ContainerLiquid cl1  = new ContainerLiquid(500, 500, 2000, 1000);
        ContainerLiquid cl2  = new ContainerLiquid(500, 500, 2000, 500);

        // Product payloads
        PayloadProduct pp1 = new PayloadProduct("Hershey's Bar", 200, EProduct.CHOCOLATE);
        PayloadProduct pp2 = new PayloadProduct("Gouda", 100, EProduct.CHEESE);
        PayloadProduct pp3 = new PayloadProduct("Galaxy Chocolate Bar", 500, EProduct.CHOCOLATE);
        
        // Regular payloads
        Payload pl1 = new Payload("Water", 300);
        Payload pl2 = new Payload("Vodka", 400);
        
        // 2 - Załadowanie ładunku do danego kontenera
        cc1.Load(pp1);
        cc1.Load(pp3);

        cl1.Load(pl1);
        cl2.Load(pl2);

        // 3 - Załadowanie kontenera na statek
        cs1.LoadContainer(cc1);

        // 4 - Załadowanie listy kontenerów na statek
        List<Container> containers = new List<Container>{ cl1, cl2 };
        cs1.LoadContainer(containers);

        // 5 - Usunięcie kontenera ze statku
        ContainerLiquid unloadedContainer = cs1.UnloadContainer<ContainerLiquid>();

        // 6 - Rozładowanie kontenera
        Payload payload = unloadedContainer.Unload();
        
        // 7 - Zastapienie kontenera o danym numerze innym kontenerem
        // Container must be the same weight or smaller in order to replace it
        unloadedContainer.Load(payload);
        // Console.WriteLine(cs1);
        cs1.ReplaceContainer(cl2.GetSerialNumber(), unloadedContainer);

        // 8 - Możliwość przeniesienia kontenera między dwoma statkami
        cs2.LoadContainer(cs1.UnloadContainer<ContainerLiquid>());
        
        // 9 - Wypisane informacji o danym kontenerze
        Console.WriteLine(unloadedContainer);
        
        // 10 - Wypisanie informacji o danym statku i jego ładunku
        Console.WriteLine(cs1);
        Console.WriteLine(cs2);
    }
}