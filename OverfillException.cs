class OverfillException : Exception
{
    public OverfillException(String msg) : base(msg) {}
    public OverfillException(String msg, Exception err) : base(msg, err) {}
}