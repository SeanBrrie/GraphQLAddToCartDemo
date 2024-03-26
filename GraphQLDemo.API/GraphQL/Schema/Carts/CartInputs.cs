public record ProductCartInput(
    int CartId,
    int ProductId,
    int Quantity,
    OperationType OperationType
);

public enum OperationType
{
    ADD,
    REMOVE,
}
