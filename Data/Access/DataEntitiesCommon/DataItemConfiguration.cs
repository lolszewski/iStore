﻿using System;
using iStore.Data.Access.DataAccessMeta;
using iStore.Data.Access.DataItemsCommonMeta;

namespace iStore.Data.Access.DataEntitiesCommon
{
    public class DataItemConfiguration : IDataItemConfiguration
    {
        public Type DataItemType { get; set; }

        public IDataAccess DataAccess { get; set; }

        public IDataLocation DataLocation { get; set; }

        public void Configure(Type dataItemType, IDataAccess dataAccess, IDataLocation dataLocation)
        {
            DataItemType = dataItemType;
        }

        public IDataAccess GetDataAccess()
        {
            return DataAccess;
        }
    }
}