﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ICQ.Maps
{
    public interface IAutoMapper
    {
        IConfigurationProvider Configuration { get; }

        T Map<T>(object objectToMap);

        void Map<TSource, TDestination>(TSource source, TDestination destination);

        TResult[] Map<TSource, TResult>(IEnumerable<TSource> sourceQuery);
        IQueryable<TResult> Map<TSource, TResult>(IQueryable<TSource> sourceQuery);
    }
}