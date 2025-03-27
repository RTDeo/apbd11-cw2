class ContainerGas : Container, IHazardNotifier
{
    private int pressure;
    public ContainerGas(int containerWeight, int height, int depth, int maxPayloadWeight) : base(containerWeight, height, depth, maxPayloadWeight) {}

    public override void Load(Payload payload)
    {        
        if(this.loadedPayloads.Count != 0 && payload.PayloadName != this.loadedPayloads.Last().PayloadName) {
            this.sendDangerNotification($"There was an attempt to cross-contaminate the gas container with a different gas, {payload.PayloadName} -> {this.loadedPayloads.Last().PayloadName}");
            return;
        }

        // New container, initialize gas on load
        if(this.loadedPayloads.Count == 0) {
            int leftoverGasWeight   = (int)Math.Round(payload.Weight * 0.05);
            Payload leftoverGas     = new Payload(payload.PayloadName, leftoverGasWeight);
            Payload rest            = new Payload(payload.PayloadName, payload.Weight - leftoverGasWeight);
            this.loadedPayloads.Add(leftoverGas);
            this.loadedPayloads.Add(rest);
            payload.Weight = payload.Weight - leftoverGasWeight;
            return;
        }

        int overallGasWeight = this.loadedPayloads[0].Weight;
        overallGasWeight += this.loadedPayloads.Count == 2 ? this.loadedPayloads[1].Weight : 0;
        overallGasWeight += payload.Weight; 

        if(overallGasWeight > this.maxPayloadWeight) {
            throw new OverfillException("Gas container cannot fill more gas");
        }

        // Calculate gas ratio for both payloads
        int newLeftoverGasWeight = (int)Math.Round(overallGasWeight * 0.05);
        this.loadedPayloads[0].Weight = newLeftoverGasWeight;
        this.loadedPayloads[1].Weight = overallGasWeight - newLeftoverGasWeight;
    }

    public override Payload? Unload()
    {
        // There must be 2 payloads, 5% of gas and 95% of gas
        if(this.loadedPayloads.Count < 2) {
            throw new EmptyContainerException("Gas container is empty");
        }

        Payload res = this.loadedPayloads.Last();
        this.loadedPayloads.Remove(res);
        return res;
    }

    public override string GetSerialNumber()
    {
        return $"KON-G-{this.containerId}";
    }

    public override string ToString()
    {   
        if(this.loadedPayloads.Count == 0) {
            return $"Container serial number: {this.GetSerialNumber()}\n\tType: Gas Container\n\tPayload: N/A";
        }

        String gasName       = this.loadedPayloads.Last().PayloadName;
        int leftOverPressure = this.loadedPayloads[0].Weight;
        int gasPressure      = 0; 
        
        if(this.loadedPayloads.Count > 1) {
            gasPressure = this.loadedPayloads[1].Weight;
        }

        return $"Container serial number: {this.GetSerialNumber()}\n\tType: Gas Container\n\tPayload: {gasName}\n\t\tPayload amount: {gasPressure+leftOverPressure} ({gasPressure}+{leftOverPressure})";
    }

    public void sendDangerNotification(string msg)
    {
        Console.WriteLine($"[DANGER] {msg} - container {this.GetSerialNumber()}");
    }
}