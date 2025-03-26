class ContainerCooling : Container
{
    public ContainerCooling(int containerWeight, int height, int depth, int maxPayloadWeight) : base(containerWeight, height, depth, maxPayloadWeight) {}

    public override string GetSerialNumber()
    {
        throw new NotImplementedException();
    }

    public override void Load(Payload payload)
    {
        throw new NotImplementedException();
    }

    public override Payload? Unload()
    {
        throw new NotImplementedException();
    }
}