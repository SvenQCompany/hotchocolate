using System.Linq;
using HotChocolate.ApolloFederation.Constants;
using HotChocolate.Types;
using HotChocolate.Utilities;
using Snapshooter.Xunit;
using Xunit;

namespace HotChocolate.ApolloFederation.Directives;

public class KeyDirectiveTests : FederationTypesTestBase
{
    [Fact]
    public void AddKeyDirective_EnsureAvailableInSchema()
    {
        // arrange
        var schema = CreateSchema(b =>
        {
            b.AddDirectiveType<KeyDirectiveType>();
        });

        // act
        var directive =
            schema.DirectiveTypes.FirstOrDefault(
                t => t.Name.EqualsOrdinal(WellKnownTypeNames.Key));

        // assert
        Assert.NotNull(directive);
        Assert.IsType<KeyDirectiveType>(directive);
        Assert.Equal(WellKnownTypeNames.Key, directive!.Name);
        Assert.Single(directive.Arguments);
        AssertDirectiveHasFieldsArgument(directive);
        Assert.Collection(directive.Locations,
            t => Assert.Equal(DirectiveLocation.Object, t),
            t => Assert.Equal(DirectiveLocation.Interface, t));

    }

    [Fact]
    public void AnnotateKeyToObjectTypeCodeFirst()
    {
        // arrange
        Snapshot.FullName();

        var schema = SchemaBuilder.New()
            .AddQueryType(o => o
                .Name("Query")
                .Field("someField")
                .Argument("a", a => a.Type<IntType>())
                .Type("TestType")
            )
            .AddObjectType(
                o =>
                {
                    o.Name("TestType").Key("id");
                    o.Field("id").Type<IntType>();
                    o.Field("name").Type<StringType>();
                })
            .AddDirectiveType<KeyDirectiveType>()
            .AddType<FieldSetType>()
            .Use(next => next)
            .Create();

        // act
        var testType = schema.GetType<ObjectType>("TestType");

        // assert
        Assert.Collection(
            testType.Directives,
            item =>
            {
                Assert.Equal(WellKnownTypeNames.Key, item.Name);
                Assert.Equal("fields", item.ToNode().Arguments[0].Name.ToString());
                Assert.Equal("\"id\"", item.ToNode().Arguments[0].Value.ToString());
            });

        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public void AnnotateKeyToObjectTypeSchemaFirst()
    {
        // arrange
        Snapshot.FullName();

        var schema = SchemaBuilder.New()
            .AddDocumentFromString(
                @"
                    type TestType @key(fields: ""id"") {
                        id: Int!
                        name: String!
                    }

                    type Query {
                        someField(a: Int): TestType
                    }

                    interface IQuery {
                        someField(a: Int): TestType
                    }")
            .AddDirectiveType<KeyDirectiveType>()
            .AddType<FieldSetType>()
            .Use(next => context => default)
            .Create();

        // act
        var testType = schema.GetType<ObjectType>("TestType");

        // assert
        Assert.Collection(testType.Directives,
            item =>
            {
                Assert.Equal(
                    WellKnownTypeNames.Key,
                    item.Name
                );
                Assert.Equal("fields", item.ToNode().Arguments[0].Name.ToString());
                Assert.Equal("\"id\"", item.ToNode().Arguments[0].Value.ToString());
            });

        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public void AnnotateKeyToObjectTypePureCodeFirst()
    {
        // arrange
        Snapshot.FullName();

        var schema = SchemaBuilder.New()
            .AddApolloFederation()
            .AddQueryType<Query<TestTypeClassDirective>>()
            .Create();

        // act
        var testType = schema.GetType<ObjectType>("TestTypeClassDirective");

        // assert
        Assert.Collection(testType.Directives,
            item =>
            {
                Assert.Equal(
                    WellKnownTypeNames.Key,
                    item.Name
                );
                Assert.Equal("fields", item.ToNode().Arguments[0].Name.ToString());
                Assert.Equal("\"id\"", item.ToNode().Arguments[0].Value.ToString());
            });

        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public void AnnotateKeyToClassAttributePureCodeFirst()
    {
        // arrange
        Snapshot.FullName();

        var schema = SchemaBuilder.New()
            .AddApolloFederation()
            .AddQueryType<Query<TestTypePropertyDirective>>()
            .Create();

        // act
        var testType = schema.GetType<ObjectType>("TestTypePropertyDirective");

        // assert
        Assert.Collection(testType.Directives,
            item =>
            {
                Assert.Equal(
                    WellKnownTypeNames.Key,
                    item.Name
                );
                Assert.Equal("fields", item.ToNode().Arguments[0].Name.ToString());
                Assert.Equal("\"id\"", item.ToNode().Arguments[0].Value.ToString());
            });

        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public void AnnotateKeyToClassAttributesPureCodeFirst()
    {
        // arrange
        Snapshot.FullName();

        var schema = SchemaBuilder.New()
            .AddApolloFederation()
            .AddQueryType<Query<TestTypePropertyDirectives>>()
            .Create();

        // act
        var testType = schema.GetType<ObjectType>("TestTypePropertyDirectives");

        // assert
        Assert.Collection(testType.Directives,
            item =>
            {
                Assert.Equal(
                    WellKnownTypeNames.Key,
                    item.Name
                );
                Assert.Equal("fields", item.ToNode().Arguments[0].Name.ToString());
                Assert.Equal("\"id name\"", item.ToNode().Arguments[0].Value.ToString());
            });

        schema.ToString().MatchSnapshot();
    }

    public class Query<T>
    {
        public T someField(int id) => default!;
    }

    [Key("id")]
    public class TestTypeClassDirective
    {
        public int Id { get; set; }
    }

    public class TestTypePropertyDirective
    {
        [Key]
        public int Id { get; set; }
    }

    public class TestTypePropertyDirectives
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string Name { get; set; } = default!;
    }
}
