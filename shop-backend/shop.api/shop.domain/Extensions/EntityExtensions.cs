using shop.domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace shop.domain.Extensions;
public static class EntityExtensions
{
    public static TReceiverModel ReceiveDifferentProperties<TReceiverModel, TSupplierModel>(
        this TReceiverModel receiver,
        TSupplierModel supplier)
        where TReceiverModel : Entity
        where TSupplierModel : Entity
    {
        if (supplier.IsNull())
            return receiver;

        var receiverProperties = receiver.GetType().GetProperties();
        foreach (var receiverProperty in receiverProperties)
        {
            var receiverPropertyValue = receiverProperty.GetValue(receiver);

            var supplierProperty = supplier.GetType().GetProperty(receiverProperty.Name);

            var supplierPropertyValue = supplierProperty?.GetValue(supplier) ?? null;

            if (supplierPropertyValue.IsNotNull() &&
                !supplierPropertyValue.Equals(0) &&
                !supplierPropertyValue.Equals(receiverPropertyValue)

                ||

                receiverProperty.GetCustomAttribute<NotMappedAttribute>().IsNotNull())
            {
                receiverProperty.SetValue(receiver, supplierPropertyValue);
            }
        }

        return receiver;
    }
}
