﻿namespace EntityFramework.Repository.Services.Extensions;

internal static class TypeExtensions
{
    public static Type ToNullableType(this Type type)
    {
        // Use Nullable.GetUnderlyingType() to remove the Nullable<T> wrapper if type is already nullable.
        type = Nullable.GetUnderlyingType(type) ?? type; // avoid type becoming null
        if (type.IsValueType) return typeof(Nullable<>).MakeGenericType(type);

        return type;
    }
}