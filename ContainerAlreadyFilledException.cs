class ContainerAlreadyFilledException : Exception {
    public ContainerAlreadyFilledException(String msg) : base(msg) {}
    public ContainerAlreadyFilledException(String msg, Exception err) : base(msg, err) {}
}