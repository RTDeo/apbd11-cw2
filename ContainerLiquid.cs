class ContainerLiquid : Container, IHazardNotifier
{
    private static int uniqueCounter = 0;
    public ContainerLiquid(int containerWeight, int height, int depth, int maxPayloadWeight) : base(containerWeight, height, depth, maxPayloadWeight) {
        this.containerId = ContainerLiquid.uniqueCounter;
        ContainerLiquid.uniqueCounter++;
    }

    public override void Load(Payload payload)
    {
        // TODO: This is wrong, need to fix
        // One type of liquid can only exist in the container
        if(this.loadedPayloads.Count != 0) {
            throw new ContainerAlreadyFilledException("Liquid container already filled, unload it first");
        }

        int maxPayloadWeight = (int)Math.Round(this.maxPayloadWeight * 0.9);
        
        if(payload is PayloadDangerous) {
            maxPayloadWeight = (int)Math.Round(this.maxPayloadWeight * 0.5);
        }

        if(payload.Weight > maxPayloadWeight) {
            this.sendDangerNotification("There was an attempt to overload the container");
            return;
        }

        this.loadedPayloads.Add(payload);
        return;
    }

    public override Payload Unload()
    {
        if(this.loadedPayloads.Count == 0) {
            throw new EmptyContainerException($"No liquid loaded in container {this.GetSerialNumber()}");
        }
        
        Payload res = this.loadedPayloads.Last();
        this.loadedPayloads.Remove(res);
        return res;
    }

    public void sendDangerNotification(String msg)
    {
        Console.WriteLine($"[DANGER] {msg} - container {this.GetSerialNumber()}");
    }

    public override string ToString()
    {   
        if(this.loadedPayloads.Count == 0) {
            return $"Container serial number: {this.GetSerialNumber()}\n\tType: Liquid Container\n\tPayload: N/A";
        }

        Payload payload = this.loadedPayloads.Last();
        return $"Container serial number: {this.GetSerialNumber()}\n\tType: Liquid Container\n\tPayload: {payload.PayloadName}\n\tPayload amount: {payload.Weight}";
    }

    public override string GetSerialNumber()
    {
        return $"KON-L-{this.containerId}";
    }

    public override int GetOverallWeight()
    {
        int overallWeight = 0;
        
        foreach(Payload product in this.loadedPayloads) {
            overallWeight += product.Weight;
        }

        return overallWeight;
    }
}