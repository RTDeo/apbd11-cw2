class ContainerCooling : Container
{
    private double? temperature;
    private EProduct? productType;

    private static Dictionary<EProduct, double> productTemperatureTable = new Dictionary<EProduct, double> {
        { EProduct.BANANAS,    13.3 },
        { EProduct.CHOCOLATE,  18 },
        { EProduct.FISH,       2 },
        { EProduct.MEAT,       -15 },
        { EProduct.ICE_CREAM,  -18 },
        { EProduct.CHEESE,     7.2 },
        { EProduct.BUTTER,     20.5 }
    };

    public ContainerCooling(int containerWeight, int height, int depth, int maxPayloadWeight, EProduct productType, double temperature) : base(containerWeight, height, depth, maxPayloadWeight) {
        this.temperature = temperature;
        this.productType = productType;
    }

    public override void Load(Payload payload)
    {
        if(payload is not PayloadProduct) {
            throw new PayloadMismatchException("Payload is not a product");
        }

        PayloadProduct payloadProduct = (PayloadProduct)payload;

        if(payloadProduct.ProductType != this.productType) {
            throw new PayloadMismatchException($"Product is not the same type, {payloadProduct.ProductType} -> {this.productType}");
        }

        double productTemperature;

        if(!ContainerCooling.productTemperatureTable.TryGetValue(payloadProduct.ProductType, out productTemperature)) {
            throw new Exception("For some reason the product does not exist in the temperature table, add it in");
        }

        if(this.temperature < productTemperature) {
            throw new Exception($"Temperature is too low for {payloadProduct.PayloadName} in container {this.GetSerialNumber()}");
        }

        int overallWeight = 0;
        
        foreach(PayloadProduct iPayloadProduct in this.loadedPayloads) {
            overallWeight += iPayloadProduct.Weight;
        }

        if(overallWeight + payloadProduct.Weight > this.maxPayloadWeight) {
            throw new OverfillException($"Container {this.GetSerialNumber()} is full, unload it first"); 
        }

        this.loadedPayloads.Add(payloadProduct);
    }

    public override Payload? Unload()
    {
        if(this.loadedPayloads.Count == 0) {
            throw new EmptyContainerException("Container already empty");
        }

        Payload res = this.loadedPayloads.Last();
        this.loadedPayloads.Remove(res);
        return res;
    }

    // TODO
    public override string ToString()
    {   
        if(this.loadedPayloads.Count == 0) {
            return $"Container serial number: {this.GetSerialNumber()}\n\tType: Liquid Container\n\tPayload: N/A";
        }

        Payload payload = this.loadedPayloads.Last();
        return $"Container serial number: {this.GetSerialNumber()}\n\tType: Liquid Container\n\tPayload: {payload.PayloadName}\n\t\tPayload amount: {payload.Weight}";
    }

    public override string GetSerialNumber()
    {
        return $"KON-C-{this.containerId}";
    }
}