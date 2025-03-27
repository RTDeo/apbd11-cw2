class ContainerCooling : Container
{
    public ContainerCooling(int containerWeight, int height, int depth, int maxPayloadWeight) : base(containerWeight, height, depth, maxPayloadWeight) {}

    

    public override void Load(Payload payload)
    {
        throw new NotImplementedException();
    }

    public override Payload? Unload()
    {
        throw new NotImplementedException();
    }

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
        throw new NotImplementedException();
    }
}