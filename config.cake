string NuGetVersionV2 = "";
string SolutionFileName = "src/StoneAssemblies.MassAuth.Benchmarks.sln";

string[] DockerFiles = System.Array.Empty<string>();

string[] OutputImages = System.Array.Empty<string>();

string[] ComponentProjects  = new [] {
	"./src/StoneAssemblies.MassAuth.Benchmarks.Messages/StoneAssemblies.MassAuth.Benchmarks.Messages.csproj",
	"./src/StoneAssemblies.MassAuth.Benchmarks.Rules/StoneAssemblies.MassAuth.Benchmarks.Rules.csproj"
};