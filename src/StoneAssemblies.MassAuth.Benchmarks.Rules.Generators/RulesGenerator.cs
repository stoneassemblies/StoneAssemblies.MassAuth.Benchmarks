namespace StoneAssemblies.MassAuth.Benchmarks.Rules
{
    using System.Text;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    [Generator]
    public class RulesGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var sourceBuilder = new StringBuilder(
                @"namespace StoneAssemblies.MassAuth.Benchmarks.Rules
{
    using System;
    using System.Threading.Tasks;

    using StoneAssemblies.MassAuth.Benchmarks.Messages;
    using StoneAssemblies.MassAuth.Messages;
    using StoneAssemblies.MassAuth.Rules.Interfaces;
");
            for (var i = 1; i <= 100; i++)
            {
                var textMessageName = $"TextMessage{i.ToString().PadLeft(3, '0')}";
                for (var j = 1; j < i + 1; j++)
                {
                    var ruleName = $"RandomRule{j.ToString().PadLeft(3, '0')}";
                    var rule =
                        $@"
    public class {textMessageName}{ruleName} : IRule<AuthorizationRequestMessage<{textMessageName}>>
    {{
        private readonly Random random = new Random();

        public bool IsEnabled => true;

        public string Name => ""Random rule {j} for text message {i}"";

        public int Priority {{ get; }}

        public Task<EvaluationResult> EvaluateAsync(AuthorizationRequestMessage<{textMessageName}> message)
        {{
            return Task.FromResult(this.random.Next() % 2 == 0 ?  EvaluationResult.Success() : EvaluationResult.Error());
        }}
    }}";
                    sourceBuilder.Append(rule);
                }
            }

            for (var i = 1; i <= 100; i++)
            {
                var textMessageName = $"ValidTextMessage{i.ToString().PadLeft(3, '0')}";
                for (var j = 1; j < i + 1; j++)
                {
                    var ruleName = $"ValidRule{j.ToString().PadLeft(3, '0')}";
                    var rule =
                        $@"
    public class {textMessageName}{ruleName} : IRule<AuthorizationRequestMessage<{textMessageName}>>
    {{
        public bool IsEnabled => true;

        public string Name => ""Valid rule {j} for text message {i}"";

        public int Priority {{ get; }}

        public Task<EvaluationResult> EvaluateAsync(AuthorizationRequestMessage<{textMessageName}> message)
        {{
            return Task.FromResult(EvaluationResult.Success());
        }}
    }}";
                    sourceBuilder.Append(rule);
                }
            }

            sourceBuilder.Append("}");
            context.AddSource("rules", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}