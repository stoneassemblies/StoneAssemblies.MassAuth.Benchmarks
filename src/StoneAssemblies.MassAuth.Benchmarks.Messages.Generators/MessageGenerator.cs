// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageGenerator.cs" company="Stone Assemblies">
// Copyright © 2021 - 2021 Stone Assemblies. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace StoneAssemblies.MassAuth.Benchmarks.Messages.Generators
{
    using System.Text;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    [Generator]
    public class MessageGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var sourceBuilder = new StringBuilder(
                @"namespace StoneAssemblies.MassAuth.Benchmarks.Messages
{
    using StoneAssemblies.MassAuth.Messages;
");

            for (int i = 1; i <= 100; i++)
            {
                sourceBuilder.Append($@"public class TextMessage{i.ToString().PadLeft(3, '0')}: MessageBase
    {{
        public string Text {{ get; set; }}
    }}");
            }

            sourceBuilder.Append("}");
            context.AddSource("messages", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }

}