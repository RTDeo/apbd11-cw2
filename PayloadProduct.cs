class PayloadProduct : Payload {
    public EProduct ProductType { get; set; }
    public PayloadProduct(String payloadName, int weight, EProduct productType) : base(payloadName, weight) {
        this.ProductType = productType;
    }

    public override string ToString()
    {
        return $"[{this.ProductType}] '{this.PayloadName}' ({this.Weight}kg)";
    }
}