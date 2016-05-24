using Test.Commons;
using Xunit;

namespace Data.Test
{
    [CollectionDefinition("DB")]
    public class DatabaseCollection : ICollectionFixture<DbSessionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
