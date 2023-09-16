namespace shop.domain.Extensions;

public static class GenericExtensions
{
    public static bool IsNull<T>(this T value) => value == null;
    public static bool IsNotNull<T>(this T value) => value != null;

    public static TReceiverModel ReceiveDifferentProperties<TReceiverModel, TSupplierModel>(
        this TReceiverModel receiver, 
        TSupplierModel supplier)
        where TReceiverModel : class
        where TSupplierModel : class
    {
        if (supplier.IsNull())
            return receiver;

        foreach (var receiverProperty in receiver.GetType().GetProperties())
        {
            var receiverPropertyValue = receiverProperty.GetValue(receiver);

            var supplierProperty = supplier.GetType().GetProperty(receiverProperty.Name);

            var supplierPropertyValue = supplierProperty?.GetValue(supplier) ?? null;

            if (supplierPropertyValue.IsNotNull() &&
                !supplierPropertyValue.Equals(0) &&
                !supplierPropertyValue.Equals(receiverPropertyValue))
            {
                receiverProperty.SetValue(receiver, supplierPropertyValue);
            }
        }

        return receiver;
    }
}