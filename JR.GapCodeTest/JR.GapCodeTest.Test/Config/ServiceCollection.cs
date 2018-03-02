using System;
using Xunit;

namespace JR.GapCodeTest.Test.Config
{
    [CollectionDefinition("Service collection")]
    public class ServiceCollection : ICollectionFixture<ServiceFixture>
    {
    }
}