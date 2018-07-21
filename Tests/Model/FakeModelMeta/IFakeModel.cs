﻿using iStore.Data.Access.DataAccessMeta;
using System.Collections.Generic;

namespace iStore.Tests.Model.FakeModelMeta
{
    public interface IFakeModel : IDataItem
    {
        int IntField { get; set; }

        string StringField { get; set; }

        IEnumerable<string> StringsList { get; set; }
    }
}
