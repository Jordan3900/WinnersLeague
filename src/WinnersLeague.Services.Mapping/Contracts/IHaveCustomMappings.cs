namespace WinnersLeague.Services.Mapping.Contracts
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
