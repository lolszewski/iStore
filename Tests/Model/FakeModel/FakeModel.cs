﻿using System.Collections.Generic;
using iStore.Tests.Model.FakeModelMeta;

namespace iStore.Tests.Model.FakeModel
{
    public class FakeModel : IFakeModel
    {
        public int IntField { get; set; }

        public string StringField { get; set; }

        public IEnumerable<string> StringsList { get; set; }

        public FakeModel(int intField, string stringField, IEnumerable<string> stringsList)
        {
            IntField = intField;
            StringField = stringField;
            StringsList = stringsList;
        }
    }
}
