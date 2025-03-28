class ContainerShip
{
    private static int uniqueCounter = 0;
    private int maxWeight; // In tonnes
    private int maxContainerCount;
    private int maxSpeed;
    private int containerShipId;
    // private int speed;
    private List<Container> loadedContainers = new List<Container>();

    public ContainerShip(int maxWeight, int maxContainerCount, int maxSpeed) {
        this.maxWeight          = maxWeight;
        this.maxContainerCount  = maxContainerCount;
        this.maxSpeed           = maxSpeed;
        this.containerShipId    = ContainerShip.uniqueCounter;
        ContainerShip.uniqueCounter++;
    }

    public void LoadContainer(Container container) {
        int currentOverallWeight = container.GetOverallWeight();
        
        foreach(Container iContainer in this.loadedContainers) {
            currentOverallWeight += iContainer.GetOverallWeight();
        }

        if(currentOverallWeight > this.maxWeight * 1000) {
            throw new OverfillException("Container ship does not have enough space");
        }

        this.loadedContainers.Add(container);
    }

    public void LoadContainer(List<Container> containers) {
        foreach(Container container in containers) {
            this.LoadContainer(container);
        }
    }

    public T UnloadContainer<T>() where T: Container {
        foreach(Container container in this.loadedContainers) {
            if(container is T) {
                T result = (T)container;
                this.loadedContainers.Remove(container);
                return result;
            }
        }
        throw new Exception($"Could not find container of this specific type");
    }

    // ContainerShip 5
    //      Container[s]: KON-C-0, KON-L-0, KON-L-1 (3/5)
    //      Weight: 200/550
    //      Speed: 0/220
    public override string ToString()
    {
        String containersInfo = "";
        double overallWeight = 0; // In tonnes
        
        foreach(Container container in this.loadedContainers) {
            containersInfo += ", " + container.GetSerialNumber();
            overallWeight  += container.GetOverallWeight();
        }

        containersInfo = containersInfo[2..];
        overallWeight /= 1000;
        
        return $"ContainerShip {this.containerShipId}\n\tContainer[s]: {containersInfo}\n\tWeight: {overallWeight}/{this.maxWeight}\n\tSpeed: 0/{this.maxSpeed}";
    }

    internal void ReplaceContainer(string serialNumber, Container newContainer)
    {
        foreach(Container container in this.loadedContainers) {
            if(container.GetSerialNumber() == serialNumber) {
                if(container.GetOverallWeight() < newContainer.GetOverallWeight()) {
                    throw new Exception("The new container is heavier than the one being replaced");
                }
                Container loadedContainer = container;
                this.loadedContainers.Remove(loadedContainer);
                this.loadedContainers.Add(newContainer);
                return;
            }
        }
        throw new Exception($"Container of serial number {serialNumber} not found on this ship");
    }
}