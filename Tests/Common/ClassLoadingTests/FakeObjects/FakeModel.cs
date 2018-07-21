using System.Collections.Generic;

namespace iStore.Tests.Common.ClassLoadingTests.FakeObjects
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
