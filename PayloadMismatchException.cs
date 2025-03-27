class PayloadMismatchException : Exception
{
    public PayloadMismatchException(String msg) : base(msg) {}
    public PayloadMismatchException(String msg, Exception err) : base(msg, err) {}
}