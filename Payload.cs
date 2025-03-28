class Payload
{
    public int Weight { get; set; }
    public String PayloadName { get; set; }
    public Payload(String payloadName, int weight) {
        this.Weight         = weight;
        this.PayloadName    = payloadName;
    }

    public override string ToString()
    {
        return $"Payload '{this.PayloadName}' ({this.Weight}kg)";
    }
}