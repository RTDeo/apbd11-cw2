abstract class Container
{    
    protected static int uniqueCounter = 0;   // Unique counter iterated when a new container object is created, used for tracking the last generated container object.
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

        this.containerId        = Container.uniqueCounter;
        Container.uniqueCounter++;
    }

    public abstract Payload? Unload();/* {
        if(this.loadedPayloads.Count == 0) {
            throw new EmptyContainerException(String.Format("No payload loaded in container %s", this.GetSerialNumber()));
        }
        
        Payload res = this.loadedPayloads.Last();
        this.loadedPayloads.Remove(res);
        return res;
    }*/

    public abstract void Load(Payload payload);

    // Yuck
    abstract public String GetSerialNumber();
}