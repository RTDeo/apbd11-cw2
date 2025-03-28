abstract class Container
{    
    protected int containerId;                // Obtained from uniqueCounter, used for displaying the current container serial number.
    protected List<Payload> loadedPayloads;
    protected int containerWeight;
    protected int height;
    protected int depth;
    protected int maxPayloadWeight;
    protected int currentWeight;

    public Container(int containerWeight, int height, int depth, int maxPayloadWeight) {
        this.containerWeight    = containerWeight;
        this.height             = height;
        this.depth              = depth;
        this.maxPayloadWeight   = maxPayloadWeight;
        this.loadedPayloads     = new List<Payload>();
        this.currentWeight      = 0;
    }

    public abstract Payload Unload();
    public abstract void Load(Payload payload);

    public abstract int GetOverallWeight();
    public abstract String GetSerialNumber();
}