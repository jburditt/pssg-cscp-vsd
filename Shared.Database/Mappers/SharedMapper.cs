﻿namespace Shared.Database;

public class SharedMapper : Profile
{
    public SharedMapper()
    {
        CreateMap<Money, decimal>()
            .ConvertUsing(src => src.Value);
        CreateMap<Money, decimal?>()
            .ConvertUsing(src => src != null ? src.Value : null);
        CreateMap<EntityReference, Guid>()
            .ConvertUsing(src => src.Id);
        CreateMap<EntityReference, Guid?>()
            .ConvertUsing(src => src.Id);
        CreateMap<DynamicReference, EntityReference>()
            .ConvertUsing(src => new EntityReference(src.SchemaName, src.Id));
        CreateMap<EntityReference, DynamicReference>()
            .ConvertUsing(src => new DynamicReference(src.Id, src.LogicalName));
    }
}
