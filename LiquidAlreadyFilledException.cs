class LiquidAlreadyFilledException : Exception {
    public LiquidAlreadyFilledException(String msg) : base(msg) {}
    public LiquidAlreadyFilledException(String msg, Exception err) : base(msg, err) {}
}