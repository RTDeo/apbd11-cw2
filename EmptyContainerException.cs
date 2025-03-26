class EmptyContainerException : Exception
{
    public EmptyContainerException(String msg) : base(msg) {}
    public EmptyContainerException(String msg, Exception err) : base(msg, err) {}
}